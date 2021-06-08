using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera camfollow;
    public float camOffsetZ;
    public PlayerMovement  player;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    public void Update()
    {
        if (player != null)
        {
           
            camfollow.transform.position = new Vector3(player.transform.position.x, camfollow.transform.position.y, camfollow.transform.position.z);
        }
    }
    
   
}
