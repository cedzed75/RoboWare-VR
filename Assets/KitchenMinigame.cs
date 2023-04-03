using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System;

public class KitchenMinigame : MonoBehaviour
{
    public Transform[] knifeArray;
    public GameObject knifeObject;

    public float MinigameLength = 10f;
    bool timeExpired = false;


    public Text timerTxt;
    public Text descTxt;

    // Start is called before the first frame update
    void Start()
    {
        int spawnPos = UnityEngine.Random.Range(0, 15);
        GameObject kO = Instantiate(knifeObject, knifeArray[spawnPos]);
        kO.GetComponent<Transform>().position = knifeArray[spawnPos].transform.position + new Vector3(0f, 0f, 0f);
        
        Debug.Log(spawnPos);

        //Round Timer
        KnifeCutter.WinConditionEvent += GameWin;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeExpired) { MinigameLength -= Time.deltaTime; }

        if (MinigameLength <= 0.0f)
        {
            timerTxt.text = "TIME OVER";
            timeExpired = true;
            GameLose();
        }
        else
        {
            timerTxt.text = "Timer: <color='yellow'>" + (int)MinigameLength + "</color>";
        }
    }

    void GameWin()
    {
        if (timeExpired)
            return;
        Debug.Log("YOU WIN");
        timeExpired = true;
        descTxt.text = "<color='green'>YOU WIN!!!</color>";
    }

    void GameLose()
    { 

    }
}
