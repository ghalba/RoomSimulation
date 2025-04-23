using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedBarUI : MonoBehaviour
{
    public NeedType needType;
    private Slider slider;


    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void UpdateNeedValue(float value)
    {
        slider.value = value;
    }
}
