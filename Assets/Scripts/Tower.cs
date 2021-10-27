using UnityEngine;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
    public GameObject _upgrade = null;
    private GameObject upgrade { get { return _upgrade; } }

    private List<Enemy> enemies { get; set; } = null;

    //value in gold
    public int _value = 10;
    private int value { get { return _value; } }

    //handles fire rate
    private float currentFireRate { get; set; } = 0;
    private bool canShoot { get; set; } = true;
    public float _fireRate = 0.1f;
    private float fireRate { get { return _fireRate; } set { _fireRate = value; } }

    private void Start()
    {
        enemies = new List<Enemy>();
    }

    private void Update()
    {
        if (!canShoot)
        {
            currentFireRate += Time.deltaTime;
            if (currentFireRate >= fireRate)
            {
                canShoot = true;
                currentFireRate = 0;
            }
            return;
        }

        if (enemies != null && enemies.Count > 0)
        {
            //Shoot on the enemy
            canShoot = false;
            Destroy(enemies[0].gameObject);
            enemies.RemoveAt(0);
            GameManager.instance.AddGold(1);
        }
    }

    public void Upgrade()
    {
        if(upgrade == null)
        {
            return;
        }

        if(GameManager.instance.gold < value)
        {
            return;
        }

        Instantiate(upgrade, transform.position, transform.rotation);
        GameManager.instance.AddGold(-10);
        Destroy(gameObject);
    }

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
    }
}
