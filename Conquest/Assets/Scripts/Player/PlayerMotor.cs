using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
NavMeshAgent agent;
public float speed;
public float walkSpeed;
public float runSpeed;
public float rollForce;
public CharacterAnimator characterAnimat;
public float dashCoolDownTime = 2f;
public float DashLength;
private Vector3 mousePoint;
public float DistMousePlayer;
Camera  cam;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        characterAnimat = GetComponentInChildren<CharacterAnimator>();
        cam = Camera.main;
    }
    public void LookAtMouse()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up,new Vector3(0,transform.position.y,0));
        float rayLenght;

        if (groundPlane.Raycast(ray, out rayLenght))
        {
            Vector3 mousePoint = ray.GetPoint(rayLenght);
            transform.LookAt(mousePoint);    
            DistMousePlayer = Vector3.Distance(mousePoint, transform.position);       
        }    
    }
    public void Move()
    {
        agent.Move(transform.forward * Time.deltaTime * speed);
    }
    public void ChangeSpeed()
    {
        if (DistMousePlayer <= 1)
        {
            speed = walkSpeed/2;
        }
        else if (DistMousePlayer > 1 && DistMousePlayer < 4)
        {
            speed = walkSpeed;
        }
        else if (DistMousePlayer >= 4)
        {
            speed = runSpeed;
        }
    }
    public void Dash()
    {
        speed = rollForce;
        characterAnimat.Roll();  
    }
    private void CoolDowns()
    {
        if (dashCoolDownTime > 0)
        {
            dashCoolDownTime -= 1 * Time.deltaTime;  
        }    
    }
    private void Update() 
    {
        CoolDowns();
    }
}
