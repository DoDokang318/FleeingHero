using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemTrigger : OnRaycast
{
    public DataItem GetItem;
    ItemInteraction itemInteraction;

    private void Awake()
    {
        itemInteraction = FindObjectOfType<ItemInteraction>();
    }

    public override void OnInteract()
    {
        base.OnInteract();
        Inventory inventory = FindObjectOfType<Inventory>();
        inventory.AddItem(GetItem);

        if (itemInteraction != null)
        {
            itemInteraction.UpdateItemCount(); // 아이템을 획득할 때 아이템 카운트 업데이트
            itemInteraction.itemUIText.gameObject.SetActive(false);
        }

        Destroy(this.gameObject);
    }
}