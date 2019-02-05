using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{

    public GameObject metra;
    public GameObject canon;

    public bool _tempTower;

    private GameObject activeTurret;

    void Start()
    {
        _tempTower = false;
    }

    void Update()
    {
        checkTurretSpawn();
    }

    public void spawnMetraTurret()
    {
        if (GameManager.instance.gold >= Turret.metracost && !_tempTower)
        {
            GameManager.instance.gold -= Turret.metracost;
            _tempTower = true;
            activeTurret = metra;
        }
    }

    public void spawnCanonTurret()
    {
        if (GameManager.instance.gold >= Turret.cañoncost && !_tempTower)
        {
            GameManager.instance.gold -= Turret.cañoncost;
            _tempTower = true;
            activeTurret = canon;
        }
    }

    private void checkTurretSpawn()
    {
        if (_tempTower)
        {

            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    Instantiate(activeTurret, hit.point, Quaternion.identity);

                    _tempTower = false;



                }
            }
            
        }
    }
}

