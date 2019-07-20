using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class SceneLoader : MonoBehaviour
{

    public void LoadScene(String name)
    {
        SteamVR_LoadLevel.Begin(name);
    }
}
