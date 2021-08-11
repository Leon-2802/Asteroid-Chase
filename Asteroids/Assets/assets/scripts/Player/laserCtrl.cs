using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserCtrl : MonoBehaviour
{
    [SerializeField] protected string objectTag = null;
    protected MeteorPooler meteorPooler;
    [SerializeField] protected float speed = 55f;
    [SerializeField] protected float lifetime = 5f;
    public float currentLifetime;
    public bool noHit = true;

    private void Start() {
        meteorPooler = MeteorPooler.Instance;
        currentLifetime = lifetime;
        noHit = true;
    }
    private void OnEnable() {
        currentLifetime = lifetime;
        noHit = true;
    }
    protected virtual void Update()
    {
        if(noHit == true) {
            Vector3 newPosition = transform.position;
            newPosition += transform.up * speed * Time.deltaTime;
            transform.position = newPosition;
        }

        if(transform.position.y >= 14.4f || transform.position.y <= -12f || transform.position.x >= 19.4f || transform.position.x <= -23f) {
            meteorPooler.ObjectDestroyed(objectTag);
            this.gameObject.SetActive(false);
        }

        currentLifetime -= Time.deltaTime;

        if(currentLifetime <= 0f) {
            meteorPooler.ObjectDestroyed(objectTag);
            this.gameObject.SetActive(false);
        }
    }
}
