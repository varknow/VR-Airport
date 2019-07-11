using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour
{

    public float m_DefaultLength = 5.0f;
    public GameObject m_Dot;
    private LineRenderer m_LineRenderer = null;
    public VRInputModule m_InputModule;

    private void Awake()
    {
        m_LineRenderer = GetComponent<LineRenderer>();
    }


    void Update()
    {
        //Use default distance
        PointerEventData data = m_InputModule.GetData();
        float targetLength = data.pointerCurrentRaycast.distance == 0 ? m_DefaultLength : data.pointerCurrentRaycast.distance;

        //Raycast
        RaycastHit hit = CreateRaycast(targetLength);

        //Default
        Vector3 endposition = transform.position + (transform.forward * targetLength);

        //Or based on hit
        if (hit.collider == null)
        {
            endposition = hit.point;
        }

        //set position of the dot
        m_Dot.transform.position = endposition;

        //Set linerenderer
        m_LineRenderer.SetPosition(0, transform.position);
        m_LineRenderer.SetPosition(1, transform.position);
    }

    private RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, m_DefaultLength);

        return hit;
    }
}
