using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    Rigidbody2D getRigidBody2D { get; set; }
    float getYVelocity { get; set; }
    float getXVelocity { get; set; }
    Vector2 getVelocity { get; set; }
    float getAcceleration { get; set; }
    float getCurrentSpeed { get; set; }
}
