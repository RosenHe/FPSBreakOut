using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boxInteraction : MonoBehaviour
{
    Rigidbody boxBody;
    Transform boxT;
    private float speed = 60f;

    [SerializeField] private float countDown = 0f;
    private float timeLeft;
    public Text textTimer;


    public bool isPlatform = false;
    public bool beenHit = false;
    public float boxDistance;

    private void Awake()
    {
        boxBody = GetComponent<Rigidbody>();
        boxT = GetComponent<Transform>();

    }
    void Start()
    {
        textTimer = GameObject.Find("countDownText").GetComponent<Text>();
        timeLeft = countDown; //set box timer
        boxDistance = GetComponent<Collider>().bounds.extents.y;
    }

    void Update()
    {
        if (isPlatform)
        {

            //Debug.Log("box is platform in update");
            if (timeLeft > 0)
            {
                textTimer.text = timeLeft.ToString("0");
                timeLeft -= 1 * Time.deltaTime;
            }

            if (timeLeft <= 0)
            {
                textTimer.text = " ";
                Destroy(gameObject);
            }

        }
    }



    private void OnCollisionEnter(Collision col)
    {
        float force = 15f;

        Transform target = col.gameObject.GetComponentInParent<Transform>();

        if (col.gameObject.tag == "ball" && transform.parent != null) //first ball hit
        {
            boxBody.isKinematic = false;
            beenHit = true;
            //Debug.Log(col.gameObject.name);
            transform.parent = null;
            Vector3 dir = new Vector3(0, 0, -1);
            boxBody.useGravity = true;
            boxBody.AddForce(dir * force, ForceMode.VelocityChange);
        }
        else if ((col.gameObject.tag == "ball") && boxBody.useGravity == true) //second ball hit or touches player
        {
            boxBody.AddForce(Vector3.down * force);
        }


    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log("contacting Player");
            isPlatform = true;
        }
    }


    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log("leaving Player");
            isPlatform = false;
            textTimer.text = " ";
        }
    }
}
