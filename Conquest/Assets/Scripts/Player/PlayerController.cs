using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementmask;
    PlayerMotor motor;
    RaycastHit hit;

    private PlayerBaseState currentState;
    public readonly PlayerIdleState idleState = new PlayerIdleState();
    public readonly PlayerAttackingState attackingState = new PlayerAttackingState();
    public readonly PlayerLocomotionState locomotionState = new PlayerLocomotionState();
    
    public PlayerBaseState CurrentState
    {
        get {return currentState;}
    }
    public PlayerMotor Motor
    {
        get {return motor;}
    }
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        TrasitionToState(idleState);
    }

    void Update()
    {
        currentState.Update(this);
    }

    public void TrasitionToState(PlayerBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
} 
