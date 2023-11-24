using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory: MonoBehaviour
{
    public static Inventory instance;
    public event EventHandler OnItemListChanged;//这是一个事件，当物品列表发生变化的时候，就会触发这个事件
    private List<Item> itemList;
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
    }
    public Inventory()
    {
        itemList = new List<Item>();
        
        // Debug.Log(itemList.Count);
        // foreach (Item item in itemList) //遍历itemList
        // {
        //     Debug.Log(item.itemType); //输出每个元素的值
        // }
        
    }//这是用来初始化的，因为我们在InventoryManager中要用到这个类，所以要先初始化
    
    public void AddItem(Item item)
    {
        // Debug.Log("Item added!");
        if (item.IsStackable()) {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList) {
                if (inventoryItem.itemType == item.itemType) {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory) {
                itemList.Add(item);
            }
        } else {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }//这是用来添加物品的，比如说我们捡到了一个子弹，那么就可以调用这个函数，把子弹添加到背包中
    public List<Item> GetItemList()
    {
        return itemList;
    }//这是用来获取背包中的物品列表的
    public void RemoveItem(Item item) {
        if (item.IsStackable()) {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList) {
                if (inventoryItem.itemType == item.itemType) {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0) {
                itemList.Remove(itemInInventory);
            }
        } else {
            itemList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
}
