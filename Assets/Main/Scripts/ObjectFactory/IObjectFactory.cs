using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectFactory
{
    void InstantiateObject(ObjectType type, Transform transform);
}
