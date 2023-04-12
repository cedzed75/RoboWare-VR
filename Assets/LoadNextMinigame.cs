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
    public GameObject player;
    void Start()
    {
        nextMinigame = UnityEngine.Random.Range(0, 2);
        Debug.Log("Minigame index generated");
        IsPlayerEligible();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd)
        { 
            //Load game end scene;
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (nextMinigame == 0)
            {
                SceneManager.LoadScene("KitchenScene");
                Debug.Log("Kitchen scene chosen, failed to load");
            }
            else if (nextMinigame == 1)
            {
                //load theatre
                SceneManager.LoadScene("TheatreScene");
                Debug.Log("Theatre scene chosen, failed to load");
            }
        }
    }

    void IsPlayerEligible()
    {
        //check if player has lives left, if not, display fail message. if so, ignore and continue;
        if (PlayerPrefs.GetInt("lives") == 0)
        {
            gameEnd = true;
        }

    }
}
