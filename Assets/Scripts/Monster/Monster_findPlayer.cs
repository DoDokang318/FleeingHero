using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster_findPlayer : MonoBehaviour
{
    //[SerializeField] float m_angle = 0f;
    //[SerializeField] float m_distance = 0f;
    //[SerializeField] LayerMask m_layerMask = 0;


    [SerializeField] bool DebugMode = true;
    [Range(0f, 360f)][SerializeField] float ViewAngle = 0f;
    [SerializeField] float ViewRadius = 1f;
    [SerializeField] LayerMask TargetMask;
    [SerializeField] LayerMask ObstacleMask;
    
    List<Collider> hitTargetList = new List<Collider>();

    public Monster monster { get; private set; }
    public Attack attack { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<Monster>();
        attack = GetComponent<Attack>();
    }

    // Update is called once per frame
    void Update()
    {
        Sight();
    }

    void Sight()
    {

    }

    private void OnDrawGizmos()
    {
        if (!DebugMode) return;
        Vector3 myPos = transform.position + Vector3.up * 0.5f;

        float lookingAngle = transform.eulerAngles.y;  //캐릭터가 바라보는 방향의 각도
        Vector3 rightDir = AngleToDir(transform.eulerAngles.y + ViewAngle * 0.5f);
        Vector3 leftDir = AngleToDir(transform.eulerAngles.y - ViewAngle * 0.5f);
        Vector3 lookDir = AngleToDir(lookingAngle);

        Debug.DrawRay(myPos, rightDir * ViewRadius, Color.blue);
        Debug.DrawRay(myPos, leftDir * ViewRadius, Color.blue);
        Debug.DrawRay(myPos, lookDir * ViewRadius, Color.cyan);

        hitTargetList.Clear();
        Collider[] Targets = Physics.OverlapSphere(myPos, ViewRadius, TargetMask);

        if (Targets.Length == 0) return;
        foreach (Collider EnemyColli in Targets)
        {
            Vector3 targetPos = EnemyColli.transform.position;
            Vector3 targetDir = (targetPos - myPos).normalized;
            float targetAngle = Mathf.Acos(Vector3.Dot(lookDir, targetDir)) * Mathf.Rad2Deg;
            if (targetAngle <= ViewAngle * 0.5f && !Physics.Raycast(myPos, targetDir, ViewRadius, ObstacleMask))
            {
                hitTargetList.Add(EnemyColli);
                if (DebugMode) Debug.DrawLine(myPos, targetPos, Color.red);
                attack.tagetColl(EnemyColli);
                monster.Player_find(EnemyColli);
            }
        }

        Gizmos.DrawWireSphere(myPos, ViewRadius);
    }

    Vector3 AngleToDir(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), 0f, Mathf.Cos(radian));
    }

    //void Sight()
    //{
    //    Collider[] t_cols = Physics.OverlapSphere(transform.position, m_distance, m_layerMask);

    //    if(t_cols.Length > 0 )
    //    {
    //        Transform t_tfPlayer = t_cols[0].transform;

    //        Vector3 t_direction = (t_tfPlayer.position - transform.position).normalized;
    //        float t_angle = Vector3.Angle(t_direction, transform.forward);

    //        if(t_angle<m_angle * 0.5f)
    //        {
    //            if (Physics.Raycast(transform.forward, t_direction, out RaycastHit t_hit, m_distance))
    //            {
    //                Debug.Log("3번");
    //                if (t_hit.transform.tag == "Player")
    //                {
    //                    Debug.Log("4번");
    //                    monster.Player_find(t_tfPlayer);
    //                }
    //            }
    //        }
    //    }
    //}
}
