using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTimeObject : MonoBehaviour,ITimeObject
{
    private bool isFreezing = false;
    bool isRewinding = false;

    public float recordTime = 5f;

    List<PointInTime> pointsInTime;

    Rigidbody rb;

    // Use this for initialization
    void Start () {
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
    }
	
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
            StartRewind();
        if (Input.GetKeyUp(KeyCode.Return))
            StopRewind();
        
        if(Input.GetKeyDown(KeyCode.F))
            Freeze();
        if(Input.GetKeyUp(KeyCode.F))
            UnFreeze();
        
    }

    void FixedUpdate ()
    {
        if (isRewinding)
            Rewind();
        else
            Record();
    }

    public void Rewind ()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        } else
        {
            StopRewind();
        }
		
    }

    public void Record ()
    {
        if (isFreezing) return;
        if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }

        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    public void StartRewind ()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind ()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }
    

    public void Freeze()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        isFreezing = true;
    }
    
    public void UnFreeze()
    {
        rb.constraints = RigidbodyConstraints.None;
        isFreezing = false;
    }
    
}
