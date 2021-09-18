using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceInvadersCtrls : MonoBehaviour
{
    [SerializeField] private shootCtrl shootCtrl = null;
    [SerializeField] private GameObject spaceship = null;
    [SerializeField] private float speed = 3f;
    [SerializeField] private Image leftButton = null;
    [SerializeField] private Image rightButton = null;
    [SerializeField] private Sprite idleRight = null;
    [SerializeField] private Sprite idleLeft = null;
    [SerializeField] private Sprite touchedRight = null;
    [SerializeField] private Sprite touchedLeft = null;
    private bool leftIsPressed = false;
    private bool rightIsPressed = false;
 
    void Update()
    {
        shootCtrl.AutoShoot();
        if(leftIsPressed == true)
        {
            leftButton.sprite = touchedLeft;
            Vector3 newPos = spaceship.transform.position;
            newPos -= transform.right * speed * Time.deltaTime;
            spaceship.transform.position = newPos;
        }
        if(rightIsPressed == true)
        {
            rightButton.sprite = touchedRight;
            Vector3 newPos = spaceship.transform.position;
            newPos += transform.right * speed * Time.deltaTime;
            spaceship.transform.position = newPos;
        }

        if(spaceship.transform.position.x < -18.10f) {
            Vector3 newPos = spaceship.transform.position;
            newPos.x = 17.78f;
            spaceship.transform.position = newPos;
        }
        else if(spaceship.transform.position.x > 18.1f) {
            Vector3 newPos = spaceship.transform.position;
            newPos.x = -18f;
            spaceship.transform.position = newPos;
        }
    }

    public void PressButtonLeft()
    {
        leftIsPressed = true;
    }
    public void ReleaseButtonLeft()
    {
        leftIsPressed = false;
        leftButton.sprite = idleLeft;
    }

    public void PressButtonRight()
    {
        rightIsPressed = true;
    }
    public void ReleaseButtonRight()
    {
        rightIsPressed = false;
        rightButton.sprite = idleRight;
    }
}
