using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchEnergyBalls : MonoBehaviour
{
    [SerializeField] private GameObject projPrefab = null;
    [SerializeField] private int numberOfProjectiles = 0;
    [SerializeField] private List<GameObject> prefabs = null;
    [SerializeField] private Transform startPoint = null;
    [SerializeField] private float radius = 0f;
    [SerializeField] private float moveSpeed = 0f;
    void Start()
    {
        for(int i = 0; i < numberOfProjectiles; i++)
        {
            GameObject prefab = Instantiate(projPrefab, startPoint.position, startPoint.rotation);
            prefab.transform.parent = this.gameObject.transform;
            prefab.SetActive(false);
            prefabs.Add(prefab);
        }
    }

    public void SpawnEnergyBalls()
    {
        float angleStep = 360f / numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i < prefabs.Count; i++) {
			
			float projectileDirXposition = startPoint.position.x + Mathf.Sin ((angle * Mathf.PI) / 180) * radius;
			float projectileDirYposition = startPoint.position.y + Mathf.Cos ((angle * Mathf.PI) / 180) * radius;

			Vector3 projectileVector = new Vector3 (projectileDirXposition, projectileDirYposition);
			Vector3 projectileMoveDirection = (projectileVector - startPoint.position).normalized * moveSpeed;

			GameObject proj = prefabs[i];
            proj.transform.position = startPoint.position;
            proj.SetActive(true);
			proj.GetComponent<Rigidbody2D> ().velocity = new Vector2 (projectileMoveDirection.x, projectileMoveDirection.y);

			angle += angleStep;
		}
    }
}
