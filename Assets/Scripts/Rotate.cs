using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;
    public Vector3 direction;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(Random.Range(0,100), Random.Range(0, 100), Random.Range(0, 100)) * Random.Range(0, 10) * Time.deltaTime);
    }
}
