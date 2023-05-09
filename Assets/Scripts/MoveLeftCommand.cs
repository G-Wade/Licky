using UnityEngine;

public class MoveLeftCommand : Command
{
    private float _distance;
    private IEntity _entity;

    public MoveLeftCommand(IEntity entity, float time, float distance) : base(entity, time) {
        _distance = distance;
        _entity = entity;
    }

    public override void Execute() {
        _distance -= _entity.getAcceleration;
        _entity.getCurrentSpeed = _distance;
        _entity.getXVelocity = _distance;
        _entity.getRigidBody2D.velocity = _entity.getVelocity;
    }

    public override void Undo() {
        _entity.getXVelocity = Mathf.Abs(_entity.getCurrentSpeed);
        _entity.getRigidBody2D.velocity = _entity.getVelocity;
    }
}
