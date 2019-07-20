using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour
{

    private List<GameObject> gameObjects;
    public List<GameObject> itemsList;
    public int maxNumber;
    private Item[] panes;

    void Start()
    {
        gameObjects = new List<GameObject>();
        panes = GetComponentsInChildren<Item>();
        for (int i = 0; i < maxNumber; i++)
        {
//            Debug.Log("name"+panes[i].gameObject.name);
            GameObject newObj = Instantiate(itemsList[i]);
            newObj.transform.SetParent(panes[i].transform);
            newObj.transform.position = panes[i].transform.position;
            // newObj.transform.rotation = panes[i].transform.rotation;
            //  newObj.GetComponent<Collider>().isTrigger = true;
            gameObjects.Add(newObj);
          
        }
        updatePosition();
    }

    public void updatePosition()
    {
        for (int i = 0; i < maxNumber; i++)
        {
            gameObjects[i].GetComponent<Collider>().isTrigger = true;
            gameObjects[i].transform.position = panes[i].transform.position;
           // gameObjects[i].transform.rotation = panes[i].transform.rotation;
            gameObjects[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }

    public void add(GameObject gameObject)
    {
        //Instantiate(gameObject);
        gameObject.transform.SetParent(this.gameObject.transform);
        gameObject.transform.position = panes[maxNumber].transform.position;
        gameObject.transform.rotation = panes[maxNumber].transform.rotation;
        gameObject.transform.SetParent(panes[maxNumber].transform);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        gameObject.transform.SetParent(this.gameObject.transform);
        gameObjects.Add(gameObject);
        Debug.Log(maxNumber);
        maxNumber++;
        updatePosition();
    }

    public void remove(GameObject game)
    {
        Debug.Log("remove");
        Debug.Log(gameObjects.Remove(game));
        maxNumber--;
        updatePosition();
    }
}