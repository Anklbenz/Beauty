using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AvatarBase : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected Motor Motor;
    private void Awake() => Motor = new Motor(transform, speed);
    private void FixedUpdate() => Motor.Moving();
}
