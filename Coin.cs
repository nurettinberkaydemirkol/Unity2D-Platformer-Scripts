using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Coin int
    int coin;

    //Collider with ready settings
    BoxCollider2D collider;
    Rigidbody2D rb;

    void Start() 
    {
        ColliderSetting();
        RigidbodySetting();
    }

    void FixedUpdate() 
    {
        coin = PlayerPrefs.GetInt("coin");
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            //Increase Coin Count
            coin++;

            //Save Count to Memory
            PlayerPrefs.SetInt("coin", coin);

            //Destroy Coin
            Destroy(gameObject);

            //Print Coin Count
            Debug.Log(coin);
        }
    }

    void ColliderSetting()
    {
        collider = GetComponent<BoxCollider2D>();
        collider.isTrigger = true;
    }

    void RigidbodySetting()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }
}
