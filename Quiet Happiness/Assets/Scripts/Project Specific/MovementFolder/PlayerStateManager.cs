using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerStateManager : MonoBehaviour
{
    public void Awake()
    {
        Controller = GetComponent<CharacterController>();
        Input = GetComponent<PlayerInput>();
        _gravityVector = new Vector3(0, -9.81f, 0);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        Move();
        if (rotation3D == true)
        {
            Rotate3D();
        }
        ApplyGravity();
    }

    #region Movement

    public void ApplyGravity()
    {
        Controller.Move(_gravityVector * Time.deltaTime);
    }

    public void Move()
    {
        Controller.Move(PlayerSpeed * MoveVector * Time.deltaTime);
    }


    public void Rotate3D()
    {
        var xzDirection = new Vector3(MoveVector.x, 0, MoveVector.z);
        if (xzDirection.magnitude != 0)
        {
            Quaternion rotation = Quaternion.LookRotation(xzDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, PlayerRotateSpeed * Time.deltaTime);
        }
    }

    public void Rotate2D()
    {

    }

    #endregion
}
