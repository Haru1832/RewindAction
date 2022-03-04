using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimeObject
{
    void Record();
    void Freeze();
    void UnFreeze();
    
    void Rewind();
}
