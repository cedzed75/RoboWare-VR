using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextMinigame : MonoBehaviour
{
    // Start is called before the first frame update
    int nextMinigame;
    float timer = 10f;
    bool gameEnd = false;
    void Start()
    {
        nextMinigame = UnityEngine.Random.Range(0, 2);
        Debug.Log("Minigame index generated");
    }

    // Update is called once per frame
    void Update()
    {
        IsPlayerEligible();
        if (gameEnd)
        {
            SceneManager.LoadScene("EndingRoom");
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (nextMinigame == 0)
            {
                SceneManager.LoadScene("KitchenScene");
            }
            else if (nextMinigame == 1)
            {
                //load theatre
                SceneManager.LoadScene("TheatreScene");
            }
        }
    }

    void IsPlayerEligible()
    {
        if (PlayerPrefs.GetInt("lives") <= -1)
        {
            gameEnd = true;
        }

    }
}
