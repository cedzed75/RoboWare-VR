using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class KitchenMinigame : MonoBehaviour
{
    public Transform[] knifeArray;
    public GameObject knifeObject;

    public float MinigameLength = 10f;
    bool gameOver = false;

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
        MinigameLength -= Time.deltaTime;

        if (MinigameLength <= 0.0f)
        {
            gameOver = true;
            Debug.Log("GAME OVER");
        }
    }

    void GameWin()
    {
        if (gameOver)
            return;
        Debug.Log("YOU WIN");
        MinigameLength = float.MaxValue;

    }
}
