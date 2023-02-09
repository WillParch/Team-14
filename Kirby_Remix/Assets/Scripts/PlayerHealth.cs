using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 6;
    public int health;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        
    }

    void Update()
    {
       

        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

     public void GainHealth(int gain)
    {
        if(health <= 5)
        {
        health += gain;
        }
    }

    // Update is called once per frame
    
}
