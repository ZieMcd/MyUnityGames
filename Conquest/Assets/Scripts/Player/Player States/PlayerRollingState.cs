using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollingState : PlayerBaseState
{
    float timeStart;
    public override void EnterState(PlayerController player)
    {
        player.Motor.Dash();
        timeStart = Time.time;
    }
    public override void Update(PlayerController player)
    {
        player.Motor.Move();
        if (Time.time >= timeStart + player.Motor.DashLength)
        {
            player.TrasitionToState(player.locomotionState);
            player.Motor.dashCoolDownTime = 2f; // this hard codded for now will fix later 
        }
    }
}
