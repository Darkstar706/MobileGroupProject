using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    private GameManagerBehaviour gameManager;
    public GameObject towerPrefab;
    private GameObject tower;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehaviour>();
    }

    private bool CanPlaceTower()
    {
        int cost = towerPrefab.GetComponent<TowerData>().levels[0].cost;
        return tower == null && gameManager.Gold >= cost;
    }

    void OnMouseUp()
    {
        if (CanPlaceTower())
        {
            tower = (GameObject)
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
            gameManager.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;
        }
        else if (CanUpgradeTower())
        {
            tower.GetComponent<TowerData>().IncreaseLevel();
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
            gameManager.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;
        }
    }
    private bool CanUpgradeTower()
    {
        if (tower != null)
        {
            TowerData monsterData = tower.GetComponent<TowerData>();
            TowerLevel nextLevel = monsterData.GetNextLevel();
            if (nextLevel != null)
            {
                return gameManager.Gold >= nextLevel.cost;
            }
        }
        return false;
    }
}
