using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float obstacleSpeed;
    Rigidbody rb;

// Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
  
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.position += Vector3.back*Time.deltaTime*obstacleSpeed;
    }
   
}
