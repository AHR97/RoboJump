using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EnemyStat : MonoBehaviour
{
    [SerializeField]
    private EnemyBarScript bar;

    [SerializeField]
    private float maxVal;

    [SerializeField]
    private float currentVal;

    public float CurrentVal
    {
        get
        {
            return currentVal;
        }
        set
        {
            this.currentVal = Mathf.Clamp(value, 0, MaxVal);
            bar.Value = currentVal;
        }
    }

    public float MaxVal
    {
        get
        {
            return maxVal;
        }
        set
        {
            this.maxVal = value;
            bar.MaxValue = value;
        }
    }

    public void Intialize()
    {
        this.MaxVal = maxVal;
        this.CurrentVal = currentVal;
    }
}
