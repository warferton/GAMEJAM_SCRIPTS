//GameOBJECT NAME : Bullet
//Particle emmitter :Needed
//Explosion Radius Should Changed Be Changend on Missle;

using UnityEngine;
using System.Collection;

public class Bullet : MonoBehaviour{
    private Transform target;

    public float damageRadius = 0f;
    public float bulletSpeed = 50f;
    public GameObject impactEffect;

    public void Chase(Transform _target){
        target = _target;
    }

    void Update(){
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir  = target.position - transform.position;
        float distanceThisFrame = bulletSpeed*Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            Hit();
            return;
        }
        transform.Translate(dir.normalized*distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void Hit(){
        GameObject effectsIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation)
        Destroy(effectsIns, 1.5f);
        if(damageRadius > 0)
        {
            Explode();
        }
        else{
            Damage(target);
        }
        Destroy(gameObject);
    }

    void Damage(Transform enemy){
        Destroy(enemy.gameObject);
    }

    void Explode()
    {
        Colider[] coliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in coliders){
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
}