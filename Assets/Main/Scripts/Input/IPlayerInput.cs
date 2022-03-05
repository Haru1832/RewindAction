using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerInput
{
    bool PushedStopObject { get; }
    bool PushedRewindObject { get;}
    bool PushedJump { get; }
    float InputX { get; }
    float InputY { get; }
}
