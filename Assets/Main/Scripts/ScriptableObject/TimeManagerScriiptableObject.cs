using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TimeManagerScriptableObject", order = 1)]
public class TimeManagerScriiptableObject : ScriptableObject
{
    public float subTimeValue;
    public float addTimeValue;
    public float remainingMaxTime;
}
