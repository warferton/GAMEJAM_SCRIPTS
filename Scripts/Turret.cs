//GameObject Name: Turret
//*'Bullet' Object should be created as a pref
//*'Fire Point' Object should be craeted 

using UnityEngine;

public class Turret : MonoBehaviour{
    private Transform target;

    [Header("Rotatation")]
    public float turnSpeed = 8f;
    public Trasform partToRotate;

    [Header("Enemy")]
    public string enemyTag = "Enemy";

    [Header("Shooting")]
    public float range = 15f;
    public float fireRate = 2f;
    private float fireCountDown = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint; //Fires from this point 

    void Start(){
        InvokeRepeating("UpdateTarget", 0f, 0.5f)
    }


    void Update(){
        if(target == null)
        {
            return null;
        }
        //lockingOn
        Vector3 dir = target.position - transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime*turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountDown<= 0 )
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;


    }

    void Shoot(){
        GameObject bulletOUT = (GameObject)Instantiate(bulletPref, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletOUT.GetComponent<Bullet>();

        if( bullet != null){
            bullet.Seek(target);
        }
    }

    void UpdateTarget(){
        GameObject[] enemies = GameObject.FindGameobjectsWithTag(enemyTag);

        float shortestDist = Mathf.Infinity;

        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies){
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDist){
                shortestDist = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDist <= range){
            target = nearestEnemy.transform;
        }
        else{
            target = null;
        }

    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
 