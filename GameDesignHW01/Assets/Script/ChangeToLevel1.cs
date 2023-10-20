using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeToLevel1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //当带有“Player”标签的游戏对象碰到这个游戏对象时，加载第二个场景，代码可以是
        //SceneManager.LoadScene(1);
    }
    private void OnCollisionEnter(Collision collision)
    {
        // 检查碰撞到的游戏对象是否带有"Player"标签
        if (collision.gameObject.CompareTag("Player"))
        {
            // 加载第二个场景
            SceneManager.LoadScene("Level1"); // 替换成你的第二个场景的名称
        }
    }
}
