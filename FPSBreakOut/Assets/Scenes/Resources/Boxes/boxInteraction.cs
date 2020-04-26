using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxInteraction : MonoBehaviour
{
    Rigidbody boxBody;
    Transform boxT;
    private float speed = 60f;
    [SerializeField] private int countDown = 0;
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
        float force = 15f;

        Transform target = col.gameObject.GetComponentInParent<Transform>();

        if (col.gameObject.tag == "ball" && transform.parent != null)
        {
            boxBody.isKinematic = false;
            Debug.Log(col.gameObject.name);
            transform.parent = null;
            Vector3 dir = new Vector3(0, .1f, -1);
            boxBody.useGravity = true;
            boxBody.AddForce(dir*force, ForceMode.VelocityChange);
        }

        if (col.gameObject.tag == "Player" && boxBody.isKinematic == false)
        {
            boxBody.AddForce(Vector3.down * force);
        }


    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
       
    }
}
