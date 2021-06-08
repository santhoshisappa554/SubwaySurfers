using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject[] objects;

    public GameObject Object1;
    //public GameObject Object2;

    Stack<GameObject> Objectpool1 = new Stack<GameObject>();//created stack
    Stack<GameObject> Objectpool2 = new Stack<GameObject>();
   
    private static ObjectPooling instance;

    public static ObjectPooling Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<ObjectPooling>();
            }
            return instance;
        }

    }

    // Start is called before the first frame update
    void Start()
    {

        // CreateTiles(5);


    }

    // Update is called once per frame
    void Update()
    {

    }
    void CreateObjects(int value)//to create the pool of tiles
    {
        for (int i = 0; i < value; i++)
        {
            Objectpool1.Push(Instantiate(objects[0]));
            Objectpool2.Push(Instantiate(objects[1]));
           
            Objectpool1.Peek().SetActive(false);
            Objectpool2.Peek().SetActive(false);
            

            Objectpool1.Peek().name = "Object1";
            Objectpool2.Peek().name = "Object2";
          
        }

    }
    public void AddObjectpool1(GameObject tempObj)
    {
        Objectpool1.Push(tempObj);
        Objectpool1.Peek().SetActive(false);
    }
    public void AddObjectpool2(GameObject tempObj)
    {
        Objectpool2.Push(tempObj);
        Objectpool2.Peek().SetActive(false);
    }
   

    public void SpawnTile()
    {
        if (Objectpool1.Count == 0 || Objectpool2.Count == 0 )
        {
            CreateObjects(10);
        }
        int index = Random.Range(0, 2);
        if (index == 0)
        {
            GameObject tempTile = Objectpool1.Pop();
            tempTile.SetActive(true);
            tempTile.transform.position = Object1.transform.GetChild(6).position;
            Object1 = tempTile;
        }
        else if (index == 1)
        {
            GameObject temp = Objectpool2.Pop();
            temp.SetActive(true);
            temp.transform.position = Object1.transform.GetChild(6).position;
            Object1 = temp;
        }
       
    }
}
