using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;

public class Monster : MonoBehaviour
{
    [field: SerializeField] public MonsterData Data { get; private set; }  // �� �⺻ ������
   [field: SerializeField] public MonsterAnimation AnimationData { get; private set; }  // �� �⺻ ������

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public Attack attack { get; private set; }

    [Header("Wandering")]
    public float minWanderDistance; // �ּ� �����Ÿ�
    public float maxWanderDistance; // �ִ� �����Ÿ�
    public float MaxWanderTime; // ���� �ð�����
    private float waittimes = 0f;
    private bool reSet = true; // ���� ���� ����

    [Header("NAv")]
    private NavMeshAgent nmAgent; // �׺���̼�
    private Transform target; // Ÿ�� �� �÷��̾�
    public float lostDistance; // �߰� ���� �Ÿ�

    private MonsterStateMachine stateMachine;

    private void Awake()
    {
        AnimationData.Initialize();
        stateMachine = new MonsterStateMachine(this);
    }
    public enum State  // ����
    {
        IDLE,
        CHASE,
        ATTACK,
        Walk,
        KILLED
    }
    public State state;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        nmAgent = GetComponent<NavMeshAgent>();
        attack = GetComponent<Attack>();

        state = State.IDLE;
        StartCoroutine(StateMachine());
        stateMachine.ChangeStates(stateMachine.IdleState);
        //Debug.Log("0��");
    }

    IEnumerator StateMachine()
    {
        while (Data.HP > 0)
        {
            //Debug.Log("1��");
            yield return StartCoroutine(state.ToString());
        }
    }

    IEnumerator IDLE()
    {
        Animator.SetBool("Idle", true);
        Animator.SetBool("Run", false);
        Animator.SetBool("Attack", false);
        Animator.SetBool("Idle", false);
        Animator.SetBool("Walk", false);

        nmAgent.velocity = Vector3.zero;
        nmAgent.isStopped = true;
        // Debug.Log("����");
        // ���� animator �������� ���
        var curAnimStateInfo = Animator.GetCurrentAnimatorStateInfo(0);
        
        //// �ִϸ��̼� �̸��� IdleNormal �� �ƴϸ� Play
        //if (curAnimStateInfo.IsName("Z_Idle") == false)
        //    Animator.Play("Z_Idle", 0, 0);
        
        // ���Ͱ� Idle ������ �� �θ��� �Ÿ��� �ϴ� �ڵ�
        // 50% Ȯ���� ��/��� ���� ����
        int dir = Random.Range(0f, 1f) > 0.5f ? 1 : -1;
        //dir = 0;// �ӽ�

        // ȸ�� �ӵ� ����
        float lookSpeed = Random.Range(25f, 40f);

        // IdleNormal ��� �ð� ���� ���ƺ���
        for (float i = 0; i < curAnimStateInfo.length; i += Time.deltaTime)
        {
            transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y + (dir) * Time.deltaTime * lookSpeed, 0f);

            ChangeState(State.Walk);
            yield return null;
        }
    }

    IEnumerator CHASE() // ����
    {
        Animator.SetBool("Idle", false);
        Animator.SetBool("Run", true);
        Animator.SetBool("Attack", false);
        Animator.SetBool("Idle", false);
        Animator.SetBool("Walk", false);

        var curAnimStateInfo = Animator.GetCurrentAnimatorStateInfo(0);

        nmAgent.velocity = Vector3.zero;
        nmAgent.isStopped = false;
        //if (curAnimStateInfo.IsName("Z_Run_InPlace") == false)
        //{
        //    Animator.Play("Z_Run_InPlace", 0, 0);
        //    // SetDestination �� ���� �� frame�� �ѱ������ �ڵ�
        //    yield return null;
        //}

        // ��ǥ������ ���� �Ÿ��� ���ߴ� �������� �۰ų� ������
        if (nmAgent.remainingDistance <= nmAgent.stoppingDistance)
        {
            Animator.SetBool("Run", false);
            Animator.SetBool("Attack", true);
            // StateMachine �� �������� ����
            ChangeState(State.ATTACK);
        }
        // ��ǥ���� �Ÿ��� �־��� ���
        else if (nmAgent.remainingDistance > lostDistance)
        {
            Animator.SetBool("Idle", true);
            Animator.SetBool("Run", false);
            target = null;
            nmAgent.SetDestination(transform.position);
            yield return null;
            // StateMachine �� ���� ����
            ChangeState(State.IDLE);
        }
        else
        {
            // WalkFWD �ִϸ��̼��� �� ����Ŭ ���� ���
            yield return new WaitForSeconds(curAnimStateInfo.length);
        }
    }

    IEnumerator ATTACK()
    {
        //���� ����
        nmAgent.velocity = Vector3.zero;
        nmAgent.isStopped = true;
        
        Animator.SetBool("Idle", false);
        Animator.SetBool("Run", false);
        Animator.SetBool("Attack", true);
        Animator.SetBool("Idle", false);
        Animator.SetBool("Walk", false);

        // ���� �ִϸ��̼��� ���� �� Idle Battle �� �̵��ϱ� ������ 
        // �ڵ尡 �� ������ ���� ������ Attack01 �� Play
        //var curAnimStateInfo = Animator.GetCurrentAnimatorStateInfo(0);
        //Animator.Play("Z_Attack", 0, 0);

        // �Ÿ��� �־�����
        if (nmAgent.remainingDistance > nmAgent.stoppingDistance)
        {
            attack.RePosition();
            Animator.SetBool("Run", true);
            Animator.SetBool("Attack", false);
            // StateMachine�� �������� ����
            ChangeState(State.CHASE);
        }
        else
        {
            attack.RePosition();
            attack.damage();
            yield return new WaitForSeconds(4f);
        }
        // ���� animation �� �� �踸ŭ ���
        // �� ��� �ð��� �̿��� ���� ������ ������ �� ����.

        yield return null;
    }

    //����
    IEnumerator Walk()
    {
        //nmAgent.velocity = Vector3.zero;
        nmAgent.isStopped = false;

        Animator.SetBool("Idle", false);
        Animator.SetBool("Run", false);
        Animator.SetBool("Attack", false);
        Animator.SetBool("Idle", false);
        Animator.SetBool("Walk", true);

        if (nmAgent.remainingDistance > nmAgent.stoppingDistance)// ��ǥ �����ΰ�
        {
            reSet = false;
        }
        else
        {
            waittimes = 0f;
            reSet = true;
            yield return null;
            ChangeState(State.IDLE);
        }

        if (MaxWanderTime < (waittimes += Time.deltaTime)) // ���� �ð����� ������
        {
            waittimes = 0f;
            reSet = true;
            yield return null;
            ChangeState(State.IDLE);
        }

        if (reSet) // ���� �����ΰ�.
        {
            nmAgent.destination = GetWanderLocation();
            reSet = false;
            yield return null;
        }

        yield return null;
    }

    //�̵��Լ�
    Vector3 GetWanderLocation()
    {
        NavMeshHit hit;

        NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * Random.Range(minWanderDistance, maxWanderDistance)), out hit, maxWanderDistance, NavMesh.AllAreas);

        //int i = 0;
        //while (Vector3.Distance(transform.position, hit.position) < lostDistance)
        //{
        //    NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * Random.Range(minWanderDistance, maxWanderDistance)), out hit, maxWanderDistance, NavMesh.AllAreas);
        //    i++;
        //    if (i == 30)
        //        break;
        //}
        Debug.Log(hit.position);
        return hit.position;
    }

    IEnumerator KILLED()
    {
        yield return null;
    }

    void ChangeState(State newState)
    {
        state = newState;
    }

    //�÷��̾ ã�Ҵ�.
    public void Player_find(Collider other)
    {
        target = other.transform;
        nmAgent.SetDestination(target.position);
        // StateMachine�� �������� ����
        ChangeState(State.CHASE);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        // target �� null �� �ƴϸ� target �� ��� ����
        nmAgent.SetDestination(target.position);

    }

    // �ݶ��̴� �浹 ȿ�� �Ⱦ�
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.name != "player") return;
    //    // sphere collider �� player �� �����ϸ�      
    //    target = other.transform;
    //    // navmeshagent�� ��ǥ�� player �� ����
    //    nmAgent.SetDestination(target.position);
    //    // StateMachine�� �������� ����
    //    ChangeState(State.CHASE);
    //}
}
