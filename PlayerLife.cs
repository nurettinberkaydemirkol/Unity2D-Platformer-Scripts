using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    //[IF] USE THIS CODE IF YOU WANT TO ADD HEARTBAR OR LIFEBAR TO YOUR GAME [ELSE] YOU CAN USE TRAP SCRIPT :)

    Rigidbody2D rb;

    //Set Life
    public int Life;

    //Set Damage
    public int Damage;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() 
    {
        //Check Health and Restart
        if(Life == 0)
        {
            Debug.Log("U DED");
            Application.LoadLevel(Application.loadedLevel); 
            Debug.Log("Restarted");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Trap")
        {
            //Decrease Health
            Life -= Damage;

            //Jump Player When Get Damage
            rb.velocity = new Vector2(rb.velocity.x, 10);
        }
    }
}
