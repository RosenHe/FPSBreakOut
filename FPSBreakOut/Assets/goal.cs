using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class goal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool isEndless;
    [SerializeField] Text finishText;
    private string textPlaceholder;
    private bool isMoving = false;
    private bool nextLevel = false;
    private int targetScene;
    [SerializeField] private float timer = 5f; 
    private void Update()
    {
        if(isMoving)
        {
            if (nextLevel)
            {
                finishText.text = textPlaceholder + timer.ToString("0");
            }
            else
            {
                finishText.text = textPlaceholder;
            }
           
            timer -= 1 * Time.deltaTime;
            if (timer < 0) 
            {
                if (targetScene == 0)
                {
                    Time.timeScale = 1;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    SceneManager.LoadScene(0);
                }
                else
                {
                    SceneManager.LoadScene(targetScene);
                }
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision);
        if (collision.gameObject.tag == "Player")
        {
            isMoving = true;
        
            

            if (SceneManager.GetActiveScene().buildIndex + 1 > 4)
            {
                //done with the game
                textPlaceholder = "You Broke Out! ";
                targetScene = 0;
                nextLevel = false;
            }
            else
            {
                //next level
                nextLevel = true;

                if (isEndless)
                {
                    targetScene = 1;
                    textPlaceholder = "ENDLESS!!!...";
                }
                else
                {
                    textPlaceholder = "Next Level in ...";
                }
                
                targetScene = SceneManager.GetActiveScene().buildIndex + 1;
            }
            
        }
    }
}
