using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelmet : MonoBehaviour
{
    public float health = 100;
    public GameObject enemyGO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void helmetDamaged(float damage)
    {
        health = health - damage;
        enemyGO.GetComponent<Enemy>().Hurt(damage / 2);
    }
}
