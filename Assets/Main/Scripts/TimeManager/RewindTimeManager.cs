using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class RewindTimeManager : MonoBehaviour
{
    private List<BaseObject> _rewindedObject;
    
    [SerializeField]
    private TimeManagerScriiptableObject rewindValues;


    private float RewindRemainingTime;
    
    // Start is called before the first frame update
    void Start()
    {
        _rewindedObject=new List<BaseObject>();
        RewindRemainingTime = rewindValues.remainingMaxTime;
        
        ManageRewindRemainingTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public float GetRewindTime()
    {
        return RewindRemainingTime;
    }

    public void AddObject(BaseObject obj)
    {
        _rewindedObject.Add(obj);
    }

    public void RemoveObject(BaseObject obj)
    {
        _rewindedObject.Remove(obj);
    }
    
    
    private void ManageRewindRemainingTime()
    {
        this.UpdateAsObservable()
            .Where(_ => _rewindedObject.Any())
            .Subscribe(_ =>
            {
                var subValue = rewindValues.subTimeValue * _rewindedObject.Count;
                RewindRemainingTime -= subValue;
                RewindRemainingTime = Mathf.Clamp(RewindRemainingTime, 0, rewindValues.remainingMaxTime);
            })
            .AddTo(this);
        
        this.UpdateAsObservable()
            .Where(_ => !_rewindedObject.Any())
            .Subscribe(_ =>
            {
                RewindRemainingTime += rewindValues.addTimeValue;
                RewindRemainingTime = Mathf.Clamp(RewindRemainingTime, 0, rewindValues.remainingMaxTime);
            })
            .AddTo(this);

        this.ObserveEveryValueChanged(x => x.RewindRemainingTime)
            .Where(x => x <= 0)
            .Subscribe(_ => ClearRewindList())
            .AddTo(this);
    }
    
    void ClearRewindList()
    {
        foreach (var obj in _rewindedObject)
        {
            obj.UnRewind();
        }
        _rewindedObject.Clear();
    }
    
}
