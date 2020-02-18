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
        else if (CanUpgradeMonster())
        {
            tower.GetComponent<TowerData>().IncreaseLevel();
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
            // TODO: Deduct gold
        }
    }
    private bool CanUpgradeMonster()
    {
        if (tower != null)
        {
            TowerData monsterData = tower.GetComponent<TowerData>();
            TowerLevel nextLevel = monsterData.GetNextLevel();
            if (nextLevel != null)
            {
                return true;
            }
        }
        return false;
    }
}
