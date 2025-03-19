using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    public float deleteTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        // deleteTime이 지나면 스스로 파괴
        Destroy(this.gameObject, deleteTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 누군가하고 부딛치면 즉시 자폭
        Destroy(this.gameObject);
    }
}
