using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using EzySlice;

public class KnifeCutter : MonoBehaviour
{
    public GameObject slicedTomatoPrefab;

    public static event Action WinConditionEvent;

    void OnCollisionEnter(Collision collision)
    {
        // Check for a match with the specified name on any GameObject that collides with your GameObject
        //Debug.Log("object: " + collision.gameObject.name);
        if (collision.gameObject.tag == "Cuttable" && collision.gameObject != null) {
            Debug.Log("object: " + collision.gameObject.name);
            // If the GameObject's tag matches the one you suggest, output this message in the console

            WinConditionEvent?.Invoke();

            GameObject thisGuy = gameObject;
            if (collision.gameObject.name == "Tomato") {
                Instantiate(slicedTomatoPrefab, collision.transform.position, Quaternion.identity);
                Instantiate(slicedTomatoPrefab, collision.transform.position, Quaternion.identity);
                Instantiate(slicedTomatoPrefab, collision.transform.position, Quaternion.identity);
            }
            Destroy(collision.gameObject);
        }
    }
}
