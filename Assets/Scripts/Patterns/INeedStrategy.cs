using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INeedStrategy
{
    float CalculateDecay(float currentValue, float decayRate, float deltaTime);
}
