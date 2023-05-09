using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IPlayerState
{
    private CommandProcessor commandProcessor;

    public void Enter(PlayerMovementController player)
    {
        Debug.Log("Idle");
        commandProcessor = player.GetComponent<CommandProcessor>();
        return;
    }

    public IPlayerState Tick(PlayerMovementController player)
    {
        if (Input.GetKeyDown(KeyCode.W) && player.getOnGround)
        {
            return new JumpingState();
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            return new RunningState();
        }

        if (Input.GetKey(KeyCode.E))
        {
            commandProcessor.UndoCommand();
        }

        return null;
    }

    public void Exit(PlayerMovementController player)
    {
        return;
    }
}