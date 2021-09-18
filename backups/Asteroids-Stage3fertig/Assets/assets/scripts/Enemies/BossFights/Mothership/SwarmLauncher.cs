using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmLauncher : MonoBehaviour
{
    [SerializeField] private int numberOfShips = 0;
    [SerializeField] private List<GameObject> prefabs = null;
    [SerializeField] private Transform startPoint = null;
    [SerializeField] private float radius = 0f;
    [SerializeField] private float moveSpeed = 0f;

    // void Start()
    // {
    //     for(int i = 0; i < numberOfShips; i++)
    //     {
    //         GameObject prefab = Instantiate(shipPrefab, startPoint.position, startPoint.rotation);
    //         prefab.transform.parent = this.gameObject.transform;
    //         prefab.GetComponent<SwarmShip>().swarmLauncher = this;
    //         prefab.GetComponent<SwarmShip>().target = target;
    //         prefab.SetActive(false);
    //         prefabs.Add(prefab);
    //     }
    // }

    public void SpawnSwarm()
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
