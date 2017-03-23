using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    public int health = 100;

    public int moneyGainFromDeath = 50;

    public GameObject deathParticleEffect;

    private Transform target;
    //This will be the way Point the enemy is moving towards
    private int wavepointIndex = 0;

    /// <summary>
    /// This will handle the Damage taken when the enemy gets hit by a bullet
    /// </summary>
    /// <param name="amount">Handles the amount of Damage Taken </param>
    public void TakeDamage(int amount) {
        health -= amount;
        if (health <= 0) {
            Die();
        }
    }
 
    void Die()
    {
        PlayerStats.Money += moneyGainFromDeath;
        GameObject effect = (GameObject)Instantiate(deathParticleEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        //Add some money and cool effect
        Destroy(gameObject);
    }

    void Start()
    {
        target = WayPoints.points[0];
    }

    void Update()
    {
        //To get the point from our current Pos , to target pos , you just need to negate 
        // Current position from targete 
        Vector3 dir = target.position - transform.position;
        //Make sure it always has the same fixed speed 
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        //Checks if the distance between the current and target pos is less that 0.2
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            getNextWayPoint();
            return;
        }
    }
    /// <summary>
    /// Will check if the enemy is still less than the total amount of wayPoints , 
    /// until it is more than the total amount - in which it will call endPath
    /// </summary>
    public void getNextWayPoint() {
        if (wavepointIndex >= WayPoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = WayPoints.points[wavepointIndex];
    }

    void EndPath() {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
