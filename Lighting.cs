using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{

    public float lightIntensity = 1.5f;
    private int lightsOn;
    float duration = 1.0f;
    Color color0 = Color.red;
    Color color1 = Color.blue;

    Light lt;

    void Start()
    {
        lt = GetComponent<Light>();
        lightsOn = 0;
    }

    
    void Update()
    {
        if (lightsOn >= 1)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            lt.color = Color.Lerp(color0, color1, t);
            lt.intensity = lightIntensity;
        }
    }

    public void UpdateLights(int activateLights)
    {
        lightsOn += activateLights;
    }
}
