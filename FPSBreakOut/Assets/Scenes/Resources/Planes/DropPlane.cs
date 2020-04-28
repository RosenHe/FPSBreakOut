using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropPlane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {


        //stops the boxes from moving
        if(col.gameObject.tag == "box")
        {   
            col.gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
            //col.gameObject.transform.Translate(Vector3.up);
            col.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            Rigidbody R = col.gameObject.GetComponent<Rigidbody>();

            //freeze box
            //R.constraints = RigidbodyConstraints.FreezeRotation;
            //R.velocity = Vector3.zero;
            R.useGravity = false;
            R.isKinematic = true;

            //Debug.Log("colliding with plane");
               
        }
    }

    private void OnTriggerExit(Collider col)
    {
        //gotta add the player death / game restart logic call here
        if (col.gameObject.name == "Player")
        {
            Debug.Log("You died");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
