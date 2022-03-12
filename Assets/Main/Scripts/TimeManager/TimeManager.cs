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
        obj.Stop();
        _stopTimeManager.AddObject(obj);
    }

    public void RewindObject(BaseObject obj)
    {
        obj.Rewind();
        _rewindTimeManager.AddObject(obj);
    }

    public void UnStopObject(BaseObject obj)
    {
        obj.UnStop();
        _stopTimeManager.RemoveObject(obj);
    }

    public void UnRewindObject(BaseObject obj)
    {
        obj.UnRewind();
        _rewindTimeManager.RemoveObject(obj);
    }
}
