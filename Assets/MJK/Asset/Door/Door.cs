using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : OnRaycast
{
    [SerializeField] private float openAngle;
    [SerializeField] private float closeAngle;

    [SerializeField] private float speed;
    [SerializeField] Collider col;

    public bool isOpen;
    Quaternion newRotation;

    private void Update () {
        if(isOpen) {
            newRotation = Quaternion.Euler(transform.localRotation.x, openAngle, transform.localRotation.y);
        } else {
            newRotation = Quaternion.Euler(transform.localRotation.x, closeAngle, transform.localRotation.y);
        }

        col.enabled = transform.localRotation == newRotation;

        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, newRotation, speed);
    }

    public override void OnUseItem () {
        removeRequirement();
    }

    public override void OnInteract () {
        isOpen = !isOpen;
    }
}
