using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWorkPls : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ALERT");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ALERT");

    }
}
