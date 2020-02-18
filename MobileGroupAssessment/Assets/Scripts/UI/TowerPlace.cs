using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    public GameObject towerPrefab;
    private GameObject tower;

    private bool CanPlaceTower()
    {
        return tower = null;
    }

    void OnMouseUp()
    {
        if (CanPlaceTower())
        {
            tower = (GameObject)
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
        }
    }
}
