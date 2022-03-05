using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager
{
    void ChangeGameState(GameState state);
    void OnChange();
}
