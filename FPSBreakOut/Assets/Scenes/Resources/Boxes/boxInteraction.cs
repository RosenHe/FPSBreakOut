using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxInteraction : MonoBehaviour
{
    Rigidbody boxBody;
    Transform boxT;
    private float speed = 60f;
    private void Awake()
    {
        boxBody = GetComponent<Rigidbody>();
        boxT = GetComponent<Transform>();
    }
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        float force = 13f;

        if (col.gameObject.tag == "ball")
        {
            Debug.Log(col.gameObject.name);

            Vector3 dir = new Vector3(0, 0, -1);
            boxBody.useGravity = true;
            boxBody.AddForce(dir*force, ForceMode.VelocityChange);
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
       
    }
}
