using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManger : MonoBehaviour
{
    public static PlayerManger instance;
    void Awake() 
    {
        instance = this;
    }

    public GameObject player;

    
}
