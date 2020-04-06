//Should Be Put On the Node

using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour{
    public Material hoverColor;
    private Material startMat;

    public Vector3 positionOffset;

    private Renderer rend;

    [Header("Optional")]
    public GameObject turret;

    BuildManager buildManager;

    void Start()}{
        rend =GetComponent<Renderer>();
        startMat = rend.material;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown(){
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }
        if(buildManager.GetTurretToBuild == null){
            return;
        }
        if(turret != null){
            return;
        }
        GameObject turrretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turrretToBuild, transform.position * positionOffset, transform.rotation);
    }

    void OnMouseEnter(){
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }
         if(buildManager.GetTurretToBuild == null){
            return;
        }
        rend.material = hoverColor;
    
    }
    void OnMouseExit(){
        rend.material = startMat;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}