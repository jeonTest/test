using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerStateManager
{
    public CharacterController Controller;
    public PlayerInput Input;

    public Animator anim;

    public Vector3 MoveVector;
    public Vector2 InputVector;
    public float PlayerSpeed;
    public float PlayerRotateSpeed;

    private Vector3 _gravityVector;

    public bool rotation3D = false;
    public bool rotation2D = false;

    public bool facingRight = true;
    
}
