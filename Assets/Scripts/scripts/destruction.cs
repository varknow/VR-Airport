using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destruction : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject level;
    Text imageTxt;
    GameObject[] allImgs;
    public static GameObject imageObject;
    public static bool isHit;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            hit();
        }
    }
    
    public void hit()
    {
        Debug.Log("selector mige kudum");
        barkhord();
        StartCoroutine(WaintAndGoNextLevel());
        isHit = false;
    }
    private IEnumerator WaintAndGoNextLevel()
    {

        //Debug.Log("ghable wait");
        yield return new WaitForSeconds(1.0f);
        //Debug.Log("bade wait");
        levelManager.nxtLevel = true;
        wordsHandler.nxtWord = true;

    }

    private bool isCorrect(string selected)
    {
        return wordsHandler.curWord == selected;
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("collision " + collision.gameObject.name);
        GameObject imageObj = collision.gameObject;
        imageTxt = imageObj.GetComponentInChildren<Text>();
        Debug.Log("collision on : text : "+ imageTxt.text);
        SpriteRenderer selectedImg = imageObj.GetComponentInChildren<SpriteRenderer>();
        imageTxt.enabled = true;
        if (isCorrect(selectedImg.name))
        {

            imageTxt.material.color = Color.green;
        }
        else imageTxt.material.color = Color.red;
        System.Threading.Thread.Sleep(300);
        imageTxt.enabled = false;

        // Debug.Log(imageObj.transform.GetChild(1).gameObject.name);

        levelManager.nxtLevel = true;

        var bullet = Instantiate(ball); //new ball in position
        bullet.transform.position = SpawnPoint.position;
        bullet.transform.rotation = SpawnPoint.rotation;
        //Destroy(this.gameObject); //destroy ball
    }*/
    private void barkhord()
    {
        imageTxt = imageObject.GetComponentInChildren<Text>();
        //Debug.Log("name : "+ imageTxt.text);
        SpriteRenderer selectedImg = imageObject.GetComponentInChildren<SpriteRenderer>();
        
        if (isCorrect(imageTxt.text))
        {
            imageTxt.color = Color.green;
        }
        else {
            
            imageTxt.color = Color.red;
            showCorrectAnswer();
            //imageTxt.color = Color.clear;
        }
    }
    public void showCorrectAnswer()
    {
        foreach (Text txt in level.GetComponentsInChildren<Text>())
        {
            //Debug.Log("each text : " + txt.text);
            if (isCorrect(txt.text))
            {
                txt.color = Color.green;
            }
        }
    }

}

