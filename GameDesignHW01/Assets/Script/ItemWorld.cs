using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CodeMonkey.Utils;
using UnityEditor;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item) {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }//这段代码意思是
    
    public static void  DropItem(Vector3 dropPosition, Item item) {
        // Vector3 randomDir = UtilsClass.GetRandomDir();
        SpawnItemWorld(dropPosition , item);
        // itemWorld.GetComponent<Rigidbody>().AddForce(randomDir * 5f, ForceMode.Impulse);
        
    }
    
    private Item item;
    private SpriteRenderer spriteRenderer;
    public TextMeshProUGUI textMeshPro;
    public static float radius = 1.2f; 

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();//这个代码被挂载在
    }
    

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        if (item.amount > 1) {
            textMeshPro.SetText(item.amount.ToString());
        } else {
            textMeshPro.SetText("");
        }

    }
    public Item GetItem() {
        return item;
    }
    public void DestroySelf() {
        Destroy(gameObject);
    }

    public static void DropItem(Item item,Inventory inventory)
    {// Drop item
            Item duplicateItem = new Item { itemType = item.itemType, amount = item.amount };
            inventory.RemoveItem(item);
            Debug.Log("RightClick!");
            
            Vector3 spawnPosition = CharacterManager.player.transform.position + Random.insideUnitSphere * radius;
            spawnPosition.y = CharacterManager.player.transform.position.y;// 确保生成位置的y坐标与中心物体的y坐标相同
            ItemWorld.SpawnItemWorld(spawnPosition , duplicateItem);
        }
    }

