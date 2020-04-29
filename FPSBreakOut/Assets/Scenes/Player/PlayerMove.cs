using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //[SerializeField] private string horizontalInputName;
    //[SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;

    private CharacterController controller;

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier = 20;
    [SerializeField] private KeyCode jumpKey;

    private Vector3 moveDirection;
    private float speed = 10;
    private float jumpSpeed =10;
    float horizInput;
    float vertInput;
    Vector3 forwardMovement;
    Vector3 rightMovement;
    Vector3 normal;
    float airSpeed = 5;
    float gravity = 5f;
    public static bool useGravity = true;

    private bool isJumping;
    private bool dblJumping;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

    }

    private void Update()
    {
        
        PlayerMovement();
    }

    private void PlayerMovement()
    {


        horizInput = Input.GetAxis("Horizontal") * movementSpeed;
        vertInput = Input.GetAxis("Vertical") * movementSpeed;
        forwardMovement = transform.forward * vertInput;
        rightMovement = transform.right * horizInput;

        if (Input.GetKeyDown(jumpKey) && !isJumping || controller.collisionFlags == CollisionFlags.Sides && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
        else if(Input.GetKeyDown(jumpKey) && isJumping && !dblJumping) //double jump
        {
            dblJumping = true;
            StartCoroutine(DblJumpEvent());
        }
        else
        {
            moveDirection = (forwardMovement + rightMovement) * Time.deltaTime;
        }
        if (useGravity)
        {
            moveDirection.y = moveDirection.y - gravity * Time.deltaTime;
        }
        controller.Move(moveDirection);
    }
    private IEnumerator JumpEvent()
    {
        controller.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            moveDirection = Vector3.up * (jumpForce * jumpMultiplier * 1.5f* Time.deltaTime) + normal;
            controller.Move(moveDirection);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!controller.isGrounded && controller.collisionFlags != CollisionFlags.Above);

        controller.slopeLimit = 45.0f;
        isJumping = false;
    }

    private IEnumerator DblJumpEvent()
    {
        controller.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            moveDirection = Vector3.up * (jumpForce * jumpMultiplier * Time.deltaTime) + normal;
            controller.Move(moveDirection);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!controller.isGrounded && controller.collisionFlags != CollisionFlags.Above);

        controller.slopeLimit = 45.0f;
        dblJumping = false;

        
    }

   

}