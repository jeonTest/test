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
        if (MoveVector.x != 0 || MoveVector.z != 0)
        {
            anim.SetFloat("Speed", Mathf.Abs(2));
        }
        else if(MoveVector.x == 0 && MoveVector.z == 0)
        {
            anim.SetFloat("Speed", Mathf.Abs(0));
        }
    }

    #region Movement

    public void ApplyGravity()
    {
        Controller.Move(_gravityVector * Time.deltaTime);
    }

    public void Move()
    {
        if (cameraFollowRotation == false)
        {
            Controller.Move(PlayerSpeed * MoveVector * Time.deltaTime);
        }
        if (cameraFollowRotation == true)
        {
            if (MoveVector.x != 0 || MoveVector.z != 0)
            {
                Vector3 forward = transform.forward;
                Controller.Move(PlayerSpeed * forward * Time.deltaTime);
            }
        }
    }


    public void Rotate3D()
    {
        if (cameraFollowRotation == false)
        {
            var xzDirection = new Vector3(MoveVector.x, 0, MoveVector.z);
            if (xzDirection.magnitude != 0)
            {
                Quaternion rotation = Quaternion.LookRotation(xzDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, (PlayerRotateSpeed * 100) * Time.deltaTime);
            }
        }

        if (cameraFollowRotation == true)
        {
            float rotation = transform.localEulerAngles.y;

            if (MoveVector.x < 0) // A Rotation ins Negative
            {
                rotation -= (PlayerRotateSpeed * 1);
            }

            if (MoveVector.x > 0) // D Rotation ins Positive
            {
                rotation += (PlayerRotateSpeed * 1);
            }

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotation, transform.eulerAngles.z);
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
