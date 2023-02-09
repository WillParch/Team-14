using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public int gain;
    public PlayerHealth playerHealth;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.GainHealth(gain);
            Destroy(gameObject);
        }
    }
            
}

