using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LucesLed : MonoBehaviour
{
    public Light2D led;
    private float timerChangeColor;
    private float timerCurrentColor;
    // Start is called before the first frame update
    void Start()
    {
        timerChangeColor = 1.0f;
        timerCurrentColor = timerChangeColor;
    }

    // Update is called once per frame
    void Update()
    {
        timerCurrentColor -= Time.deltaTime;
        if(timerCurrentColor < 0)
        {
            Color RandomColor = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255),255);
            Debug.Log(RandomColor); 
            led.color = RandomColor;
            timerCurrentColor = timerChangeColor;
        }
    }
}
