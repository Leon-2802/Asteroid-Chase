using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorMovement : MonoBehaviour
{
    meteorManager meteorManager;
    [SerializeField] private float speed = 1f;
    public float xValue = 2f;
    public float yValue = 1f;
    public string spawnPos;
    [SerializeField] private float[] xValuesPos = {0.7f, 1.3f, 1f, 2f};
     [SerializeField] private float[] xValuesNeg = {-0.7f, -1.3f, -1f, -2f};
    [SerializeField] private float[] yValuesPos = {0.7f, 1.3f, 1f, 2f, 3f, 1.5f};
    [SerializeField] private float[] yValuesNeg = {-0.7f, -1.3f, -1f, -2f, -3f, -1.5f};
    Vector3 initialPos;

    private void Start() {
        meteorManager = GameObject.FindWithTag("meteorManager").GetComponent<meteorManager>();
    }
    public void OnEnable() 
    {
        initialPos = transform.position;
        float indexX = Random.Range(0, xValuesPos.Length);
        float indexY = Random.Range(0, xValuesPos.Length);
        
        if(initialPos.y > 0)
            yValue = yValuesNeg[(int)indexY];
        else
            yValue = yValuesPos[(int)indexY];

        if(initialPos.x > 0)
            xValue = xValuesNeg[(int)indexX];
        else
            xValue = xValuesPos[(int)indexX];
    }

    void Update()
    {
        Vector3 newPos = transform.position;
        newPos += new Vector3(xValue, yValue) * speed * Time.deltaTime;
        transform.position = newPos;

        if(transform.position.y >= 14.4f || transform.position.y <= -12f || transform.position.x >= 19.4f || transform.position.x <= -23f) 
            relocate();
    }

    void relocate() {
        meteorManager.spawnMeteor();
        this.gameObject.SetActive(false);
    }
}
