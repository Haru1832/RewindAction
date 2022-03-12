using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class PlayerTimeController : MonoBehaviour
{
    private IPlayerInput _playerInput;
    
    private ITimeManager _timeManager;

    private Ray rayCamera;

    private Camera mainCamera;
    // Start is called before the first frame update
    private void Awake()
    {
        mainCamera=Camera.main;
        _playerInput = new KeyBoardPlayerInput();
        _timeManager = TimeManager.Instance;
    }

    void Start()
    {
        this.UpdateAsObservable()
            .Where(_=>_playerInput.PushedStopObject)
            .Subscribe(_ => Stop())
            .AddTo(this);
        
        this.UpdateAsObservable()
            .Where(_=>_playerInput.PushedRewindObject)
            .Subscribe(_ => Rewind())
            .AddTo(this);
    }


    private bool RayCastToObject(out BaseObject baseObject)
    {
        rayCamera = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(rayCamera, out RaycastHit hit))
        {
            if (hit.transform.TryGetComponent<BaseObject>(out var obj))
            {
                baseObject = obj;
                return true;
            }
        }

        baseObject = null;
        return false;
    }

    void Stop()
    {
        if (RayCastToObject(out BaseObject obj))
        {
            if (!obj.isStopped)
            {
                //obj.Stop();
                _timeManager.StopObject(obj);
            }
            else
            {
                //obj.UnStop();
                _timeManager.UnStopObject(obj);
            }
            
        }
    }

    void Rewind()
    {
        if (RayCastToObject(out BaseObject obj))
        {
            if (!obj.isRewinded)
            {
                //obj.Rewind();
                _timeManager.RewindObject(obj);
            }
            else
            {
                //obj.UnRewind();
                _timeManager.UnRewindObject(obj);
            }
            
        }
    }
}
