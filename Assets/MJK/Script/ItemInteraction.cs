using UnityEngine;
using TMPro;

public class ItemInteraction : MonoBehaviour
{
    public TextMeshProUGUI itemUIText;
    public TextMeshProUGUI itemCountText;

    private int itemCount = 0;
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
        if (isNearPlayer)
        {
            itemUIText.text = "Press E to pick up item";
        }
    }

    public void UpdateItemCount()
    {
        itemCount++;
        itemCountText.text = itemCount + " / 3";
        if (itemCount >= 3)
        {
            // 만약 아이템 카운트가 3 이상이면 추가 동작을 수행하도록 설정할 수 있습니다.
        }
    }
}