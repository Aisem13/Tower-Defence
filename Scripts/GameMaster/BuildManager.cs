using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one BuildManager in scene!");
        }
        instance = this;
    }

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public TowerUI nodeUI;
    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enought money tu build that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

        DeselectNode();
    }
}
