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
            Vector3 camDirection = Camera.main.transform.forward;

            if (MoveVector.z > 0)
            {
                Controller.Move(PlayerSpeed * camDirection * Time.deltaTime);
            }
            if(MoveVector.z < 0)
            {
                Vector3 backward = transform.forward * -1;
                Controller.Move(PlayerSpeed * backward * Time.deltaTime);
            }
            /*if(MoveVector.x != 0)
            {
                Vector3 forward = transform.forward;
                Controller.Move(PlayerSpeed * forward * Time.deltaTime);
            }*/
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
            /*float rotation = transform.eulerAngles.y;
            if (MoveVector.x < 0) // A Rotation ins Negative
            {
                rotation -= PlayerRotateSpeed;
            }

            if (MoveVector.x > 0) // D Rotation ins Positive
            {
                rotation += PlayerRotateSpeed;
            }

            if(MoveVector.x == 0)
            {
                rotation = (Camera.main.transform.eulerAngles.y);
            }*/
            float rotation = Camera.main.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotation, transform.eulerAngles.z);

            //transform.rotation = Quaternion.Euler(0, rotation, 0);
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
