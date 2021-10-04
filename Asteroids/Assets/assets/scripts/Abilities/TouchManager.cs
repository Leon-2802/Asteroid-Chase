using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    [SerializeField] private GameObject lenkrakete = null;
    [SerializeField] private FollowTarget lenkraketeScript = null;
    SoundManager soundManager;

    private void Start() 
    {
        soundManager = SoundManager.sManagerInstance;
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

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if(hit.collider != null && hit.collider.transform.tag == "Selectable") 
            {
                Animator targetAnim = hit.collider.GetComponentInChildren<Animator>();
                if(targetAnim != null && targetAnim.GetBool("Selected") == false)
                {
                    targetAnim.SetBool("Selected", true);
                    lenkraketeScript.target = hit.collider.transform;
                    lenkrakete.SetActive(true);
                }
            }
        }
    }
}
