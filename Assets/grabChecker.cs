using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Linq;
using System;

public class grabChecker : MonoBehaviour
{
    public XRRayInteractor rHand;
    public XRRayInteractor lHand;
    public static event Action WinConditionEvent;

    void Start()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("GameController");
        rHand = go[1].GetComponent<XRRayInteractor>();
        lHand = go[0].GetComponent<XRRayInteractor>();
    }
    // Update is called once per frame
    void Update()
    {
        if (rHand.hasSelection || lHand.hasSelection)
        {
            WinConditionEvent?.Invoke();
            Debug.Log("Selection Occuring");
        }
            
    }
}
