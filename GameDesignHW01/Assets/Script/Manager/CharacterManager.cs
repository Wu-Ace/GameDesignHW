using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
public class CharacterManager : MonoBehaviour
{
    // Singleton
    public static CharacterManager instance;

    // CharacterMove
    private Rigidbody rb;
    private Vector3 moveDirection;
    public static Vector3 movement;
    public AudioClip footstepAudio;
    private string currentSceneName;
    public static GameObject player;
    private Text sceneCountText; // 用于显示切换场景次数的文本
    private bool isFirstTrigger = true; // 添加一个标志以判断是否是第一次触发
    public static Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;//这个是用来设置背包的，因为我们在InventoryManager中要用到这个类，所以要先设置
    public GameObject Player;
    public static Vector3 PlayerPosition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody>();

        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        currentSceneName = SceneManager.GetActiveScene().name;

    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        // rb = player.GetComponent<Rigidbody>();

        // 在玩家头上查找并获取Text组件
        sceneCountText = player.GetComponentInChildren<Text>();
        if (sceneCountText == null)
        {
            Debug.LogError("Text component not found on player's child object!");
        }

        sceneCountText.text = "Switch Count: " + MySceneManager.instance.SwitchSceneNumber.ToString();
    }

    public void Update()
    {
        // player = GameObject.FindWithTag("Player");
        // rb = player.GetComponent<Rigidbody>();
        // sceneCountText = player.GetComponentInChildren<Text>();
        PlayerPosition = player.transform.position;
        // Debug.Log(PlayerPosition);
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     Debug.Log("Inventory Set!");
        // }
        string activeSceneName = SceneManager.GetActiveScene().name;
        if (activeSceneName != currentSceneName)
        {
            // 场景已经改变
            currentSceneName = activeSceneName;
            uiInventory.SetInventory(inventory);
            uiInventory.RefreshInventoryItems();
        }
    }

    

    public void CharacterMove()
    {
        float moveSpeed = 5f;

        // 检测玩家输入并设置移动方向
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        // 根据移动方向设置速度
        movement = moveDirection * moveSpeed;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // 播放脚步声音效
        if (movement.magnitude > 0.1f && !SoundManager.instance.footstepAudio.isPlaying)
        {
            SoundManager.instance.Playsound(footstepAudio);
        }
        else if (movement.magnitude < 0.1f)
        {
            SoundManager.instance.Stopsound(footstepAudio);
        }
    }

    public void UpdateSceneCountText(Text sceneCountText)
    {
        if (sceneCountText != null)
        {
            if (isFirstTrigger) // 如果是第一次触发，将计数设置为1
            {
                MySceneManager.instance.SwitchSceneNumber = 0;
                isFirstTrigger = false; // 将标志设置为false，以后的触发不再执行该分支
            }

            sceneCountText.text = "Switch Count: " + MySceneManager.instance.SwitchSceneNumber.ToString() +" "+CharacterController.instance.currentState.ToString();
        }
        else
        {
            Debug.LogError("Text component not found or not properly assigned!");
        }
    }
}