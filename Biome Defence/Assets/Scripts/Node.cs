using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    BuildManager buildManager;

    [Header("Optional")]
    public GameObject turret;

    public Color hoverColor;
    public Color invalidColor;

    public Vector3 posOffset;

    private Renderer rend;
    private Color startColor;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        buildManager = BuildManager.instance;
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("We cant build here ");

            return;
        }

        buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.hasMoney)
        {
            rend.material.color = hoverColor;
        }
        else {
            rend.material.color = invalidColor;
        }
    }

    private void OnMouseOver()
    {
        if (turret != null)
        {
            rend.material.color = invalidColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + posOffset;
    }
}
