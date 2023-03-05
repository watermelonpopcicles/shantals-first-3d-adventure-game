using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 6.0f;
    public float runspeed = 8.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float rotationspeed = 90.0f;

    private Vector3 moveDirection = Vector3.zero;
    public Animator anim;
    private CharacterController controller;
    public Transform target;
    public float RotationSpeed = 100f;
    public float OrbitDegrees = 1f;
    void Start()
    {
        controller = GetComponentInChildren<CharacterController>();

    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 rot = new Vector3(0,h,0);
        transform.Rotate(rot * rotationspeed * Time.deltaTime);

        if (h > 0)
        {
            //anim.SetBool("r turn", true);
            //anim.SetBool("L turn", false);
        }
        else if (h < 0)
        {
            //anim.SetBool("r turn", false);
            //anim.SetBool("L turn", true);
        }
        else
        {
            //anim.SetBool("r turn", false);
            //anim.SetBool("L turn", false);
        }
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(0, 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);


            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection = moveDirection * runspeed;
                anim.SetBool("Run", true);
                anim.SetBool("Walk", false);
            }
            else
            {
                moveDirection = moveDirection * speed;
                anim.SetBool("Run", false);
                anim.SetBool("Walk", true);
            }

            if (moveDirection == Vector3.zero)
            {
                anim.SetBool("Run", false);
                anim.SetBool("Walk", false);
            }
            

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                anim.SetTrigger("Jump");
            }
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
        //anim.SetFloat("speed", moveDirection.magnitude);

        

        
}
}
