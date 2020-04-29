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


    public Material[] materials;
    Renderer rend;


    [SerializeField] private float flyDistance = 14f;
    public bool isPlatform = false;
    public bool beenHit = false;
    private float boxDistance;

    private void Awake()
    {
        boxBody = GetComponent<Rigidbody>();
        boxT = GetComponent<Transform>();
        rend = GetComponent<Renderer>();
    }
    void Start()
    {

        //rend.sharedMaterial = materials[0];
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
                textTimer.text = Mathf.Ceil(timeLeft).ToString("0");
                timeLeft -= 1 * Time.deltaTime;
                if (Mathf.Ceil(timeLeft) - 1 >= 0)
                {
                    rend.sharedMaterial = materials[(int)Mathf.Ceil(timeLeft) - 1];
                }
                
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
        float force = 2f;

        Transform target = col.gameObject.GetComponentInParent<Transform>();

        if (col.gameObject.tag == "ball" && transform.parent != null) //first ball hit
        {
            boxBody.isKinematic = false;
            beenHit = true;
            //Debug.Log(col.gameObject.name);
            transform.parent = null;
            Vector3 dir = new Vector3(0, Random.Range(0f,1f), -1);
            boxBody.useGravity = true;
            boxBody.AddForce(dir * flyDistance, ForceMode.VelocityChange);
        }
        else if ((col.gameObject.tag == "ball" || col.gameObject.tag == "Player") && boxBody.useGravity == true) //second ball hit or touches player
        {
            boxBody.AddForce(Vector3.down * force, ForceMode.Impulse);
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
