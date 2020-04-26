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
        if(col.gameObject.name == "Player")
        {
            Debug.Log("You died");
        }

        if(col.gameObject.tag == "box")
        {
            col.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
