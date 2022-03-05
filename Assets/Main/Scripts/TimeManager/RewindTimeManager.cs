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
    private float subRewindValue=0.1f;
    [SerializeField]
    private float addRewindValue=0.2f;
    
    [SerializeField]
    private float rewindRemainingMaxTime=100;
    public float RewindRemainingMaxTime => rewindRemainingMaxTime;
    
    
    public float RewindRemainingTime { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        _rewindedObject=new List<BaseObject>();
        RewindRemainingTime = rewindRemainingMaxTime;
        
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
    
    public float GetRewindMaxTime()
    {
        return RewindRemainingMaxTime;
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
                var subValue = subRewindValue * _rewindedObject.Count;
                RewindRemainingTime -= subValue;
                RewindRemainingTime = RewindRemainingTime < 0 ? 0 : RewindRemainingTime;
            })
            .AddTo(this);
        
        this.UpdateAsObservable()
            .Where(_ => !_rewindedObject.Any())
            .Subscribe(_ =>
            {
                RewindRemainingTime += addRewindValue;
                RewindRemainingTime = RewindRemainingTime > rewindRemainingMaxTime ? rewindRemainingMaxTime : RewindRemainingTime;
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
