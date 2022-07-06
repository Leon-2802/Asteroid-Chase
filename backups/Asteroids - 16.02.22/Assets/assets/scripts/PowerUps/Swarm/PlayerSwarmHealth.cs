using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwarmHealth : MonoBehaviour
{
    [SerializeField] private GameObject swarmparent = null;
    [SerializeField] private Enemy mainScript = null;

    void Update()
    {
        if(transform.position.y >= 14.4f || transform.position.y <= -12f || transform.position.x >= 19.4f || transform.position.x <= -23f)
            Die();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("target") || other.CompareTag("smolTarget") || other.CompareTag("enemy")
        || other.CompareTag("magnetic")) {
            Die();
        }
    }

    void Die() 
    {
        mainScript.gameObject.transform.parent = swarmparent.transform;
        mainScript.gameObject.SetActive(false);
    }
}
