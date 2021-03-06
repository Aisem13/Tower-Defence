﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
    public GameObject ui;

    private Node target;

    public void SetTarget(Node node)
    {
        this.target = node;

        transform.position = target.GetBuildPosition();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
