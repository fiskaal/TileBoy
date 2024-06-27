using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursor : MonoBehaviour
{
    private bool cursorHidden = false;
    private float idleTimer = 0f;
    private const float idleTimeThreshold = 2f;

    private void Start()
    {
        // Set the cursor visibility to true initially
        Cursor.visible = true;
        cursorHidden = false;
    }

    private void Update()
    {
        // Check if the mouse is moving
        if (Input.GetAxis("Mouse X") != 0f || Input.GetAxis("Mouse Y") != 0f)
        {
            // Reset the idle timer if the mouse is moving
            idleTimer = 0f;

            // Show the cursor if it was hidden
            if (cursorHidden)
            {
                Cursor.visible = true;
                cursorHidden = false;
            }
        }
        else
        {
            // Increment the idle timer
            idleTimer += Time.deltaTime;

            // Hide the cursor if the idle timer exceeds the threshold
            if (idleTimer >= idleTimeThreshold && !cursorHidden)
            {
                Cursor.visible = false;
                cursorHidden = true;
            }
        }
    }
}
