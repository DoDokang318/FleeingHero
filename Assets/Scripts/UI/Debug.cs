using UnityEngine;

public class MouseClickHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0�� ���콺 ���� ��ư�� ��Ÿ���ϴ�.
        {
            Debug.Log("���콺 ���� ��ư Ŭ��!");
            // ����� �޽����� ���ϴ� �������� �����մϴ�.
        }
    }
}