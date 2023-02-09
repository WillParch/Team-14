using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    public int maxJumps = 4;

private int jumps;
public float speed;
 private float horizontal;
 private Rigidbody2D rd2d;
 public int maxHealth = 5;
 int currentHealth;
public int health { get { return currentHealth; }}
    private void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }
    
    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
    {
        this.Jump ();

    }
    }
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
    public void ChangeHealth(int amount)
    {
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        
    }
        
    

     private void Jump()
    {
    if (jumps > 0)
    {
        rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
        jumps = jumps - 1;
    }
    if (jumps == 0)
    {
        return;
    }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
    {
        if(Input.GetKey(KeyCode.W))
        {
        rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
        jumps = maxJumps;
        }                                                          
     }                                                                                
 }
    
    
}
