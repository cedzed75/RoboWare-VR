using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Minigame : MonoBehaviour
{
    public Transform[] spawnArray;
    public GameObject spotlightObject;
    public GameObject microphoneObject;

    public float MinigameLength = 10f;
    bool gameOver = false;

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


        //kO.GetComponent<Transform>().position = knifeArray[spawnPos].transform.position + new Vector3(0f, 0f, 0f);

        //Debug.Log(spawnPos);

        //Round Timer
        //KnifeCutter.WinConditionEvent += GameWin;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
