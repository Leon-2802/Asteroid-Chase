using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    public List<GameManager> enemies;

    void Update()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            if(enemies[i] != isActiveAndEnabled)
                enemies.Remove(enemies[i]);
        }
    }
}
