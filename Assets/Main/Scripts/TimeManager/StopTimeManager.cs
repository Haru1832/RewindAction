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
    private float subStopValue=0.1f;
    [SerializeField]
    private float addStopValue=0.2f;
    
    [SerializeField]
    private float stopRemainingMaxTime=100;
    public float StopRemainingMaxTime => stopRemainingMaxTime;
    
    
    public float StopRemainingTime { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        _stoppedObject=new List<BaseObject>();
        StopRemainingTime = stopRemainingMaxTime;
        
        ManageStopRemainingTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public float GetStopTime()
    {
        return StopRemainingTime;
    }

    public float GetStopMaxTime()
    {
        return StopRemainingMaxTime;
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
                var subValue = subStopValue * _stoppedObject.Count;
                StopRemainingTime -= subValue;
                StopRemainingTime = StopRemainingTime < 0 ? 0 : StopRemainingTime;
            })
            .AddTo(this);
        
        this.UpdateAsObservable()
            .Where(_ => !_stoppedObject.Any())
            .Subscribe(_ =>
            {
                StopRemainingTime += addStopValue;
                StopRemainingTime = StopRemainingTime > stopRemainingMaxTime ? stopRemainingMaxTime : StopRemainingTime;
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
