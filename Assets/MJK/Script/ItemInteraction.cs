using UnityEngine;
using TMPro;

public class ItemInteraction : MonoBehaviour
{
    public TextMeshProUGUI itemUIText;
    private bool isNearPlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearPlayer = true;
            itemUIText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearPlayer = false;
            itemUIText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // 아이템 근처에 플레이어가 있을 때 추가 동작을 수행하거나 상호작용 로직을 구현할 수 있습니다.
        if (isNearPlayer)
        {
            // UI 텍스트를 업데이트하거나 다른 동작을 수행
            itemUIText.text = "Press E to pick up item"; // 텍스트 업데이트 예시
        }
    }
}
