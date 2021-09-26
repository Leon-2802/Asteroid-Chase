using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwarmLauncher : SwarmLauncher
{
    [SerializeField] private EnemyList enemyList = null;
    [SerializeField] private float countdown = 0f;
    private float currentCountdown;
    private int selectCounter = 0;
    private void OnEnable() 
    {
        SpawnSwarm();
        currentCountdown = countdown;
        selectCounter = 0;
    }

    void Update() 
    {
        currentCountdown -= Time.deltaTime;
        if(currentCountdown <= 0 && selectCounter < prefabs.Count)
        {
            if(enemyList.enemies.Count == 0)
                return;
            int index = UnityEngine.Random.Range(0, enemyList.enemies.Count);
            prefabs[selectCounter].transform.parent = null;
            prefabs[selectCounter].GetComponent<SwarmShip>().target = enemyList.enemies[index].transform;
            prefabs[selectCounter].transform.GetChild(0).gameObject.SetActive(true);
            selectCounter++;
            currentCountdown = countdown;
        }

        Disable();
    }
    public override void SpawnSwarm()
    {
        float angleStep = 360f / numberOfShips;
        float angle = 0f;

        for (int i = 0; i < prefabs.Count; i++) {
			
			float shipDirXposition = startPoint.position.x + Mathf.Sin ((angle * Mathf.PI) / 180) * radius;
			float shipDirYposition = startPoint.position.y + Mathf.Cos ((angle * Mathf.PI) / 180) * radius;

			Vector3 shipVector = new Vector3 (shipDirXposition, shipDirYposition);
			Vector3 shipMoveDirection = (shipVector - startPoint.position).normalized * moveSpeed;

			GameObject ship = prefabs[i];
            ship.transform.position = startPoint.position;
            ship.SetActive(true);
			ship.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shipMoveDirection.x, shipMoveDirection.y);

			angle += angleStep;
		}
    }

    void Disable() 
    {
        for(int i = 0; i < prefabs.Count; i++)
        {
            if(prefabs[i].activeInHierarchy)
                return;
        }
        this.gameObject.SetActive(false);
    }
    private void OnDisable() 
    {
        for (int i = 0; i < prefabs.Count; i++) 
        {
			GameObject ship = prefabs[i];
            ship.transform.position = startPoint.position;
            ship.GetComponent<SwarmShip>().target = this.gameObject.transform;
            ship.transform.GetChild(0).gameObject.SetActive(false);
		}
    }
}
