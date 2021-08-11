using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFlames : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb = null;
    [SerializeField] private GameObject emmissionRight = null;
    [SerializeField] private GameObject emmissionLeft = null;
    private Vector2 zero = new Vector2(0, 0);

    void Update()
    {
        if(playerRb.velocity != zero) {
            emmissionRight.SetActive(true);
            emmissionLeft.SetActive(true);
        }
        else {
            emmissionRight.SetActive(false);
            emmissionLeft.SetActive(false);
        }
    }
}
