using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelColor : MonoBehaviour
{

    public float speed = 1.0f;
    public Color startColor;
    public Color endColor;
    float startTime;
    public Image image;
    public float currentImageColorAlpha = 1f;
    public bool repeat = false;

    void Start()
    {
        image = GetComponent<Image>();
        //Get the alpha value of Color
        //currentImageColorAlpha = image.color.a;
        //Assign Color
        //image.color = startColor;
    }


    void Update()
    {
        if(!repeat)
        {
            float t = (Time.time - startTime) * speed;
            image.color = Color.Lerp(startColor, endColor, t);
        }
        else
        {
            float t =(Mathf.Sin(Time.time - startTime) * speed);
            image.color = Color.Lerp(startColor, endColor, t);
        }

    }
}
