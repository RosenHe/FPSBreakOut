using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //gotta add the player death / game restart logic call here
        if(col.gameObject.name == "Player")
        {
            Debug.Log("You died");
            Application.LoadLevel(0);
        }

        //stops the boxes from moving
        if(col.gameObject.tag == "box")
        {   
            col.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            col.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            col.gameObject.GetComponent<Rigidbody>().isKinematic = true;


        }
    }
}
