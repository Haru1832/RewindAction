using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class StopTimeManager : MonoBehaviour
{
    private List<BaseObject> _stoppedObject;
    
    
    [SerializeField]
    private TimeManagerScriiptableObject stopValues;


    private float StopRemainingTime;

    
    
    // Start is called before the first frame update
    void Start()
    {
        _stoppedObject=new List<BaseObject>();
        StopRemainingTime = stopValues.remainingMaxTime;
        
        ManageStopRemainingTime();
    }

    public float GetStopTime()
    {
        return StopRemainingTime;
    }
    

    public void AddObject(BaseObject obj)
    {
        _stoppedObject.Add(obj);
    }

    public void RemoveObject(BaseObject obj)
    {
        _stoppedObject.Remove(obj);
    }
    
    
    private void ManageStopRemainingTime()
    {
        this.UpdateAsObservable()
            .Where(_ => _stoppedObject.Any())
            .Subscribe(_ =>
            {
                var subValue = stopValues.subTimeValue * _stoppedObject.Count;
                StopRemainingTime -= subValue;
                StopRemainingTime = Mathf.Clamp(StopRemainingTime, 0, stopValues.remainingMaxTime);
            })
            .AddTo(this);
        
        this.UpdateAsObservable()
            .Where(_ => !_stoppedObject.Any())
            .Subscribe(_ =>
            {
                StopRemainingTime += stopValues.addTimeValue;
                StopRemainingTime = Mathf.Clamp(StopRemainingTime, 0, stopValues.remainingMaxTime);
            })
            .AddTo(this);

        this.ObserveEveryValueChanged(x => x.StopRemainingTime)
            .Where(x => x <= 0)
            .Subscribe(_ => ClearStopList())
            .AddTo(this);
    }
    
    void ClearStopList()
    {
        foreach (var obj in _stoppedObject)
        {
            obj.UnStop();
        }
        _stoppedObject.Clear();
    }

}
