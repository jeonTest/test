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
        if(rotation3D == true && rotation2D == true)
        {
            rotation2D = false;
            Debug.Log("Nur eine Rotation auswählen!");
        }
    }

    
    void Update()
    {
        Move();
        if (rotation3D == true)
        {
            Rotate3D();
        }
        else if (rotation2D == true)
        {
            Rotate2D();
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
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, (PlayerRotateSpeed*100) * Time.deltaTime);
        }
    }

    public void Rotate2D()
    {
        if (MoveVector.x < 0 && facingRight)
        {
            Flip();
        }
        if (MoveVector.x > 0 && !facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    #endregion
}
