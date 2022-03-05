using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SelectObject))]
[RequireComponent(typeof(RewindObject))]
[RequireComponent(typeof(StopObject))]
public abstract class BaseObject : MonoBehaviour
{
    public bool isStopped;
    public bool isRewinded;
    
    
    public virtual void Stop()
    {
        isStopped = true;
        Debug.Log("Stop");
    }
    
    public virtual void UnStop()
    {
        isStopped = false;
        Debug.Log("UnStop");
    }

    public virtual void Rewind()
    {
        isRewinded = true;
        Debug.Log("Rewind");
    }

    public virtual void UnRewind()
    {
        isRewinded = false;
        Debug.Log("UnRewind");
    }
}
