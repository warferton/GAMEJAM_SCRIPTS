using UnityEngine;
using System.Collections;

public class NodeUI : MonoBehaviour{

    private Node target;

    public GameObject ui;



    public void SetTarget(Node t){
        this.target = t;
        ui.SetActive(true);

        transform.position = target.GetBuildPosition();
    }
    public void Hide(){
        ui.SetActive(false);
    }

}