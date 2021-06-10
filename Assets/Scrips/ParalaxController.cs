using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxController : MonoBehaviour
{
    [SerializeField]
    List<ParalaxLayers> paralaxLayersList = new List<ParalaxLayers>();
    public ParalaxCamera paralaxCamera;

    // Start is called before the first frame update
    void Start()
    {
        GetLayers();

        if (paralaxCamera == null)
            paralaxCamera = Camera.main.GetComponent<ParalaxCamera>();

        if(paralaxCamera !=null)
        {
            paralaxCamera.onCameraTranslateX += MoveX;
            paralaxCamera.onCameraTranslateY += MoveY;
        }
        
    }

    private void MoveX(float delta)
    {
        foreach (ParalaxLayers layer in paralaxLayersList)
        {
            if(layer != null)
            {
                layer.MoveX(delta);
            }
        }
    } 
    private void MoveY(float delta)
    {
        foreach (ParalaxLayers layer in paralaxLayersList)
        {
            if(layer != null)
            {
                layer.MoveY(delta);
            }
        }
    }
    private void GetLayers()
    {
        paralaxLayersList.Clear();
        for(int i = 0; i< transform.childCount; i++)
        {
            ParalaxLayers layer = transform.GetChild(i).GetComponent<ParalaxLayers>();
            if (layer != null)
                paralaxLayersList.Add(layer);
        }
    }
}
