using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class UITimeSlider : MonoBehaviour
{
    [SerializeField]
    private Slider StopSlider;
    [SerializeField]
    private Slider RewindSlider;
    


    public void UpdateStopSlider(float value)
    {
        StopSlider.value = value;
    }

    public void UpdateRewindSlider(float value)
    {
        RewindSlider.value = value;
    }
}
