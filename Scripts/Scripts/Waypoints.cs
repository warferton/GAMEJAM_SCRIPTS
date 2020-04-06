//Obj Name : Waypoint

using UnityEngine;

public class Waypoints : MonoBehaviour {

    public static Transform[] waypoints;

    void Awake(){
        waypoint = new Transform[transform.childCount];
        for(int i = 0 ; i< points.Length; i++){
            waypoints[i] = transform.GetChild(i);
        }
    }

}