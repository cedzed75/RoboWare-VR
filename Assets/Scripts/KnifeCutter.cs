using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using EzySlice;

public class KnifeCutter : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject slicedApplePrefab;
    public GameObject slicedPicklePrefab;
    public GameObject slicedTomatoPrefab;
    public GameObject slicedCheesePrefab;
    public GameObject burgerBunsPrefab;

    void OnCollisionEnter(Collision collision)
    {
        // Check for a match with the specified name on any GameObject that collides with your GameObject
        //Debug.Log("object: " + collision.gameObject.name);
        if (collision.gameObject.tag == "Cuttable" && collision.gameObject != null) {
            Debug.Log("object: " + collision.gameObject.name);
            // If the GameObject's tag matches the one you suggest, output this message in the console
            Debug.Log("Do something here");
            Vector3 myVector = new Vector3(0.0f, 1.0f, 0.0f);
            GameObject thisGuy = gameObject;
            if (collision.gameObject.name == "Apple") {
                Instantiate(slicedApplePrefab, collision.transform.position, Quaternion.identity);
            } else if (collision.gameObject.name == "Pickle") {
                Instantiate(slicedPicklePrefab, collision.transform.position, Quaternion.identity);
            } else if (collision.gameObject.name == "Tomato") {
                Instantiate(slicedTomatoPrefab, collision.transform.position, Quaternion.identity);
            } else if (collision.gameObject.name == "WheelCheese") {
                Instantiate(slicedCheesePrefab, collision.transform.position, Quaternion.identity);
            } else if (collision.gameObject.name == "Bread") {
                Instantiate(burgerBunsPrefab, collision.transform.position, Quaternion.identity);
            } else {
                Instantiate(applePrefab, collision.transform.position, Quaternion.identity);
            }
            Destroy(collision.gameObject);
        }
    }
}
