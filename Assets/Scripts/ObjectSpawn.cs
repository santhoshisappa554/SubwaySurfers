using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    Rigidbody tempRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        tempRigidbody = GetComponent<Rigidbody>();
       // ObjectPooling.Instance.SpawnTile();
        //StartCoroutine("FallDown");

    }

    // Update is called once per frame
    void Update()
    {
        
       // Debug.Log(tempRigidbody.gameObject.name);
    }

     private void OnTriggerEnter(Collider other)
     {
       
         if (other.tag == "Player")
         {

             ObjectPooling.Instance.SpawnTile();
             StartCoroutine("FallDown");

             Debug.Log("Triggered");


         }
     }
    IEnumerator FallDown()
    {
        yield return new WaitForSeconds(3);
        tempRigidbody.isKinematic = false;
        yield return new WaitForSeconds(1);
        tempRigidbody.isKinematic = true;
        if (tempRigidbody.gameObject.name == "Object1")
        {

            ObjectPooling.Instance.AddObjectpool1(tempRigidbody.gameObject);
            //Debug.Log("Added to forward pool");
        }
        else if (tempRigidbody.gameObject.name == "Object2")
        {

            ObjectPooling.Instance.AddObjectpool2(tempRigidbody.gameObject);
            //Debug.Log("Added to left pool");
        }
      
    }
}
