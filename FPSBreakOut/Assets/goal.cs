using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class goal : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
