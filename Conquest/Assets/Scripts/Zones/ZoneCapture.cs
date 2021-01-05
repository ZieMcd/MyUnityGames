using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public delegate void Captured();
public class ZoneCapture : MonoBehaviour
{
    private bool playerInZone = false;
    public float timerLeftTocapture = 10f;
    public event Captured ZoneCaptured;
    bool captured = false;

    void Update()
    {   
        Capturing();
    }
    private void OnTriggerEnter(Collider other) 
    {       
        if (other.tag == "Player")  
        {
            playerInZone = true;
        }
    }
    private void OnTriggerExit(Collider other) 
    {   
        if (other.tag == "Player")
        {
            playerInZone = false;
        }
    }
    void Capturing()
    {
        if (playerInZone && timerLeftTocapture>0)
        {
            timerLeftTocapture -= 1 * Time.deltaTime;
        }

        if(timerLeftTocapture <= 0)
        {
            OnZoneCaptured();
        }
    }

    void OnZoneCaptured()
    {
        if (!captured)
        {
            captured = true;
            if (ZoneCaptured != null)
            {
                ZoneCaptured();
                Debug.Log("Rasied event");
            }
        }

    }
}
