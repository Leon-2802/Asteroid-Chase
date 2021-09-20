using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] public Transform[] spawnsNorth;
    [SerializeField] public Transform[] spawnsEast;
    [SerializeField] public Transform[] spawnsSouth;
    [SerializeField] public Transform[] spawnsWest;
    public bool spawnsAssigned = false;
    [SerializeField] private Transform target = null;
    [SerializeField] private float speed = 1f;
    private bool move = false;
    private bool delete = false;
    Vector3 initialPos;

    void OnEnable()
    {
        initialPos = transform.position;
        target = transform;
        delete = false;

        if(spawnsAssigned == true)
            CheckPosition();

        // if(initialPos.y > 0)
        //     yValue = UnityEngine.Random.Range(-2f, -0.7f);
        // else
        //     yValue = UnityEngine.Random.Range(0.7f, 2f);

        // if(initialPos.x > 0)
        //     xValue = UnityEngine.Random.Range(-2f, -0.7f);
        // else
        //     xValue = UnityEngine.Random.Range(0.7f, 2f);
    }

    void Update()
    {
        if(target == transform)
            CheckPosition();
        // Vector3 newPos = transform.position;
        // newPos += new Vector3(xValue, yValue) * speed * Time.deltaTime;
        // transform.position = newPos;

        // if(transform.position.y >= 12f || transform.position.y <= -12f || transform.position.x >= 19.5f || transform.position.x <= -19.5f) 
        //     Destroy();
        if(move) 
        {
            Vector2 tempVector2 = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.position = new Vector3(tempVector2.x, tempVector2.y, transform.position.z);

            if(transform.position == target.position)
                Destroy();
        }

        CheckForBossFight();
        if(delete)
            Destroy();
    }

    void CheckPosition()
    {
        if(initialPos.y > 11f) {
            int rand = UnityEngine.Random.Range(0, spawnsSouth.Length);
            target = spawnsSouth[rand];
            move = true;
            return;
        }
        if(initialPos.x > 18.5f) {
            int rand = UnityEngine.Random.Range(0, spawnsWest.Length);
            target = spawnsWest[rand];
            move = true;
            return;
        }
        if(initialPos.y < -10.7f) {
            int rand = UnityEngine.Random.Range(0, spawnsNorth.Length);
            target = spawnsNorth[rand];
            move = true;
            return;
        }
        if(initialPos.x < -18.5f) {
            int rand = UnityEngine.Random.Range(0, spawnsEast.Length);
            target = spawnsEast[rand];
            move = true;
            return;
        }
    }
    void CheckForBossFight()
    {
        for(int i = 1; i < gameManager.bossFight.Length; i++)
        {
            if(gameManager.bossFight[i] == true)
                delete = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) {
            Destroy();
        }
    }

    void Destroy()
    {
        this.gameObject.SetActive(false);
    }
    void OnDisable()
    {
        move = false;
    }
}
