using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardPlayerInput :IPlayerInput
{
    public bool PushedStopObject =>Input.GetMouseButtonDown(0);
    public bool PushedRewindObject => Input.GetMouseButtonDown(1);
    public bool PushedJump { get; set; }
    public float InputX { get; set; }
    public float InputY { get; set; }
}
