using System;
using System.Collections.Generic;
using InterviewTask.Items;

namespace InterviewTask.Managers
{
    public class InventoryManager : CharacterCustomization
    {
        private float currentAmount = 1000;

        struct InventoryItem
        {
            public Item Item;
            public InventoryItemUI ItemUI;
        }

        private List<InventoryItem> items = new List<InventoryItem>();
        public float CurrentAmount { get => currentAmount; }

        public void BuyItem(Item item)
        {
            currentAmount -= float.Parse(item.Value);

            var newItem = new Item(item);
            var itemUi = Instantiate(itemUIPrefab, contentParent);
            var inventoryItem = new InventoryItem
            {
                Item = item,
                ItemUI = (InventoryItemUI)itemUi
            };

            items.Add(inventoryItem);
            itemUi.SetItem(newItem, this);
        }

        public void SellItem(Item item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                var inventoryItem = items[i];

                if (inventoryItem.Item == item)
                {
                    currentAmount += float.Parse(inventoryItem.Item.Value);
                    items.Remove(inventoryItem);
                    Destroy(inventoryItem.ItemUI.gameObject);
                    break;
                }
            }
        }

        public bool IsItemEquipped(Item item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                var inventoryItem = items[i];

                if (inventoryItem.Item == item) return true;
            }

            return false;
        }
    }
}