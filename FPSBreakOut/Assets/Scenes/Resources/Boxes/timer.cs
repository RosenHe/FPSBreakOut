using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    float currentTime;
    float startingTime = 10f;
    private Text textTimer;
    private Rigidbody boxBody;

    private void Start()
    {
        textTimer = GameObject.Find("countDownText").GetComponent<Text>();
        currentTime = startingTime; //set box timer
    }

    private void Awake()
    {
        boxBody = GetComponent<Rigidbody>();
    }
    [SerializeField] private Text countDownText;

    private void Update()
    {
        boxDisappear();
    }

    IEnumerable boxDisappear()
    {
        yield return new WaitForSeconds(2);//wait x amount of seconds
        Debug.Log("dying");
        Destroy(gameObject);
    }
}
    

