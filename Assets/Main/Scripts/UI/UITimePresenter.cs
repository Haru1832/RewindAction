using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UITimePresenter : MonoBehaviour
{
    private ITimeManager _timeManager;

    [SerializeField] private TimeManagerScriiptableObject stopValues;
    [SerializeField] private TimeManagerScriiptableObject rewindValues;

    [SerializeField] private UITimeSlider timeSlider;
    // Start is called before the first frame update
    void Start()
    {
        _timeManager = TimeManager.Instance;
        SetChangeValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetChangeValue()
    {
        this.ObserveEveryValueChanged(x => x._timeManager.StopRemainingTime)
            .Subscribe(x=>
            {
                float sliderValue = x/stopValues.remainingMaxTime;
                timeSlider.UpdateStopSlider(sliderValue);
            });
        
        this.ObserveEveryValueChanged(x => x._timeManager.RewindRemainingTime)
            .Subscribe(x=>
            {
                float sliderValue = x/rewindValues.remainingMaxTime;
                timeSlider.UpdateRewindSlider(sliderValue);
            });
    }
}
