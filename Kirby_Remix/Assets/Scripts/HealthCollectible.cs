using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public int gain;
    public PlayerHealth playerHealth;
    AudioSource audioSource;
    public AudioClip key;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audioSource.clip = key;
            audioSource.Play();
            playerHealth.GainHealth(gain);
            Destroy(gameObject);
        }
    }
            
}

