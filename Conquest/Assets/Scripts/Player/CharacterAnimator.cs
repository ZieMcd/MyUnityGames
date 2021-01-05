using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CharacterAnimator : MonoBehaviour
{
    Animator animator;
    PlayerMotor motor;
    const float locomationAnimationSmoothTime = .1f;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        float speedPercent = motor.speed/motor.runSpeed;
        animator.SetFloat("speedPercent",speedPercent, locomationAnimationSmoothTime, Time.deltaTime);
    }

    public void Roll()
    {
        animator.SetTrigger("Roll");
    }
}
