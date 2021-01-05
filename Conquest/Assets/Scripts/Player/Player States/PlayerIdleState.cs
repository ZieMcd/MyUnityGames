using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    
   public override void EnterState(PlayerController player)
    {
        player.Motor.speed = 0f;
    }
    public override void Update(PlayerController player)
    {
        player.Motor.LookAtMouse();

        if (Input.GetMouseButtonDown(1))
        {
            player.TrasitionToState(player.locomotionState);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(player.Motor.dashCoolDownTime <= 0)
            {
                player.TrasitionToState(new PlayerRollingState());
            }
        }
    }
}
