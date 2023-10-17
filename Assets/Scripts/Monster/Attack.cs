using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform model;
    public Transform body;
    private Collider targatCol;
    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RePosition()
    {
        Rigidbody.velocity = Vector3.zero;
        model.position = body.position;
    }

    public void damage()
    {
        targatCol.TryGetComponent(out PlayerConditions hp);
        Debug.Log("ÇÇ°¨¼Ò");
    }

    public void tagetColl(Collider other)
    {
        targatCol = other;
    }
}
