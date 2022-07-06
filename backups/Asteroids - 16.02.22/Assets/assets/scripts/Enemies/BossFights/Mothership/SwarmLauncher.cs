using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmLauncher : MonoBehaviour
{
    [SerializeField] protected int numberOfShips = 0;
    [SerializeField] protected List<GameObject> prefabs = null;
    [SerializeField] protected Transform startPoint = null;
    [SerializeField] protected float radius = 0f;
    [SerializeField] protected float moveSpeed = 0f;

    public virtual void SpawnSwarm()
    {
        float angleStep = 180f / numberOfShips;
        float angle = 90f;

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
}
