using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int health;
    
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        
    }

    void Update()
    {
       

        
    }

    public void TakeHealth(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
