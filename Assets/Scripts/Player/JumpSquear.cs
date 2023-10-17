using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSquear : MonoBehaviour
{
    [SerializeField] private GameObject[] Img;

    public float WaitTime = 1.0f;
    public int randnum;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("충돌");
            StartCoroutine(RandomImg());
        }
    }

    IEnumerator RandomImg()
    {
        Debug.Log("시작");
        randnum = Random.Range(0, Img.Length);
        Img[0].SetActive(true);
        yield return new WaitForSeconds(WaitTime);
        Img[randnum].SetActive(false);
        this.gameObject.SetActive(false); // 게임 오브젝트 비활성화는 코루틴이 완료된 후에 실행
    }
}
