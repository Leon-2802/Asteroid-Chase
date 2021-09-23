using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwarmLauncher : SwarmLauncher
{
    private void OnEnable() 
    {
        SpawnSwarm();
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

    private void OnDisable() 
    {
        for (int i = 0; i < prefabs.Count; i++) 
        {
			GameObject ship = prefabs[i];
            ship.transform.position = startPoint.position;
		}
    }
}
