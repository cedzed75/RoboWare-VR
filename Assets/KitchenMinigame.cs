using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenMinigame : MonoBehaviour
{
    public Transform[] knifeArray;
    public GameObject knifeObject;
    // Start is called before the first frame update
    void Start()
    {
        int spawnPos = Random.Range(0, 15);
        GameObject kO = Instantiate(knifeObject, knifeArray[spawnPos]);
        kO.GetComponent<Transform>().position = knifeArray[spawnPos].transform.position + new Vector3(0f, 0f, 0f);
        
        Debug.Log(spawnPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
