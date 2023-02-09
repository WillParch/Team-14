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
 public GameObject projectilePrefab;
 RaycastHit2D hit;
  Vector2 lookDirection = new Vector2(1,0);
  bool isPower;

    private void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        isPower = false;
    }
    
    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.W))
        {
            this.Jump (); 
        }

        

        if(isPower == true)
        {
            if(Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }
        }

        if (Input.GetKey(KeyCode.V))
        {
            isPower = false;
        }
    }
        
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            lookDirection = new Vector2(-1,0);
            
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            lookDirection = new Vector2(1,0);
            
        }

       if (Input.GetKeyDown(KeyCode.X))
        {
        RaycastHit2D hit = Physics2D.Raycast(rd2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("Enemy"));
        if (hit.collider != null)
        {
        if(hit.collider.gameObject.tag == "Enemy")
        {
            Destroy (hit.collider.gameObject);
            isPower = true;
        }
        
        }
        }
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
    
    void Launch()
    {
        
        GameObject projectileObject = Instantiate(projectilePrefab, rd2d.position + Vector2.up * 0.1f, Quaternion.identity);

    Projectile projectile = projectileObject.GetComponent<Projectile>();
    projectile.Launch(lookDirection, 300);

        
    }

    
}
