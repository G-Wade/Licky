using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : IPlayerState
{
    private float speed;
    private CommandProcessor commandProcessor;

    public void Enter(PlayerMovementController player)
    {
        Debug.Log("Running");
        commandProcessor = player.GetComponent<CommandProcessor>();
        return;
    }

    public IPlayerState Tick(PlayerMovementController player)
    {
        speed = player.getCurrentSpeed;
        player.getVelocity = player.getRigidBody2D.velocity;
        speed = player.getVelocity.x;

        player.getAnimator.SetFloat("Speed", Mathf.Abs(speed));

        if (Input.GetKey(KeyCode.D) && player.getVelocity.x < player.getMaxRunSpeed) {
            player.getSpriteRenderer.flipX = false;
            commandProcessor.ExecuteCommand(new MoveRightCommand(player, Time.timeSinceLevelLoad, speed));
        }

        if (Input.GetKey(KeyCode.A) && player.getVelocity.x > -player.getMaxRunSpeed) {
            player.getSpriteRenderer.flipX = true;
            commandProcessor.ExecuteCommand(new MoveLeftCommand(player, Time.timeSinceLevelLoad, speed));
        }

        if (Input.GetKeyDown(KeyCode.W) && player.getOnGround)
        {
            return new JumpingState();
        }

        if (Input.GetKey(KeyCode.E))
        {
            commandProcessor.UndoCommand();
        }

        if (player.getCurrentSpeed == 0f)
        {
            return new IdleState();
        }
        return null;
    }

    public void Exit(PlayerMovementController player)
    {
        return;
    }
}
