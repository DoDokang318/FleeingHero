using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform model;
    public Transform body;
    private Collider targatCol;
    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }

    public MonsterData Data { get; private set; }
    [SerializeField] private Collider myCollider;

    private List<Collider> alreadyColliderWith = new List<Collider>();
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
        if (targatCol == null) return;
        if (targatCol == myCollider) return;
        if (alreadyColliderWith.Contains(targatCol)) return;

        alreadyColliderWith.Add(targatCol);

        if (targatCol.TryGetComponent(out PlayerConditions curValue))
        {
            curValue.TakePhysicalDamage(30);
            Debug.Log(curValue.health.curValue+"ÇÇ°¨¼Ò");
            alreadyColliderWith.Remove(targatCol);
        }
    }

    public void tagetColl(Collider other)
    {
        targatCol = other;
    }
}
