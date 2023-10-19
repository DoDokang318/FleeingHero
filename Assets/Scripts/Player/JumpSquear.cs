using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSquear : MonoBehaviour
{
    [SerializeField] private GameObject[] JumpSquearObj;

    public float OnWaitTime;
 



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {      
            StartCoroutine(JumpSquearActive());
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }

    IEnumerator JumpSquearActive()
    {
        yield return new WaitForSeconds(OnWaitTime);
        for (int i = 0; i < JumpSquearObj.Length; i++)
        {
            JumpSquearObj[i].SetActive(true);
            AudioManagers.I.PlaySound(7);
        }
        

    }
}
