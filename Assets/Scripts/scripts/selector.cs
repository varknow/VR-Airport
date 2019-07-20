using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selector : MonoBehaviour
{
    public bool go1;
    public bool go2;
    public bool go3;
    GameObject imo1;
    GameObject imo2;
    GameObject imo3;
    // Start is called before the first frame update
    void Start()
    {
        imo1 = GameObject.Find("imageObject1");
        imo2 = GameObject.Find("imageObject2");
        imo3 = GameObject.Find("imageObject3");
    }

    // Update is called once per frame
    void Update()
    {
        select();
    }

    private void select()
    {
        if (go1)
        {
            destruction.isHit = true;
            destruction.imageObject = imo1;
            go1 = false;
        }
        else if (go2)
        {
            destruction.isHit = true;
            destruction.imageObject = imo2;
            go2 = false;
        }
        else if (go3)
        {
            destruction.isHit = true;
            destruction.imageObject = imo3;
            go3 = false;
        }
    }

    public void set1()
    {
        go1 = true;
    }
    public void set2()
    {
        go2 = true;
    }
    public void set3()
    {
        go3 = true;
    }
}
