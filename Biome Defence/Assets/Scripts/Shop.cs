using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBluePrint standardTurret;
    public TurretBluePrint missleTurret;
    public TurretBluePrint laserBeamer;

    BuildManager buildManager;

    // Use this for initialization
    void Start () {
        buildManager = BuildManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #region TurretPurchasing
    public void SelectStandardTurret()
    {
        Debug.Log("Stanard Turret Purchased");
        buildManager.SelectTurretToBuild(standardTurret);
    }


    public void SelectMissleTurret()
    {
        Debug.Log("Stanard Turret Purchased");
        buildManager.SelectTurretToBuild(missleTurret);
    }

    public void SelectLaserBeamer() {

        buildManager.SelectTurretToBuild(laserBeamer);
    }

    #endregion
}
