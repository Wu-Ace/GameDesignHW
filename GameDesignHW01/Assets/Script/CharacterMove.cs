using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    // Start is called before the first frame update
    public static CharacterMove instance;
    public Text sceneCountText;
    
    void Start()
    {
        // sceneCountText = GameObject.Find("Player/UI/Canvas/Text").GetComponent<Text>();
        // if (sceneCountText == null)
        // {
        //     Debug.LogError("Text component not found or not properly assigned!");
        // }
        // void Start()
        // {
        //     Debug.Log("CharacterMove Start");
        //     // ...
        // }
    }
 
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CharacterManager.instance.CharacterMove();
        CharacterManager.instance.UpdateSceneCountText(sceneCountText);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SceneTrigger"))
        {
            // 处理场景切换逻辑

            // 调用CharacterManager的UpdateSceneCountText方法更新UI文本
            CharacterManager.instance.UpdateSceneCountText(sceneCountText);
        }
    }
}