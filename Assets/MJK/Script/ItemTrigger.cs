using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : OnRaycast
{
    public DataItem GetItem;

    public override void OnInteract()
    {
        base.OnInteract();
        Inventory inventory = FindObjectOfType<Inventory>();
        inventory.AddItem(GetItem);

        Destroy(this.gameObject);
    }
}
