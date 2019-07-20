using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InevntoryTransform : MonoBehaviour
{
    public Transform player;
    public Transform[] positions;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
    }

    public void UpdateTransform(int index)
    {
        transform.LookAt(player);
        transform.position = positions[index].position;
    }
}
