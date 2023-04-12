using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using System;

public class KitchenMinigame : MonoBehaviour
{
    public Transform[] knifeArray;
    public GameObject knifeObject;

    public float MinigameLength = 10f;
    float cooldownLength = 5f;
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
            cooldownLength -= Time.deltaTime;
        }
        else
        {
            timerTxt.text = "Timer: <color='yellow'>" + (int)MinigameLength + "</color>";
        }

        if (cooldownLength <= 0.0f)
        {
            if (timeExpired) PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") - 1);
            SceneManager.LoadScene("WaitingRoom");
        }
    }

    void GameWin()
    {
        if (timeExpired)
            return;
        Debug.Log("YOU WIN");
        timeExpired = true;
        MinigameLength = 0f;
        descTxt.text = "<color='green'>YOU WIN!!!</color>";
    }

}
