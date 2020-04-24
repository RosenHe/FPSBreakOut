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
    [SerializeField] private float jumpMultiplier = 1;
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

    private bool isJumping;

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

        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
        else
        {
            normal = (forwardMovement + rightMovement) * Time.deltaTime;
            normal.y = normal.y - gravity * Time.deltaTime;
            controller.Move(normal);
        }
    }
    private IEnumerator JumpEvent()
    {
        controller.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * airSpeed * Time.deltaTime, jumpForce * jumpMultiplier * Time.deltaTime, Input.GetAxis("Vertical") * airSpeed * Time.deltaTime) ;
            controller.Move(moveDirection);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!controller.isGrounded && controller.collisionFlags != CollisionFlags.Above);

        controller.slopeLimit = 45.0f;
        isJumping = false;
    }

}