//Should Be Put In GameMaster Object
using UnityEngine;
using System.Collection;

public class BuildManager : Monobehaviour{
    [Header("BM")]
    public static BuildManager  instance;


    private TurretBP turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

    [Header("Turret Models")]
    public GmaeObject standardTurretPref;
    public GmaeObject superTurretPref;
    public GmaeObject missleTurretPref;
    public GmaeObject mortarTurretPref;

    void Awake()
    {
        if(instance != null){
            Debug.LogError("More than one BuildManager is in the scene!");
            return;
        }
        instance = this;
    }

    public GmaeObject GetTurretToBuild(){
        return turretToBuild;
    }

    public void SelectTurretTuBuild(TurretBP turret){
        turretToBuild = turret;
        DeselectNode();
    }

    public void SelectNode(Node node){
        if(selectedNode == node){
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }
    public void DeselectNode(){
        selectedNode = null;
        nodeUI.Hide();
    }

    public void BuildTurretOn(Node node){
        if(PlayerStats.money < turretToBuild.cost){
            Debug.Log("Not ENOUGH RESOURCES");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;

        GmaeObject turret = (GmaeObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("TB! MONNEY LEFT:" + PlayerStats.money);
    }
} 