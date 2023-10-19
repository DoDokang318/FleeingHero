using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{


    private Animator animator;

    private readonly int Walk = Animator.StringToHash("FlashWalk");
    private readonly int Run = Animator.StringToHash("FlashRun");
    [Header("Movement")]
    public float moveSpeed;
    public float RunSpeed;
    private Vector2 curMovementInput;
    public float jumpForce;
    public LayerMask groundLayerMask;
    public bool IsRun;
    public bool IsStamina;
     Vector3 startScale = new Vector3(1f, 0.5f, 1f); // 시작 스케일
     Vector3 endScale  = new Vector3(1f,1f,1f);   // 앉았을 때의 목표 스케일
    public float SitTime = 0.2f;
    private bool isJumping = false;

    [Header("Look")]

    public Transform cameraContainer;
 
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;
    private Vector2 mouseDelta;






    [HideInInspector]
    public bool canLook = true;

    private Rigidbody _rigidbody;

    public static PlayerController instance;

    [Header("flashlight")]

    [SerializeField]
    GameObject FlashlightLight;
    bool FlashLightActive = false;
    [Header("Audio")]
    public AudioManagers audioManagers;

    public GameObject StaMinauiBar;

    private void Awake()
    {
        instance = this;
        _rigidbody = GetComponent<Rigidbody>();
     

        

    }
    void Start()
    {
        FlashlightLight.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; //커서 없에기
    }

    // Update is called once per frame
    private void FixedUpdate()  //물리적인작업 
    {
        Move();
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        if(IsRun == true&&IsStamina == true)
        {
            dir = moveSpeed*RunSpeed*dir;
            //animator.SetBool(Run, false);
            if (Math.Abs(dir.x) > 0.1 || Math.Abs(dir.z) > 0.1)
            {
                StaMinauiBar.SetActive(true);
            }
        }
        else  if(IsRun == false || IsStamina == false )
        {
            dir *= moveSpeed;
            //animator.SetBool(Walk, false);
            if (Math.Abs(dir.x) > 0.1 || Math.Abs(dir.z) > 0.1)
            {
                StaMinauiBar.SetActive(false);
                
                if (!audioManagers.sfxPlayer.isPlaying && !isJumping)
                {
                    //이동만 하면 이동만 소리
                    audioManagers.PlaySound(3);
                }
                else if (!audioManagers.sfxPlayer.isPlaying && isJumping)
                {
                    //이동하면서 점프하면 둘다 소리
                    audioManagers.PlaySound(3);
                    audioManagers.PlaySound(4);
                }
                

            }
        }
        else if(!IsRun && !IsStamina)
        {
            dir *= 0;
            if (audioManagers.sfxPlayer.isPlaying && !isJumping)
            {
                //멈춤 상태에서 점프도 아니면 다 멈춤
                audioManagers.sfxPlayer.Stop();           
            }
            else if(!audioManagers.sfxPlayer.isPlaying && isJumping)
            {
                audioManagers.PlaySound(4);
            }
        }
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
    
    }

    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);//마우스 를상하로 움직이는거에따라서 움직이게해주는것
        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
      
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
            //animator.SetBool(Walk, false);
            //animator.SetBool(Run, false);
        }
    }


    public void OnRunInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            IsRun = true;

        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            IsRun = false;          
        }

    }
    public void SitdownInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            moveSpeed /= 2; // 이동 속도를 줄이는 예
            StartCoroutine(ScaleOverTime(startScale, SitTime)); // 스케일을 endScale로 부드럽게 변경
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            moveSpeed *= 2; // 이동 속도를 다시 복구하는 예
            StartCoroutine(ScaleOverTime(endScale, SitTime)); // 스케일을 startScale로 부드럽게 변경
        }

    }

    private IEnumerator ScaleOverTime(Vector3 targetScale, float duration)
    {
        Vector3 initialScale = transform.localScale;
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            yield return null;
        }

        // 스케일 설정을 완료한 후 정확한 값을 설정
        transform.localScale = targetScale;
    }

    public void OnFlashput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if(FlashLightActive == false)
            {
                FlashlightLight.gameObject.SetActive(true);
                FlashLightActive = true;
            }
            else 
            {
                FlashlightLight.gameObject.SetActive(false);
                FlashLightActive = false;
            }
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (IsGrounded())
            {
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse); // Impulse 는 질량을 가지고서 처이를 한다는 뜻이다 
                isJumping = true;
                Debug.Log("점프 중" + isJumping);
            }
        }

    }

    private bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (Vector3.up * 0.01f) , Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f)+ (Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
        };


        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.01f, groundLayerMask))
            {

                return true;
            }

        }
        isJumping = false;
        Debug.Log("착지" + isJumping);
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + (transform.forward * 0.2f), Vector3.down);
        Gizmos.DrawRay(transform.position + (-transform.forward * 0.2f), Vector3.down);
        Gizmos.DrawRay(transform.position + (transform.right * 0.2f), Vector3.down);
        Gizmos.DrawRay(transform.position + (-transform.right * 0.2f), Vector3.down);
    }

    public void ToggleCursor(bool toggle)
    {
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canLook = !toggle;
    }
}
