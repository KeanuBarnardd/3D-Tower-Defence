using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public int damage = 50;
    public float explosionRadius = 0f;
    public float speed = 70f;
    public GameObject immpactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        //Registers Collision with Target
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    public void HitTarget()
    {

        Destroy(gameObject);
        GameObject effectIns = (GameObject)Instantiate(immpactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 3f);
        if (explosionRadius > 0f)
        {
            //Damage Enemies in a radius
            Explode();
        }
        else
        {
            Damage(target);
        }
    }
    /// <summary>
    /// Will Damage the Enemy Object when they collide with the Bullet
    /// </summary>
    /// <param name="enemy">Choose the Enemy Game Object you are wanting to damage </param>
    public void Damage(Transform enemy)
    {

        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
