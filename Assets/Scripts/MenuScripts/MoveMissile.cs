using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMissile : MonoBehaviour
{
    public float myAngle;

    // Start is called before the first frame update
    void Start()
    {
        myAngle = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * myAngle * Time.deltaTime);
    }
}
