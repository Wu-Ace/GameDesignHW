using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public float radius = 1.2f; // 随机生成物体的半径

    public void Drop()
    {
    //     UI_Inventory.inventory.RemoveItem(item);
    //     Vector3 randomDir = Random.insideUnitSphere * radius;
    //     Vector3 dropPosition = CharacterManager.player.transform.position + randomDir;
    //     dropPosition.y = CharacterManager.player.transform.position.y; // 确保生成位置的y坐标与中心物体的y坐标相同
    //     ItemWorld.SpawnItemWorld(dropPosition, item);
    }
}
