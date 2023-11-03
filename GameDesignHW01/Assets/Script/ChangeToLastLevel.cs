using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeToLastLevel : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        // 检查碰撞到的游戏对象是否带有"Player"标签
        if (collision.gameObject.CompareTag("Player"))
        {
            // 加载第二个场景
            MySceneManager.instance.LoadLastScene(); // 替换成你的第二个场景的名称
        }
    }
}
