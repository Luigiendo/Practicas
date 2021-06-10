using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxCamera : MonoBehaviour
{
    public delegate void ParallaxCameraDelegate(float deltaMovement);

    public ParallaxCameraDelegate onCameraTranslateX;
    public ParallaxCameraDelegate onCameraTranslateY;

    private float oldPositionX;
    private float oldPositionY;

    private void Start()
    {
        oldPositionX = transform.position.x;
        oldPositionY = transform.position.y;
    }

    private void LateUpdate()
    {
        if(transform.position.x != oldPositionX)
        {
            if(onCameraTranslateX != null)
            {
                float deltaX = oldPositionX - transform.position.x;
                onCameraTranslateX(deltaX);
            }
            oldPositionX = transform.position.x;
        }

        if (transform.position.y != oldPositionY)
        {
            if (onCameraTranslateY != null)
            {
                float deltaY = oldPositionY - transform.position.y;
                onCameraTranslateY(deltaY);
            }
            oldPositionX = transform.position.x;
        }
    }
}
