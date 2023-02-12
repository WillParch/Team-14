using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
   
    public int maxJumps = 4;

    private int jumps;
    public float speed;
    private float horizontal;
    private Rigidbody2D rd2d;
    public GameObject projectilePrefab;
    public GameObject boomerangPrefab;
    RaycastHit2D hit;
    Vector2 lookDirection = new Vector2(1,0);
    bool isPower;
    bool isCutter;
    public SpriteRenderer spriteRenderer;
    public Sprite beamSprite;
    public Sprite cutterSprite;
    public Sprite normSprite;
    public Sprite normfallSprite;
    public Sprite changefallSprite;
    public Sprite otherfallSprite;
    Animator animator;
    public float FallingThreshold = -1f;
    public bool Falling = false;
    
    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rd2d = GetComponent<Rigidbody2D>();
        isPower = false;
        isCutter = false;
        animator = GetComponent<Animator>();
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
            ChangeSprite(beamSprite);
            if(Input.GetKeyDown(KeyCode.C))
            {
                Launch();
            }
        }

        if(isCutter == true)
        {
            OtherSprite(cutterSprite);
            if(Input.GetKeyDown(KeyCode.C))
            {
                
                Throw();
            }
        }

        if (Input.GetKey(KeyCode.V))
        {
            OriginSprite(normSprite);
            isPower = false;
            isCutter = false;
        }
        
       if (rd2d.velocity.y < FallingThreshold)
       {
        Falling = true;
       }
       else
       {
        Falling = false;
       }

       if(Falling)
       {
        NormFallSprite(normfallSprite);
       }
       if(Falling == false && isCutter == false && isPower == false)
       {
         OriginSprite(normSprite);
       }

       if(Falling && isPower == true)
        {
        ChangeFallSprite(changefallSprite);
        }
        if(Falling == false && isPower == true)
        {
        ChangeSprite(beamSprite);
        }

         if(Falling && isCutter == true)
        {
        OtherFallSprite(otherfallSprite);
        }
        if(Falling == false && isCutter == true)
        {
        OtherFallSprite(cutterSprite);
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
        RaycastHit2D hit = Physics2D.Raycast(rd2d.position + Vector2.up * 0.1f, lookDirection, 1.5f, LayerMask.GetMask("Enemy"));
        if (hit.collider != null)
        {
        if(hit.collider.gameObject.tag == "Enemy")
        {
            Destroy (hit.collider.gameObject);
            isPower = true;
            isCutter = false;
        }
        
        if(hit.collider.gameObject.tag == "Enemy2")
        {
            Destroy (hit.collider.gameObject);
            isCutter = true;
            isPower = false;
        }
        }
        }
    }

    void ChangeSprite(Sprite beamSprite)
    {
        spriteRenderer.sprite = beamSprite;
    }
    void OtherSprite(Sprite cutterSprite)
    {
        spriteRenderer.sprite = cutterSprite;
        
    }
    void OriginSprite(Sprite normSprite)
    {
        spriteRenderer.sprite = normSprite;
        
    }
    void NormFallSprite(Sprite normfallSprite)
    {
        spriteRenderer.sprite = normfallSprite;
    }
    void ChangeFallSprite(Sprite changefallSprite)
    {
        spriteRenderer.sprite = changefallSprite;
    }
    void OtherFallSprite(Sprite otherfallSprite)
    {
        spriteRenderer.sprite = otherfallSprite;
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
        
        
        if(collision.collider.tag == "Door")
            {
            SceneManager.LoadScene("GameOver");
            }    
                                                                                   
    }
    
    void Launch()
    {
        
    GameObject projectileObject = Instantiate(projectilePrefab, rd2d.position + Vector2.up * 0.1f, Quaternion.identity);

    Projectile projectile = projectileObject.GetComponent<Projectile>();
    projectile.Launch(lookDirection, 300);
    }

    void Throw()
    {
        
    GameObject boomerangObject = Instantiate(boomerangPrefab, rd2d.position + Vector2.up * 0.1f, Quaternion.identity);

    Boomerang boomerang = boomerangObject.GetComponent<Boomerang>();
    boomerang.Throw(lookDirection, 300);
    
    
    }
}