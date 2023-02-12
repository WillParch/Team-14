using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth2 : MonoBehaviour
{
    public int maxHealth = 5;
    public int health;
    // Start is called before the first frame update
   private void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeHealth2(int damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
