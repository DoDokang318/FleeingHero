using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            itemInteraction.itemUIText.gameObject.SetActive(false);
        }

        Destroy(this.gameObject);
    }
}
