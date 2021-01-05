using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float speed= 10f;
   public Rigidbody p_Rigidbody;
   public Vector2 UserInput;
   public Collider p_Collider;
   bool isGrounded = false;

 
    void Start()
    {
        p_Rigidbody = this.GetComponent<Rigidbody>();
        p_Collider = this.GetComponent<Collider>();
    }
    void Update()
    {      
        UserInput = new Vector2(Input.GetAxisRaw("Horizontal"),0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            float jumpVelocity = 10f;
            p_Rigidbody.velocity = Vector3.up * jumpVelocity;
        }

        //Debug.Log(isGrounded);
    }
    private void FixedUpdate() 
    {
        moveCharacter(UserInput);  
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit(Collision other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }    
    }
    







    void moveCharacter(Vector2 direction)
    {
        p_Rigidbody.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }



    
  
}
