using System;
using System.Collections.Generic;
using UnityEngine;

public class NeedManager : MonoBehaviour
{
    public List<Need> needs = new List<Need>();
    private Dictionary<NeedType, NeedBarUI> needUIs;


    private void Awake()
    {
        needs.Add(new Need(NeedType.Hunger, 2f));
        needs.Add(new Need(NeedType.Bladder, 3f));
        needs.Add(new Need(NeedType.Sleep, 1.5f));
        needs.Add(new Need(NeedType.Fun, 2.5f));
    }


    private void OnApplicationQuit()
    {
        SaveNeeds();
    }
    private void Start()
    {
        LoadNeeds();

        // Find all UI bars in the scene and link them by type
        NeedBarUI[] uiBars = FindObjectsOfType<NeedBarUI>();
        needUIs = new Dictionary<NeedType, NeedBarUI>();

        foreach (var ui in uiBars)
        {
            needUIs[ui.needType] = ui;
        }
    }

    private void Update()
    {
        foreach (var need in needs)
        {
            need.Update(Time.deltaTime);
            UpdateUI(need);

        }
    }
    private void UpdateUI(Need need)
    {
        if (needUIs.ContainsKey(need.type))
        {
            needUIs[need.type].UpdateNeedValue(need.currentValue / need.maxValue);
        }
    }


    public void SatisfyNeed(NeedType type, float amount)
    {
        var need = needs.Find(n => n.type == type);
        if (need != null)
        {
            need.Increase(amount);
            UpdateUI(need);

        }

    }

    public void SaveNeeds()
    {
        SaveData saveData = new SaveData();
        foreach (var need in needs)
        {
            saveData.needs.Add(new NeedData
            {
                needType = need.type,
                currentValue = need.currentValue
            });
        }

        saveData.saveTime = System.DateTime.Now.ToString();
        SaveSystem.Save(saveData);
    }

    public void LoadNeeds()
    {
        SaveData loadedData = SaveSystem.Load();
        if (loadedData == null) return;

        // 1. Convertir l’heure de sauvegarde
        DateTime lastSaveTime;
        if (!DateTime.TryParse(loadedData.saveTime, out lastSaveTime))
        {
            Debug.LogWarning("Failed to parse save time.");
            return;
        }

        // 2. Calculer le temps écoulé
        TimeSpan timeElapsed = DateTime.Now - lastSaveTime;
        float minutesElapsed = (float)timeElapsed.TotalMinutes;
        Debug.Log("Minutes écoulées depuis la dernière sauvegarde : " + minutesElapsed);

        // 3. Appliquer la perte automatique
        foreach (var savedNeed in loadedData.needs)
        {
            Need need = needs.Find(n => n.type == savedNeed.needType);
            if (need != null)
            {
                float decayPerMinute = need.decayRate;
                float lostAmount = decayPerMinute * minutesElapsed;
                need.currentValue = Mathf.Max(0, savedNeed.currentValue - lostAmount);
            }
        }
    }


}
