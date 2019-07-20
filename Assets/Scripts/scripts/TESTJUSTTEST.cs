using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTJUSTTEST : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(lalala());
    }

    private void OnEnable()
    {
        StartCoroutine(lalala());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator lalala()
    {
        Debug.Log("Coroutine started");

        yield return  new WaitForSeconds(1f);
        Debug.Log("just satarted at one second");
    }
}
