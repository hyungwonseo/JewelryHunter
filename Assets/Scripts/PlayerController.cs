using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    float axisH = 0.0f;
    public float velocity = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
        //Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update() // 1/60초 (약 0.016초)
    {
        //Debug.Log(Time.deltaTime);
        axisH = Input.GetAxisRaw("Horizontal");
        if (axisH > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }     
        else if (axisH < 0.0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    private void FixedUpdate() // 0.02초
    {
        //Debug.Log(Time.fixedDeltaTime);
        rbody.velocity = new Vector2(axisH*velocity, rbody.velocity.y);
        
    }
}
