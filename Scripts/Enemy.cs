//Object name: Enemy
//ObjectTag : Enemy

using UnityEngine;
public class Enemy : MonoBehaviour{
    public float speed = 10f;

    private Transform target;
    private int wavePointIndex = 0;

    void Start()
    {
        target = Waypoints.waypoints[0];
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
            Destroy(gameObject);
            return;
        }

        wavePointIndex++;
        target = Waypoints.waypoints[wavePointIndex];
    }
}
