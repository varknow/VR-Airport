using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveInventori : MonoBehaviour
{
    public GameObject follow;
    private Vector3 firestAxis;
    private Quaternion firestAngel;
    // Start is called before the first frame update
    void Start()
    {
        firestAxis = this.gameObject.transform.position;
        firestAngel = this.gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
