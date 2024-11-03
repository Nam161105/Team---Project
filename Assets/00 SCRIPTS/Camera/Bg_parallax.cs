using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg_parallax : MonoBehaviour
{
    private float startPos, leght;
    public GameObject cam;
    public float parallaxE;
    void Start()
    {
        startPos = transform.position.x;
        leght = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    private void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxE;
        float movent = cam.transform.position.x * (1 - parallaxE);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
        if(movent > startPos + leght)
        {
            startPos += leght;
        }
        else if(movent < startPos - leght)
            { startPos -= leght; }
    }
}
