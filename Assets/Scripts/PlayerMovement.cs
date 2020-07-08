using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D contoller;
    //targer the movement script

    float horiontalMove = 0f;
    public float runSpeed = 40f;

    bool jump = false;
    bool crouch = false;

    bool canUseJetpack = false;

    public GameObject head;

    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        ani = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*  
        if (crouch == false)
          {
              head.SetActive(true);           
          }
          else
          {
              //head.SetActive(false);
          }
        */

        horiontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            ani.SetBool("Walking", true);
        }
        else
        {
            ani.SetBool("Walking", false);
        }

        //print(horiontalMove);

        if (Input.GetButtonDown("Jump"))
        {
            if (canUseJetpack == true)
            {

            }
            else
            {
                jump = true;
                print("You have jumped, " + jump);
                ani.SetBool("Jump", true);
                //canUseJetpack = true;
            }            
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            print("You are crouching");
            ani.SetBool("Crouch", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            ani.SetBool("Crouch", false);
        }
    }

    void FixedUpdate ()
    {
        contoller.Move(horiontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        ani.SetBool("Jump", false);
    }

    //Ref https://www.youtube.com/watch?v=c3iEl5AwUF8
    // determins if the player is on the ground or not
    /*private bool IsGrounded()
    {

    }
    */
}
