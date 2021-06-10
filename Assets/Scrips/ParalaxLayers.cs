using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ParalaxLayers : MonoBehaviour
{
    public float parallaxFactorX;
    public float parallaxFactorY;

    public void MoveX(float deltaX)
    {
        Vector3 newPosition = transform.position;
        newPosition.x -= deltaX * parallaxFactorX;
        transform.position = newPosition;
    }

    public void MoveY(float deltaY)
    {
        Vector3 newPosition = transform.position;
        newPosition.y -= deltaY * parallaxFactorY;
        transform.position = newPosition;
    }
}
