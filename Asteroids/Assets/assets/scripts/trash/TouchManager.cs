using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TouchManager : MonoBehaviour
{
    [SerializeField] private GameObject lenkrakete = null;
    [SerializeField] private FollowTarget lenkraketeScript = null;
    [SerializeField] private GameObject infoText = null;
    [SerializeField] private int missileCounter = 3;
    [SerializeField] private TMP_Text missileCounterUI = null;
    [SerializeField] private Image lenkraketeUI = null;
    [SerializeField] private Sprite activeUI = null;
    [SerializeField] private Sprite inactive = null;
    SoundManager soundManager;

    private void Start() 
    {
        soundManager = SoundManager.sManagerInstance;
    }
    private void OnEnable() 
    {
        if(missileCounter > 0) {
            lenkraketeUI.sprite = activeUI;
            infoText.SetActive(true);
        }
    }
    void Update()
    {
        // if(Input.GetMouseButtonDown(0))
        // {
        //     RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, -Vector2.up);
        //     if(hit.collider != null)
        //     {
        //         Animator targetAnim = hit.collider.GetComponentInChildren<Animator>();
        //         if(targetAnim != null)
        //         {
        //             targetAnim.SetBool("Selected", true);
        //             Debug.Log("select");
        //         }
        //     }
        // }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && missileCounter > 0) 
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if(hit.collider != null && hit.collider.transform.tag == "Selectable") 
            {
                Animator targetAnim = hit.collider.transform.GetComponent<Animator>();
                if(targetAnim != null && targetAnim.GetBool("Selected") == false)
                {
                    targetAnim.SetBool("Selected", true);
                    lenkraketeScript.target = hit.collider.transform;
                    lenkrakete.SetActive(true);
                    missileCounter--;
                    missileCounterUI.text = missileCounter.ToString() + "x";
                }
            }
        }
    }

    private void OnDisable() 
    {
        lenkraketeUI.sprite = inactive;
        lenkrakete.SetActive(false);
    }

}
