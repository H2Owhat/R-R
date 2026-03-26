using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Runtime.CompilerServices;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    private playerMovement pMovement;
    private Vector2 hoppsLocation;
    private Vector2 enemyLocation;
    public Vector2 spawnLocation;
    private Rigidbody2D rBody;
    private SpriteRenderer sRend;
    [SerializeField] DeathScreen deathScreen;
    [SerializeField] private AudioClip hitSounds;
    [SerializeField] private AudioSource soundEffects;

    void Awake()
    {
        soundEffects = GetComponent<AudioSource>();
        health = maxHealth;
        pMovement = GetComponent<playerMovement>();
        rBody = GetComponent<Rigidbody2D>();
        hoppsLocation = transform.position;
        sRend = GetComponent<SpriteRenderer>();
        spawnLocation = transform.position;
    }

    public void TakeDamageHopps(int amount)
    {
        health -= amount;

        soundEffects.clip = hitSounds;
        soundEffects.Play();

        if (health <= 0)
        {
            Respawn(); //Change to allow for checkpoints and loading into other levels later
        }

        StartCoroutine(DamageFlash());
    }

    public void GainHealth(int amount)
    {
        health += amount;

        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }

   

    private IEnumerator DamageFlash()
    {
        sRend.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sRend.material.color = Color.white;
    }


    public void Respawn()
    {
        health = maxHealth;
        deathScreen.isDead = true;
        transform.position = spawnLocation;
    }
}
    
