using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
   void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            //One Shot Trap
            Application.LoadLevel(Application.loadedLevel); 
            Debug.Log("Restarted");
        }
    }
}
