using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSwitcher : MonoBehaviour
{
    public GameObject firstObject;
    public GameObject secondObject;
    public float switchDelay = 5f;

    private bool switchTriggered = false;

    private void Start()
    {
        // Enable the first object and disable the second object at the beginning
        firstObject.SetActive(true);
        secondObject.SetActive(false);
    }

    private void Update()
    {
        // Check if the switch hasn't been triggered yet and the delay has passed
        if (!switchTriggered && Time.time >= switchDelay)
        {
            // Enable the second object and disable the first object
            firstObject.SetActive(false);
            secondObject.SetActive(true);

            switchTriggered = true; // Set the switch as triggered
        }
    }
}
