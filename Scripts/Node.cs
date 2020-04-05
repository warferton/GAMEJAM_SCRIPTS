//Should Be Put On the Node

using UnityEngine;

public class Node : MonoBehaviour{
    public Material hoverColor;
    private Material startMat;

    public Vector3 positionOffset;

    private Renderer rend;

    private GameObject turret;


    void Start()}{
        rend =GetComponent<Renderer>();
        startMat = rend.material;
    }

    void OnMouseDown(){
        if(turret != null){
            return;
        }
        GameObject turrretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turrretToBuild, transform.position * positionOffset, transform.rotation);
    }

    void OnMouseEnter(){
        rend.material = hoverColor;

    }
    void OnMouseExit(){
        rend.material = startMat;
    }
}