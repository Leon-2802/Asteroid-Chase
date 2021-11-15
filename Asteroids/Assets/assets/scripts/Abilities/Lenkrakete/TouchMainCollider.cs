using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMainCollider : MonoBehaviour
{
    [SerializeField] private TouchEvent touchEvent = null;

    private void OnMouseUpAsButton() {
        touchEvent.SetAsTarget();
    }
}
