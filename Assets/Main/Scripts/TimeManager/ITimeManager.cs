using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimeManager 
{
    float StopRemainingTime { get; }
    float RewindRemainingTime { get; }
    void StopObject(BaseObject obj);

    void UnStopObject(BaseObject obj);
    void RewindObject(BaseObject obj);

    void UnRewindObject(BaseObject obj);
}
