using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

[RequireComponent(typeof(StopTimeManager))]
[RequireComponent(typeof(RewindTimeManager))]
public class TimeManager :　SingletonMonoBehaviour<TimeManager>,ITimeManager
{

    private StopTimeManager _stopTimeManager;
    private RewindTimeManager _rewindTimeManager;
    

    public float RewindRemainingMaxTime => _rewindTimeManager.GetRewindMaxTime();

    public float StopRemainingMaxTime => _stopTimeManager.GetStopMaxTime();

    public float StopRemainingTime => _stopTimeManager.GetStopTime();
    public float RewindRemainingTime => _rewindTimeManager.GetRewindTime();
    
    
    // Start is called before the first frame update
    void Awake()
    {
        _stopTimeManager = GetComponent<StopTimeManager>();
        _rewindTimeManager = GetComponent<RewindTimeManager>();
    }

   

    public void StopObject(BaseObject obj)
    {
        _stopTimeManager.AddObject(obj);
    }

    public void RewindObject(BaseObject obj)
    {
        _rewindTimeManager.AddObject(obj);
    }

    public void UnStopObject(BaseObject obj)
    {
        _stopTimeManager.RemoveObject(obj);
    }

    public void UnRewindObject(BaseObject obj)
    {
        _rewindTimeManager.RemoveObject(obj);
    }
}
