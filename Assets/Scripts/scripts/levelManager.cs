using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelManager : MonoBehaviour
{
    public static int levelCntr = 0;
    private int eachLevelImageNum;
    public GameObject level;
    public Sprite[] images;
    public static bool nxtLevel = true;
    int cbbbb = 0;
    Text imageTxt;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("nxtLevel: " + nxtLevel);

        if (nxtLevel)
        {
            nxtLevel = false;
            cbbbb += 1;
            levelCntr += 1;
            this.gameObject.name = "level" + levelCntr;
            SpriteRenderer[] rs = level.GetComponentsInChildren<SpriteRenderer>();
            eachLevelImageNum = rs.Length;
            for (int i = 0; i < rs.Length; i++)
            {
                rs[i].sprite = images[(levelCntr - 1) * rs.Length + i];
                GameObject parent = rs[i].transform.parent.gameObject;
                imageTxt = parent.GetComponentInChildren<Text>();
                imageTxt.text = rs[i].sprite.name;
                Debug.Log(i+"  "+rs[i].sprite.name);

                imageTxt.color = Color.clear;
            }
            if (levelCntr == images.Length / eachLevelImageNum )
            {
                levelCntr = 0;
            }
        }

    }
}
