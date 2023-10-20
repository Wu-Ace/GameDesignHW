using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMove : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDirection;
    public AudioSource footstepAudio;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
     private void Awake()
     {
        DontDestroyOnLoad(this.gameObject);
     }
    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 5f;

        // 检测玩家输入并设置移动方向
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        // 根据移动方向设置速度
        Vector3 movement = moveDirection * moveSpeed;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        if (movement.magnitude > 0.1f && !footstepAudio.isPlaying)
        {
            footstepAudio.Play();
        }
        else if (movement.magnitude < 0.1f)
        {
            footstepAudio.Stop();
        }
    }
}