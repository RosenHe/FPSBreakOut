using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCheats : MonoBehaviour
{
    [SerializeField] KeyCode restartLevel;
    [SerializeField] KeyCode nextLevel;
    [SerializeField] KeyCode mainMenu;
    
    [SerializeField] KeyCode gravityToggle;


    private bool gravity = true;
    private void Awake()
    {
       // cam = FindObjectOfType<Camera>();
    }

    //[SerializeField] KeyCode restart;
    //[SerializeField] KeyCode restart;
    private void Update() 
    {
        if (Input.GetKeyDown(restartLevel))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(mainMenu))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(nextLevel))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Input.GetKeyDown(gravityToggle))
        {
            if (gravity)
            {
                //turn off
                PlayerMove.useGravity = false;
                gravity = false;
            }
            else
            {
                //turn on
                PlayerMove.useGravity = true;
                gravity = true;
            }
        }
        

    }
   
}
