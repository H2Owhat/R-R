using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    // Start is called once before the first execution of Update after the MonoBehavior is created
    void Start()
    {
        health = maxHealth;
    }

    public void takeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            SceneManager.LoadSceneAsync("mainScene");
        }
    }

    public void gainHealth(int amount)
    {
        health += amount;

        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }
}
