using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading;
using static UnityEngine.GraphicsBuffer;

public class Monster : MonoBehaviour
{
    [field: SerializeField] public MonsterData Data { get; private set; }  // 적 기본 데이터
   [field: SerializeField] public MonsterAnimation AnimationData { get; private set; }  // 적 기본 데이터

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public Attack attack { get; private set; }

    private NavMeshAgent nmAgent; // 네비게이션
    private Transform target; // 타겟 즉 플레이어
    public float lostDistance; // 추격 중지 거리

    private MonsterStateMachine stateMachine;

    private void Awake()
    {
        AnimationData.Initialize();
        stateMachine = new MonsterStateMachine(this);
    }
    public enum State  // 상태
    {
        IDLE,
        CHASE,
        ATTACK,
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
        //Debug.Log("0번");
    }

    IEnumerator StateMachine()
    {
        while (Data.HP > 0)
        {
            //Debug.Log("1번");
            yield return StartCoroutine(state.ToString());
        }
    }

    IEnumerator IDLE()
    {
        Animator.SetBool("Idle", true);
        Animator.SetBool("Run", false);
        Animator.SetBool("Attack", false);
        Animator.SetBool("Idle", false);

        nmAgent.velocity = Vector3.zero;
        nmAgent.isStopped = true;
        // Debug.Log("정지");
        // 현재 animator 상태정보 얻기
        var curAnimStateInfo = Animator.GetCurrentAnimatorStateInfo(0);
        
        //// 애니메이션 이름이 IdleNormal 이 아니면 Play
        //if (curAnimStateInfo.IsName("Z_Idle") == false)
        //    Animator.Play("Z_Idle", 0, 0);
        
        // 몬스터가 Idle 상태일 때 두리번 거리게 하는 코드
        // 50% 확률로 좌/우로 돌아 보기
        int dir = Random.Range(0f, 1f) > 0.5f ? 1 : -1;
        //dir = 0;// 임시

        // 회전 속도 설정
        float lookSpeed = Random.Range(25f, 40f);

        // IdleNormal 재생 시간 동안 돌아보기
        for (float i = 0; i < curAnimStateInfo.length; i += Time.deltaTime)
        {
            transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y + (dir) * Time.deltaTime * lookSpeed, 0f);

            yield return null;
        }
    }

    IEnumerator CHASE() // 수정
    {
        var curAnimStateInfo = Animator.GetCurrentAnimatorStateInfo(0);

        Animator.SetBool("Idle", false);
        Animator.SetBool("Run", true);
        Animator.SetBool("Attack", false);
        Animator.SetBool("Idle", false);

        nmAgent.velocity = Vector3.zero;
        nmAgent.isStopped = false;
        //if (curAnimStateInfo.IsName("Z_Run_InPlace") == false)
        //{
        //    Animator.Play("Z_Run_InPlace", 0, 0);
        //    // SetDestination 을 위해 한 frame을 넘기기위한 코드
        //    yield return null;
        //}

        // 목표까지의 남은 거리가 멈추는 지점보다 작거나 같으면
        if (nmAgent.remainingDistance <= nmAgent.stoppingDistance)
        {
            Animator.SetBool("Run", false);
            Animator.SetBool("Attack", true);
            // StateMachine 을 공격으로 변경
            ChangeState(State.ATTACK);
        }
        // 목표와의 거리가 멀어진 경우
        else if (nmAgent.remainingDistance > lostDistance)
        {
            Animator.SetBool("Idle", true);
            Animator.SetBool("Run", false);
            target = null;
            nmAgent.SetDestination(transform.position);
            yield return null;
            // StateMachine 을 대기로 변경
            ChangeState(State.IDLE);
        }
        else
        {
            // WalkFWD 애니메이션의 한 사이클 동안 대기
            yield return new WaitForSeconds(curAnimStateInfo.length);
        }
    }

    IEnumerator ATTACK()
    {
        //가속 제거
        nmAgent.velocity = Vector3.zero;
        nmAgent.isStopped = true;
        
        Animator.SetBool("Idle", false);
        Animator.SetBool("Run", false);
        Animator.SetBool("Attack", true);
        Animator.SetBool("Idle", false);

        // 공격 애니메이션은 공격 후 Idle Battle 로 이동하기 때문에 
        // 코드가 이 지점에 오면 무조건 Attack01 을 Play
        //var curAnimStateInfo = Animator.GetCurrentAnimatorStateInfo(0);
        //Animator.Play("Z_Attack", 0, 0);

        // 거리가 멀어지면
        if (nmAgent.remainingDistance > nmAgent.stoppingDistance)
        {
            attack.RePosition();
            Animator.SetBool("Run", true);
            Animator.SetBool("Attack", false);
            // StateMachine을 추적으로 변경
            ChangeState(State.CHASE);
        }
        else
        {
            attack.RePosition();
            attack.damage();
            yield return new WaitForSeconds(4f);
        }
        // 공격 animation 의 두 배만큼 대기
        // 이 대기 시간을 이용해 공격 간격을 조절할 수 있음.

        yield return null;
    }

    IEnumerator KILLED()
    {
        yield return null;
    }

    void ChangeState(State newState)
    {
        state = newState;
    }

    //플레이어를 찾았다.
    public void Player_find(Collider other)
    {
        target = other.transform;
        nmAgent.SetDestination(target.position);
        // StateMachine을 추적으로 변경
        ChangeState(State.CHASE);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        // target 이 null 이 아니면 target 을 계속 추적
        nmAgent.SetDestination(target.position);

    }

    // 콜라이더 충돌 효과 안씀
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.name != "player") return;
    //    // sphere collider 가 player 를 감지하면      
    //    target = other.transform;
    //    // navmeshagent의 목표를 player 로 설정
    //    nmAgent.SetDestination(target.position);
    //    // StateMachine을 추적으로 변경
    //    ChangeState(State.CHASE);
    //}
}
