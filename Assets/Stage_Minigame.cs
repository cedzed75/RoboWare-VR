using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage_Minigame : MonoBehaviour
{
    public Transform[] spawnArray;
    public GameObject spotlightObject;
    public GameObject microphoneObject;

    public float MinigameLength = 25f;
    float cooldownLength = 5f;
    public bool playerHasMic = false;

    bool timeExpired = false;
    bool position = false;
    bool gameWon = false;
    public Text timerTxt;
    public Text descTxt;
    public Text lifeTxt;

    // Start is called before the first frame update
    void Start()
    {
        int spawnPos, spawnPos2;
        while (true)
        {
            spawnPos = UnityEngine.Random.Range(0, 12);
            spawnPos2 = UnityEngine.Random.Range(0, 12);

            if (spawnPos != spawnPos2) break;
        }
            
        Instantiate(spotlightObject, spawnArray[spawnPos]);
        Instantiate(microphoneObject, spawnArray[spawnPos2]);

        Debug.Log(spawnPos);
        Debug.Log(spawnPos2);

        lifeTxt.text = $"Lives: {PlayerPrefs.GetInt("lives")}";


        //Round Timer
        grabChecker.WinConditionEvent += GameWin;
        SpotlightCollision.PositionCorrectEvent += PositionCorrect;
        SpotlightCollision.PositionWrongEvent += PositionWrong;

    }

    // Update is called once per frame
    void Update()
    {

        if (!timeExpired)
        {
            MinigameLength -= Time.deltaTime;
        }
        
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

        if(cooldownLength <= 0.0f)
        {
            if(!gameWon) PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") - 1);
            SceneManager.LoadScene("WaitingRoom");
        }
    }

    void GameWin()
    {
        if (timeExpired)
            return;
        if(!position)
        {
            return;
        }
        MinigameLength = 0f;
        descTxt.text = "<color='green'>YOU WIN!!!</color>";
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 1);
        timeExpired = true;
        gameWon = true;
    }

    void PositionCorrect()
    {
        position = true;
    }

    void PositionWrong()
    {
        position = false;
    }
}

