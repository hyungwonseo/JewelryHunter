using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBlock : MonoBehaviour
{
    public float length = 0.0f; // 이 길이안에 플레이어가 들어오면 낙하시킴
    public float distance = 0.0f; // 현재 플레이어와의 실시간 거리
    bool isFell = false;
    Rigidbody2D rbody;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.bodyType = RigidbodyType2D.Kinematic;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // 플레이어와의 distance 계산
            Vector2 diff = this.transform.position - player.transform.position;
            //distance = Mathf.Sqrt((diff.x * diff.x) + (diff.y * diff.y));
            //if (distance <= length)
            distance = (diff.x * diff.x) + (diff.y * diff.y);
            if (distance <= (length*length)) // 이 경우에는 제곱끼리 비교하는것이 더 좋다
            {
                rbody.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
