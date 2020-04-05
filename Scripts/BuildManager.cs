//Should Be Put In GameMaster Object
using UnityEngine;

public class BuildManager : Monobehaviour{

    public static BuildManager  instance;
    


    private GmaeObject turretToBuild;

    public GmaeObject GetTurretToBuild(){
        return turretToBuild;
    }

    public GmaeObject standardTurretPref;

    void Awake()
    {
        if(instance != null){
            Debug.LogError("More than one BuildManager is in the scene!");
            return;
        }
        instance = this;
    }

    void Start(){
        turretToBuild = standardTurretPref;
    }

}