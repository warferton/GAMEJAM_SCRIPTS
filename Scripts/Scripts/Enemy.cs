//Object name: Enemy
//ObjectTag : Enemy

using UnityEngine;
public class Enemy : MonoBehaviour{
    [Header("Enemy Stats")]
    public float speed = 10f;
    public static int Helath = 45;
    [Header("Reward")]
    public int reward = 50;
    [Header("Death Effect")]
    public GameObject deathEffect;


    private Transform target;
    private int wavePointIndex = 0;

    void Start()
    {
        target = Waypoints.waypoints[0];
    }

    public void TakeDamage(int ammout){
        Helath -= ammout;
        if(Header<=o)
        {
            Die();
        }
    }
    void Die()
    {
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        PlayerStats.money += reward;
        Destroy(effect,5f);
        Destroy(gameObject);

    }

    void Update(){
        Vector3 direction = target.position - transform.position ;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f ){
            GetNextWaypoint();
            }
        }

    void GetNextWaypoint(){
        if(wavePointIndex >= Waypoints.waypoints.length - 1)
        {

            return;
        }

        wavePointIndex++;
        target = Waypoints.waypoints[wavePointIndex];
    }

    void PathEnded(){
        PlayerStats.Lives --; 
        Destroy(gameObject);
    }
}
