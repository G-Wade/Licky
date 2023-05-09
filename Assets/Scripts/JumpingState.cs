using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : IPlayerState
{
    private float jumpingSpeed;
    private float speed;
    private CommandProcessor commandProcessor;

    public void Enter(PlayerMovementController player)
    {
        Debug.Log("Jumping");
        commandProcessor = player.GetComponent<CommandProcessor>();
        jumpingSpeed = player.getJumpSpeed;
        commandProcessor.ExecuteCommand(new JumpCommand(player, Time.timeSinceLevelLoad, jumpingSpeed));
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

        if (player.getOnGround && player.getCurrentSpeed == 0f && player.getYVelocity == 0f)
        {
            return new IdleState();
        }

        if (player.getOnGround && player.getCurrentSpeed != 0f && player.getYVelocity == 0f)
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