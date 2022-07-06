using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManger : MonoBehaviour
{
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private GameObject bossStage2 = null;
    [SerializeField] private GameObject bossFight3 = null;
    [SerializeField] private GameObject bossFight4 = null;
    [SerializeField] private shipController shipController = null;
    [SerializeField] private GameObject spaceInvadersCtrls = null;
    [SerializeField] private Rotation rotationScript = null;
    [SerializeField] private GameObject joystickL = null;
    [SerializeField] private GameObject joystickR = null;
    [SerializeField] private GameObject leftArrow = null;
    [SerializeField] private GameObject rightArrow = null;
    [SerializeField] private int pointsBoss2 = 0;
    [SerializeField] private int pointsBoss3 = 0;
    [SerializeField] private int pointsBoss4 = 0;

    public void StartBossFight2()
    {
        bossStage2.SetActive(true);
    }
    public void EndBossFight2() 
    {
        bossStage2.SetActive(false);
        gameManager.bossDefeated[1] = true;
        gameManager.GivePoints(pointsBoss2);
    }

    public void StartBossFight3()
    {
        bossFight3.SetActive(true);
        shipController.enabled = false;
        spaceInvadersCtrls.SetActive(true);
        joystickL.SetActive(false);
        joystickR.SetActive(false);
        leftArrow.SetActive(true);
        rightArrow.SetActive(true);
    }
    public void EndBossFight3()
    {
        bossFight3.SetActive(false);
        shipController.enabled = true;
        spaceInvadersCtrls.SetActive(false);
        joystickL.SetActive(true);
        joystickR.SetActive(true);
        leftArrow.SetActive(false);
        rightArrow.SetActive(false);
        gameManager.bossDefeated[2] = true;
        gameManager.GivePoints(pointsBoss3);
    }

    public void StartBossFight4()
    {
        bossFight4.SetActive(true);
        rotationScript.enabled = false;
        shipController.enabled = false;
        spaceInvadersCtrls.SetActive(true);
        joystickL.SetActive(false);
        joystickR.SetActive(false);
        leftArrow.SetActive(true);
        rightArrow.SetActive(true);
    }
    public void EndBossFight4()
    {
        bossFight4.SetActive(false);
        shipController.enabled = true;
        spaceInvadersCtrls.SetActive(false);
        joystickL.SetActive(true);
        joystickR.SetActive(true);
        leftArrow.SetActive(false);
        rightArrow.SetActive(false);
        gameManager.bossDefeated[3] = true;
        gameManager.GivePoints(pointsBoss4);
    }
}
