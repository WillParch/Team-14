using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
     public int damageAmount;
    public EnemyHealth enemyHealth;
    public EnemyHealth2 enemyHealth2;
    Rigidbody2D rd2d;
    float timer;
    public float forwardTime = 1.0f;
    // Start is called before the first frame update
    void Awake()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= forwardTime)
        {
            GetComponent<Rigidbody2D>().velocity = FindObjectOfType<PlayerController>().transform.position - transform.position;
            Destroy(gameObject, 2);
        }
    }

    public void Throw(Vector2 direction, float force)
    {
        rd2d.AddForce(direction * force);
         
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyHealth>().TakeHealth(1);
            }
        if(collision.gameObject.tag == "Enemy2")
            {
                collision.gameObject.GetComponent<EnemyHealth2>().TakeHealth2(1);
            }
        //we also add a debug log to know what the projectile touch
        Debug.Log("Projectile Collision with " + collision.gameObject);
        
    }
}