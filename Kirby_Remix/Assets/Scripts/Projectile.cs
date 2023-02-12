using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public EnemyHealth enemyHealth;
    Rigidbody2D rd2d;
    // Start is called before the first frame update
    void Awake()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch(Vector2 direction, float force)
{
    rd2d.AddForce(direction * force);
}

private void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.gameObject.tag == "Enemy")
        {
            enemyHealth.TakeHealth(damage);
        }
    //we also add a debug log to know what the projectile touch
    Debug.Log("Projectile Collision with " + collision.gameObject);
    Destroy(gameObject);
}


}
