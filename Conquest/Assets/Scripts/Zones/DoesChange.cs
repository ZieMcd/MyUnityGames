using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoesChange : MonoBehaviour
{
    ZoneCapture parentZone;
    public GameObject friendBuilding;
    
    void Start()
    {
        parentZone = GetComponentInParent<ZoneCapture>();
        parentZone.ZoneCaptured += OnChange;
    }
    void OnChange()
    {
        Instantiate(friendBuilding, new Vector3(0,0,0), transform.rotation, transform);
        //Destroy(this);
        //Instantiate(friendBuilding,new Vector3(0,0,0));
        Debug.Log("ZoneCaptured");
        
    } 
}
