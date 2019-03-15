using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public GameObject impactEffect;
    public float speed = 70f;

    public float explosionRadious = 0f;
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    }

    void HitTarget()
    {

        GameObject effecIns= (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effecIns, 3.9f);

        if(explosionRadious > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);

    }

   
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadious);
        foreach (Collider collider in colliders)

        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }
    void OnDawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadious);
    }
    
}
