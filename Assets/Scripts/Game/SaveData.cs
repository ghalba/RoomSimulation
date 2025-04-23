using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public List<NeedData> needs = new List<NeedData>();
    public string saveTime;
}

[System.Serializable]
public class NeedData
{
    public NeedType needType;
    public float currentValue;
}
