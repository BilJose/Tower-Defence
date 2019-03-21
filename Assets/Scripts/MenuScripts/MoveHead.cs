using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHead : MonoBehaviour
{
    public float myAngle;


    // Start is called before the first frame update
    void Start()
    {
        myAngle = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * myAngle * Time.deltaTime);
    }
}
