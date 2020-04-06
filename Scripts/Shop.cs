//Object Name: Shop

using UnityEngine;

public class Shop : MonoBehaviour{
    BuildManager buildManager;

    public TurretBP standardTurret;
    public TurretBP missleTurret;
    public TurretBP mortarTurret;
    public TurretBP superTurret;

    void Start(){
        buildManager = BuildManager.instance;
    }


    public void SelectStandardTurret(){
        Debug.Log("StandardTurret");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissleTurret(){
        Debug.Log("MissleTurret");
         buildManager.SelectTurretToBuild(missleTurret);
    }
    public void SelectSuperTurret(){
        Debug.Log("SuperTurret");
         buildManager.SelectTurretToBuild(superTurret);
    }
    public void SelectMortarTurret(){
        Debug.Log("MortarTurret");
         buildManager.SelectTurretToBuild(mortarTurret);
    }
}