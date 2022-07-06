using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    public List<GameObject> enemies;

    void Update()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            if(!enemies[i].activeInHierarchy)
                enemies.Remove(enemies[i]);
        }
    }
}
