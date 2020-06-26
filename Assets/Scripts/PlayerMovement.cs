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

    public GameObject head;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (crouch == false)
        {
            head.SetActive(true);
        }
        else
        {
            head.SetActive(false);
        }

        horiontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        //print(horiontalMove);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            print("You have jumped, "+ jump);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            print("You are crouching");
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    void FixedUpdate ()
    {
        contoller.Move(horiontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }


}
