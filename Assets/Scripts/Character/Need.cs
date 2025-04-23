using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Need
{
    public NeedType type;
    public float currentValue = 100f;
    public float decayRate = 5f;
    public float maxValue = 100f; 

    private INeedStrategy strategy;

    public Need(NeedType type, float decayRate, INeedStrategy strategy = null)
    {
        this.type = type;
        this.decayRate = decayRate;
        this.strategy = strategy ?? new DefaultNeedStrategy();
    }

    //public void SetStrategy(INeedStrategy newStrategy) => strategy = newStrategy;

    public void Update(float deltaTime)
    {
        currentValue = strategy.CalculateDecay(currentValue, decayRate, deltaTime);
    }

    public void Increase(float amount)
    {
        currentValue = Mathf.Min(maxValue, currentValue + amount);
    }
}
