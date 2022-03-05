using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadPlayerInput :IPlayerInput
{
    public bool PushedStopObject { get; set; }
    public bool PushedRewindObject { get; set; }
    public bool PushedJump { get; set; }
    public float InputX { get; set; }
    public float InputY { get; set; }
}
