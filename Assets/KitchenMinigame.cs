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
    float prefTimer;
    bool timeExpired = false;
    bool gameWon = false;

    public Text timerTxt;
    public Text descTxt;
    public Text lifeTxt;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("attempts", PlayerPrefs.GetInt("attempts") + 1);
        int spawnPos = UnityEngine.Random.Range(0, 15);
        GameObject kO = Instantiate(knifeObject, knifeArray[spawnPos]);
        kO.GetComponent<Transform>().position = knifeArray[spawnPos].transform.position + new Vector3(0f, 0f, 0f);

        lifeTxt.text = $"Lives: <color='yellow'> {PlayerPrefs.GetInt("lives")}</color>";


        //Round Timer
        KnifeCutter.WinConditionEvent += GameWin;
    }

    // Update is called once per frame
    void Update()
    {
        prefTimer += Time.deltaTime;

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
            if (!gameWon) PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") - 1);
            SceneManager.LoadScene("WaitingRoom");
        }
    }

    void GameWin()
    {
        if (timeExpired)
            return;
        gameWon = true;
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 1);

        if (PlayerPrefs.GetFloat("fastest") == 0f) PlayerPrefs.SetFloat("fastest", prefTimer);
        if (PlayerPrefs.GetFloat("slowest") == 0f) PlayerPrefs.SetFloat("slowest", prefTimer);

        if (prefTimer <= PlayerPrefs.GetFloat("fastest")) PlayerPrefs.SetFloat("fastest", prefTimer);
        if (prefTimer >= PlayerPrefs.GetFloat("slowest")) PlayerPrefs.SetFloat("slowest", prefTimer);

        timeExpired = true;
        MinigameLength = 0f;
        descTxt.text = "<color='green'>YOU WIN!!!</color>";
    }

}
