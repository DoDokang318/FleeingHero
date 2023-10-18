using UnityEngine;

public class MouseClickHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0은 마우스 왼쪽 버튼을 나타냅니다.
        {
            Debug.Log("마우스 왼쪽 버튼 클릭!");
            // 디버그 메시지를 원하는 내용으로 변경합니다.
        }
    }
}