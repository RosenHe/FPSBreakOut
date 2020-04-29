using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    [SerializeField] private string mouseXInputName, mouseYInputName;
    public float mouseSensitivity;

    [SerializeField] private Transform playerBody;
    
    [SerializeField] Vector3 camPos;
    [SerializeField] Quaternion camRot;
    [SerializeField] KeyCode camView;

    private float xAxisClamp;
    private bool thirdPerView = false;

    public void SetMouseSensitivity(float mouseSpeed)
    {
        mouseSensitivity = mouseSpeed;
    }


    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
    }


    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        CameraRotation();
      
    }

    private void CameraRotation()
    {
        //transform.position = playerBody.position;
        var firePoint = transform.GetChild(0).transform.position;
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(camView))
        {
            if (!thirdPerView)
            {
                //turn off
                thirdPerView = true;
            }
            else
            {
                //turn on
                thirdPerView = false;
            }
        }

        if (thirdPerView)
        {
            transform.position = new Vector3(playerBody.position.x, playerBody.position.y + 3f, playerBody.position.z - 4);
            //transform.rotation = new Quaternion(playerBody.rotation.x, playerBody.rotation.y, playerBody.rotation.z,playerBody.rotation.w);
            
            firePoint = new Vector3(firePoint.x, firePoint.y, playerBody.transform.position.z + 4);
        }
        else
        {
            transform.position = playerBody.position;
            firePoint = new Vector3(firePoint.x, firePoint.y, playerBody.transform.position.z + 4);
        }
       
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

}