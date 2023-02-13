using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 6;
    public int health;
     public Text livesText;
    private int lives = 3;
    public Transform spawnPoint;
    private Transform playerPos;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        SetLivesText();
        lives = 3;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    void Update()
    {
       

        
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
       
        
        if(health <= 0)
        {
            health = maxHealth;
            playerPos.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
            lives = lives -1;

            SetLivesText();
            
        }

        HealthBar.instance.SetValue(health / (float)maxHealth);
    }

     public void GainHealth(int gain)
    {
        if(health <= 5)
        {
        health += gain;
        }
        HealthBar.instance.SetValue(health / (float)maxHealth);
    }

    // Update is called once per frame
    
}
