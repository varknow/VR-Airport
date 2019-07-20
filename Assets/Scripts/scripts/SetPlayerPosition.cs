using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SetPlayerPosition : MonoBehaviour
{

    public Transform PlayerStartPosition;
    public string PlayerName;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find(PlayerName);
        Debug.Log(player);
        player.transform.position = PlayerStartPosition.position;
        player.transform.rotation = PlayerStartPosition.rotation;
        player.transform.localScale = PlayerStartPosition.localScale;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) )
        {
            SteamVR_LoadLevel.Begin("coffeAmir");
        }
    }

}
