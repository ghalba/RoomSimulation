using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultNeedStrategy : INeedStrategy
{
    public float CalculateDecay(float currentValue, float decayRate, float deltaTime)
    {
        return Mathf.Max(0, currentValue - decayRate * deltaTime);
    }
}
