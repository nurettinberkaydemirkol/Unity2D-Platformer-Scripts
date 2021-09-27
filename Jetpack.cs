using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    Rigidbody2D rb;

    //Jetpack Power
    public float jetpackForce;
    bool on;

    //Jetpack Fuel
    public int Fuel;
    int SaveFuel;
    
    void Start()
    {
        //Save Fuel
        SaveFuel = Fuel;
        
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RunJetpack();
    }

    void FixedUpdate() 
    {
        if(on == true && Fuel > 0)
        {
            //Jetpack Up Up Up !!!
            rb.AddForce(new Vector2(0, jetpackForce));

            //Decrease Fuel
            Fuel--;

            //Print Fuel
            Debug.Log("Fuel: " + Fuel);
        }
        else
        {
            rb.AddForce(new Vector2(0, 0));
        }
    }

    void RunJetpack()
    {   
        if(Input.GetKeyDown(KeyCode.W))
        {
            on = true;
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            on = false;
        }  
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "FuelTank") 
        {
            //Reset Fuel 
            Fuel = SaveFuel;
            //or
            //Fuel += [What You Want];
            Destroy(other.gameObject);//Destroy Fuel Tank Object
        }
    }
}
