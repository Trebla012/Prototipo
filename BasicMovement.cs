
using System.Collections;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    CharacterController characterController;
    private Animator anim;

    public float Speed = 4f;
    public float rotSpeed = 120;
    float gravity = 8;
    float rot = 0;
    public float jumpForce;

    Vector3 moveDir = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        GetInput();
    }

    void Movement()
    {
        if (characterController.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (anim.GetBool("attacking") == true)
                {
                    return;
                }
                else if (anim.GetBool("attacking") == false)
                {
                    anim.SetBool("running", true);
                    anim.SetInteger("Condition", 1);
                    moveDir = new Vector3(0, 0, 1);
                    moveDir *= Speed;
                    moveDir = transform.TransformDirection(moveDir);
                }
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetBool("running", false);
                anim.SetInteger("Condition", 0);
                moveDir = new Vector3(0, 0, 0);

            }
            if (Input.GetKey(KeyCode.S))
            {
                if (anim.GetBool("attacking") == true)
                {
                    return;
                }
                else if (anim.GetBool("attacking") == false)
                {
                    anim.SetBool("running", true);
                    anim.SetInteger("Condition", 1);
                    moveDir = new Vector3(0, 0, -1);
                    moveDir *= Speed;
                    moveDir = transform.TransformDirection(moveDir);
                }
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetBool("running", false);
                anim.SetInteger("Condition", 0);
                moveDir = new Vector3(0, 0, 0);

            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetInteger("Condition", 3);
                moveDir.y = jumpForce;
            }

          
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -= gravity * Time.deltaTime;
        characterController.Move(moveDir * Time.deltaTime);
    }
    void GetInput()
    {
        if (characterController.isGrounded)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (anim.GetBool("running") == true)
                {
                    anim.SetBool("running", false);
                    anim.SetInteger("Condition", 0);
                }
                if (anim.GetBool("running") == false)
                {
                    Attacking();
                }
             
            }
            
       }
    }
    void Attacking()
    {
        anim.SetInteger("Condition", 2);
        StartCoroutine(attackRoutine());
        
    }

    IEnumerator attackRoutine()
    {
        yield return new WaitForSeconds(1);
    }
}