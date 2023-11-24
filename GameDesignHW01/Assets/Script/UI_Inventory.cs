using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
   private Inventory inventory_1;
   public Transform itemSlotContainer;
   public Transform itemSlotTemplate;
   public GameObject UI;
   public float radius = 0.5f; // 随机生成物体的半径
   public static UI_Inventory instance;
   private Button button;
   private bool isButtonClicked;
   private void Awake()
   {
      if (itemSlotContainer == null)
      {
         Debug.LogError("itemSlotContainer not found!");
      }

      if (itemSlotTemplate == null)
      {
         Debug.LogError("itemSlotTemplate not found!");
      }

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

   void Update()
   {
      if (Input.GetKeyDown(KeyCode.E))
      {
         // 切换背包UI的可见性
         UI.gameObject.SetActive(!UI.gameObject.activeSelf);
      }
      if (isButtonClicked)
      {
         // 当按钮被点击时，这个代码块会被执行
         // Debug.Log("Button clicked!");

         // 重置按钮点击状态
         isButtonClicked = false;
      }
   }

   public void SetInventory(Inventory inventory)
   {
      this.inventory_1 = inventory;

      inventory.OnItemListChanged += Inventory_OnItemListChanged;

      RefreshInventoryItems();
   } //这个是用来设置背包的，因为我们在InventoryManager中要用到这个类，所以要先设置

   private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
   {
      RefreshInventoryItems();
   }

   private void RefreshInventoryItems()
   {
      foreach (Transform child in itemSlotContainer)
      {
         if (child == itemSlotTemplate) continue;
         Destroy(child.gameObject);
      }

      int x = 0;
      int y = 0;
      float itemSlotCellSize = 100f;
      foreach (Item item in inventory_1.GetItemList())
      {
         // Debug.Log(itemSlotTemplate);
         RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
         itemSlotRectTransform.gameObject.SetActive(true);
         
         itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () =>
         {
            Debug.Log("Button clicked!");
            Item duplicateItem = new Item { itemType = item.itemType, amount = item.amount };
            inventory_1.RemoveItem(item);
            Vector3 randomDir = Random.insideUnitSphere * radius;
            Vector3 dropPosition = CharacterManager.player.transform.position + randomDir;
            dropPosition.y = CharacterManager.player.transform.position.y; // 确保生成位置的y坐标与中心物体的y坐标相同
            ItemWorld.SpawnItemWorld(dropPosition, duplicateItem);
            inventory_1.RemoveItem(item);

         };
            
         itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
         Image image = itemSlotRectTransform.GetComponentInChildren<Image>();
         image.sprite = item.GetSprite();

         TextMeshProUGUI uiText = itemSlotRectTransform.GetComponentInChildren<TextMeshProUGUI>();
         if (item.amount > 1)
         {
            uiText.SetText(item.amount.ToString());
         }
         else
         {
            uiText.SetText("");
         }

         x++;
         if (x > 1)
         {
            x = 0; 
            y--; }
         };
      }
   }
