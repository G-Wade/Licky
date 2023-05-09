using UnityEngine;

public class JumpCommand : Command
{
    private float _distance;
    private IEntity _entity;

    public JumpCommand(IEntity entity, float time, float distance) : base(entity, time) {
        _distance = distance;
        _entity = entity;
    }

    public override void Execute() {
        _entity.getYVelocity = _distance;
        _entity.getRigidBody2D.velocity = _entity.getVelocity;
    }

    public override void Undo() {
    }
}
