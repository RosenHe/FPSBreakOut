using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float destroyTime = 5;

    void Start()
    {
        //trigger ball popping animation after a time delay
        PopBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "box")
        {
            //Debug.Log(col.gameObject.name);
            PopBall(true);
        }
    }

    //destroys ball after a set time or collision with boxes
    void PopBall(bool PopNow=false)
    {
        if (PopNow)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, destroyTime);
        }

    }
}
