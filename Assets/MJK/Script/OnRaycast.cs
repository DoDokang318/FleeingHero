using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRaycast : MonoBehaviour
{
    public DataItem requirementItem;

    public virtual void OnInteract()
    {

    }
    public virtual void OnUseItem()
    {

    }
    public void removeRequirement()
    {
        requirementItem = null;
    }
}
