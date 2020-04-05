//GameOBJECT NAME : Bullet
//Particle emmitter :Needed

using UnityEngine;
public class Bullet : MonoBehaviour{
    private Transform target;

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
    }

    void Hit(){
        GameObject effectsIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation)
        Destroy(effectsIns, 1.5f);
        Destroy(gameObject);
    }
}