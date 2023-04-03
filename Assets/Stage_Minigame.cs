using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage_Minigame : MonoBehaviour
{
    public Transform[] spawnArray;
    public GameObject spotlightObject;
    public GameObject microphoneObject;

    public float MinigameLength = 25f;
    public bool playerHasMic = false;

    bool timeExpired = false;
    bool position = false;
    public Text timerTxt;
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

        //Debug.Log(spawnPos);

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
            Debug.Log("Time OVER");
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
        if(!position)
        {
            return;
        }
        Debug.Log("YOU WIN");
        timeExpired = true;
    }

    void PositionCorrect()
    {
        position = true;
        Debug.Log("Position is right");
    }

    void PositionWrong()
    {
        position = false;
        Debug.Log("Position is WRONG");
    }
}

