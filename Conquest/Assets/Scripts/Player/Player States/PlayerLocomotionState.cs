using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotionState : PlayerBaseState
{
    public override void EnterState(PlayerController player)
    {

    }
    public override void Update(PlayerController player)
    {
        player.Motor.LookAtMouse();
        player.Motor.ChangeSpeed();
        player.Motor.Move();

        if(Input.GetMouseButtonUp(1))
        {
            player.TrasitionToState(player.idleState);
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
