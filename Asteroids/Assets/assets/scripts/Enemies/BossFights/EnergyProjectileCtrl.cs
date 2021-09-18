using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyProjectileCtrl : MonoBehaviour
{
    [SerializeField] private LaunchEnergyBalls launchEnergyBalls = null;
    [SerializeField] private SpriteRenderer spriteRenderer = null;
    [SerializeField] private float moveTimeMin = 0f;
    [SerializeField] private float moveTimeMax = 0f;
    private float currentMoveTime;
    [SerializeField] private float lifetime = 3.5f;
    private float currentLifetime;
    [SerializeField] private float speed = 0f;
    private bool spawned = false;
    void OnEnable()
    {
        currentMoveTime = UnityEngine.Random.Range(moveTimeMin, moveTimeMax);
        spriteRenderer.enabled = true;
        currentLifetime = lifetime;
        spawned = false;
    }

    void Update()
    {
        currentMoveTime -= Time.deltaTime;
        if(currentMoveTime <= 0) {
            callSpawn();
            spriteRenderer.enabled = false;
            currentLifetime -= Time.deltaTime;
            if(currentLifetime <= 0)
                this.gameObject.SetActive(false);
        } else {
            Vector3 newPosition = transform.position;
            newPosition += transform.right * speed * Time.deltaTime;
            transform.position = newPosition;
        }
    }

    void callSpawn()
    {
        if(spawned == false) {
            launchEnergyBalls.SpawnEnergyBalls();
            spawned = true;
        }

    }
}
