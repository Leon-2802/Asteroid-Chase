using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManger : MonoBehaviour
{
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private GameObject bossStage2 = null;

    public void StartBossFight2()
    {
        bossStage2.SetActive(true);
    }
    public void EndBossFight2() 
    {
        bossStage2.SetActive(false);
        gameManager.bossDefeated[1] = true;
    }
}
