using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Item 
{
    public enum ItemType
    {
        Gun,
        Bandage,

    }
    public Sprite GetSprite() {
        // Debug.Log("GetSprite()");
        switch (itemType) {
            default:
            case ItemType.Gun:        return ItemAssets.Instance.gunSprite;
            case ItemType.Bandage:    return ItemAssets.Instance.bandageSprite;

        } //这一段是用来获取物品的图片的，比如说我们捡到了一个子弹，那么就会返回一个子弹的图片，switch语句的意思是，如果itemType是Gun，那么就返回ItemAssets.Instance.gunSprite，如果是Bandage，那么就返回ItemAssets.Instance.bandageSprite
        
    }
    public bool IsStackable() {
        switch (itemType) {
            default:
            case ItemType.Bandage:
                return true;
            case ItemType.Gun:
                return false;
        }
    }
    public ItemType itemType;
    public int amount;//amount是用来记录物品的数量的，比如说子弹，一次捡到的子弹数量是30，那么amount就是30
}
