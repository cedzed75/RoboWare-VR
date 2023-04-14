using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class StartGrabChecker : MonoBehaviour
{
    public XRRayInteractor rHand;
    public XRRayInteractor lHand;

    void Start()
    {
        //Set player prefs
        PlayerPrefs.SetInt("lives", 3);
        PlayerPrefs.SetInt("attempts", 0);
        PlayerPrefs.SetInt("score", 0);

        PlayerPrefs.SetFloat("fastest", 0f);
        PlayerPrefs.SetFloat("slowest", 0f);

        GameObject[] go = GameObject.FindGameObjectsWithTag("GameController");
        rHand = go[1].GetComponent<XRRayInteractor>();
        lHand = go[0].GetComponent<XRRayInteractor>();
    }
    // Update is called once per frame
    void Update()
    {
        if (rHand.hasSelection || lHand.hasSelection)
        {
            Debug.Log("Call function to load minigame waiting room");
            SceneManager.LoadScene("WaitingRoom");
        }

    }
}
