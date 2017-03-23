using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager in scene");
        }
        instance = this;
    }

    //Build Effects
    public GameObject buildParticlePrefab;

    private TurretBluePrint turretToBuild;

    //This will check if we can get TurretToBuild/Money but return if it cannot get it 
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool hasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }


    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
    }

    /// <summary>
    /// This will Build the turret Object on the Node
    /// </summary>
    /// <param name="node">Use the "Node" GameObject</param>
    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that ");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;

        GameObject effect = (GameObject)Instantiate(buildParticlePrefab, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect,5f);
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Youve built it this is your money " + PlayerStats.Money);

    }
}
