using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFellOff : MonoBehaviour
{
    // hold player possition for reset
    public Vector3 startPos;

    void Start()
    {
        // set player possition for reset
        startPos = this.gameObject.transform.position;
        print(startPos);
    }

    // Update is called once per frame
    void Update()
    {
    }


    //reset player on colission
    private void OnTriggerEnter2D(Collider2D x)
    {
        if (x.gameObject.tag == "boundry")
        {
        this.transform.position = startPos;
        print("You fell off the map. Learn to jump better");
        }

    }

}
