using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public GameObject enemyDeathEffect;
    public int currencyEarn = 15;
    public int health = 100;
    private Transform target;
    private int wavepointIndex = 0;


    void Start()
    {
        target = Waypoints.wayPoints[0];
    }


    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        PlayerStats.Money += currencyEarn;
        GameObject deathEffect = (GameObject)Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);
        Destroy(deathEffect, 2f);

        
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position)<= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {

        if(wavepointIndex >= Waypoints.wayPoints.Length - 1)
        {

            
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.wayPoints[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
