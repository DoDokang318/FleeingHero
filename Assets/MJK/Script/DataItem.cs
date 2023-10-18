using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Data Item", menuName = "Inventory/Data Item", order = 1)]
public class DataItem : ScriptableObject
{
    public Item item;
}
