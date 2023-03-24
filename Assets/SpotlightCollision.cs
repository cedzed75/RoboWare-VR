using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightCollision : MonoBehaviour
{
    public static event Action PositionCorrectEvent;
    public static event Action PositionWrongEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpotLight"))
        {
            PositionCorrectEvent?.Invoke();
            Debug.Log("Player In Correct Boundary");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SpotLight"))
        {
            PositionWrongEvent?.Invoke();
            Debug.Log("Player In Wrong Boundary");
        }
    }
}
