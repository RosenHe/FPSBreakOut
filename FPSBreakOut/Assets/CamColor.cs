using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamColor : MonoBehaviour
{
    public float speed =.1f;
    public Color[] ColorSet;
    private Color startColor;
    private Color endColor;
    float startTime;
    private Camera cam;
    public float currentImageColorAlpha = 1f;
    public bool repeat = false;

    void Start()
    {
        startTime = Time.time;
        cam = GetComponent<Camera>();
        cam.backgroundColor = ColorSet[1];
        startColor = cam.backgroundColor;
        endColor = ColorSet[Random.Range(0, ColorSet.Length)]; //chose random color
    }

    public float t;
    void Update()
    {
        t = (Mathf.Sin(Time.time - startTime) * speed);
        cam.backgroundColor = Color.Lerp(startColor, endColor, t);

        if (Mathf.Approximately(cam.backgroundColor.grayscale, endColor.grayscale))
        {
            ExecuteAfterTime(2);
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        startColor = cam.backgroundColor;
        endColor = ColorSet[Random.Range(0, ColorSet.Length)]; //chose random color
        // Code to execute after the delay
    }
}
