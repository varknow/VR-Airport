using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.Newtonsoft.Json.Utilities;
using Valve.VR;

public class GameStateManager : MonoBehaviour
{

    public int[] scenes;

    private GameState LoadData()
    {
        string fileName = "VARKnowData.dat";
        try
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            return (GameState) formatter.Deserialize(fileStream);
        }
        catch (Exception e)
        {
            Debug.LogWarning(e.Message);
        }
        throw new Exception("Data Loading failed");

    }

    private void SaveData(GameState state)
    {
        string fileName = "VARKnowData.dat";
        try
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

             formatter.Serialize(fileStream, state);
        }
        catch (Exception e)
        {
            Debug.LogWarning("saving data failed");
            Debug.LogWarning(e.Message);
        }

    }

    public bool CheckLevelIsUnlocked(int sceneIndex)
    {
        var state = LoadData();

        if (state.Levels[sceneIndex])
        {
            return true;
        }

        return false;
    }

    public void UpdateUnlockedLevels(int toUnlockSceneIndex, bool reverse = false)
    {
        var state = LoadData();
        state.Levels[toUnlockSceneIndex] = !reverse;
        SaveData(state);
    }

    public void LoadLevel(int index)
    {
        SteamVR_LoadLevel.Begin("Chek_in");
    }
}