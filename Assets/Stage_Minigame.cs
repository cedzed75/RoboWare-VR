using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage_Minigame : MonoBehaviour
{
    public Transform[] spawnArray;
    public GameObject spotlightObject;
    public GameObject spotlightInstance;
    public GameObject microphoneObject;

    public float MinigameLength = 25f;
    float cooldownLength = 5f;
    float prefTimer = 0f;
    public bool playerHasMic = false;

    bool timeExpired = false;
    bool position = false;
    bool gameWon = false;
    public Text timerTxt;
    public Text descTxt;
    public Text lifeTxt;

    public Vector3 lightVel;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("attempts", PlayerPrefs.GetInt("attempts") + 1);
        int spawnPos, spawnPos2;
        while (true)
        {
            spawnPos = UnityEngine.Random.Range(0, 12);
            spawnPos2 = UnityEngine.Random.Range(0, 12);

            if (spawnPos != spawnPos2) break;
        }

        spotlightInstance = Instantiate(spotlightObject, spawnArray[spawnPos].position, Quaternion.identity);
        Instantiate(microphoneObject, spawnArray[spawnPos2].position, Quaternion.identity);

        //Instantiate(microphoneObject, spawnArray[spawnPos2]);

        lifeTxt.text = $"Lives: <color='yellow'> {PlayerPrefs.GetInt("lives")} </color>";


        //Round Timer
        grabChecker.WinConditionEvent += GameWin;
        SpotlightCollision.PositionCorrectEvent += PositionCorrect;
        SpotlightCollision.PositionWrongEvent += PositionWrong;
        spotlightInstance.GetComponent<Rigidbody>().WakeUp();

        lightVel = new Vector3(1f, 0f, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        prefTimer += Time.deltaTime;
        if (spotlightInstance.transform.position.x >= 4.5) //left bound
        {
            lightVel = new Vector3(-1, lightVel.y, lightVel.z);
        }
        else if (spotlightInstance.transform.position.x <= -8.5) //right bound
        {
            lightVel = new Vector3(1, lightVel.y, lightVel.z);
        }
        else if (spotlightInstance.transform.position.z <= -1.5) //top bound
        {
            lightVel = new Vector3(lightVel.x, lightVel.y, 1);
        }
        else if (spotlightInstance.transform.position.z >= .5) //bot bound
        {
            lightVel = new Vector3(lightVel.x, lightVel.y, -1);
        }
        spotlightInstance.GetComponent<Rigidbody>().velocity = lightVel;    

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

        if (PlayerPrefs.GetFloat("fastest") == 0f) PlayerPrefs.SetFloat("fastest", prefTimer);
        if (PlayerPrefs.GetFloat("slowest") == 0f) PlayerPrefs.SetFloat("slowest", prefTimer);

        if (prefTimer <= PlayerPrefs.GetFloat("fastest")) PlayerPrefs.SetFloat("fastest", prefTimer);
        if (prefTimer >= PlayerPrefs.GetFloat("slowest")) PlayerPrefs.SetFloat("slowest", prefTimer);


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

