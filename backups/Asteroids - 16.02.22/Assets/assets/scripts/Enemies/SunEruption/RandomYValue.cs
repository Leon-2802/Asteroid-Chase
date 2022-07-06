using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomYValue : MonoBehaviour
{
    [SerializeField] private float[] yValues = null;
    void OnEnable()
    {
        int index = UnityEngine.Random.Range(0, yValues.Length);
        transform.position = new Vector3(transform.position.x, yValues[index], 0);
    }
}
