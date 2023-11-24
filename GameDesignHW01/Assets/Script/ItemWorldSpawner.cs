using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour {

    public Item item;

    private void Start() {
        // Debug.Log(item);
        ItemWorld.SpawnItemWorld(transform.position, item);//这个transform.position是指这个脚本所在的物体的位置
        // Debug.Log("ItemWorldSpawner");
        Destroy(this.gameObject);
    }

}
