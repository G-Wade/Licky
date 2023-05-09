using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    public IPlayerState Tick(PlayerMovementController player);
    public void Enter(PlayerMovementController player);
    public void Exit(PlayerMovementController player);
}
