using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoriInstanciate : MonoBehaviour
{
   public Transform spawnPoint;
    public GameObject inventoriPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {

            Debug.Log("K");
            GameObject inventori = Instantiate(inventoriPrefab, spawnPoint.position, spawnPoint.rotation);


        }
    }
}
