using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public GameObject enemyDeathEffect;
    public int currencyEarn = 15;
    public float health = 100;
    void Start()
    {
        speed = startSpeed;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }
    void Die()
    {
        PlayerStats.Money += currencyEarn;
        GameObject deathEffect = (GameObject)Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);
        Destroy(deathEffect, 2f);

        
        Destroy(gameObject);
    }

   
}
