using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MovingLamp : MonoBehaviour
{
    public float rotationTreshold;
    public float speed;
    public float maxOffSet = 0.2f;
    [SerializeField]
    Quaternion maxLeft;
    [SerializeField]
    Quaternion maxRight;
    Coroutine currentCoroutine;
    private Light2D colorLight;


    // Start is called before the first frame update
    void Start()
    {
        colorLight = gameObject.GetComponent<Light2D>();

        maxLeft.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + rotationTreshold);
        maxRight.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + rotationTreshold * -1);
        currentCoroutine = StartCoroutine(MoveLeft());
    }

    // Update is called once per frame
    void Update()
    {
        colorLight.color = Color.Lerp(colorLight.color, Color.blue, Mathf.PingPong(Time.time, 0.050f));
    }

    IEnumerator MoveLeft()
    {
        while(transform.localEulerAngles.z > maxLeft.eulerAngles.z + maxOffSet)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, maxLeft, Time.deltaTime * speed);
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);
        StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(MoveRight());
    }

    IEnumerator MoveRight()
    {
        while (transform.localEulerAngles.z < maxRight.eulerAngles.z - maxOffSet)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, maxRight, Time.deltaTime * speed);
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);
        StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(MoveLeft());
    }
    
}
