using System.Collections.Generic;
using InterviewTask.Items;
using TMPro;
using UnityEngine;

namespace InterviewTask.Managers
{
    public class InventoryManager : CharacterCustomization
    {
        [SerializeField] private TextMeshProUGUI amountText;
        private float currentAmount = 200f;

        private Item currentHeadItem;
        private Item currentBodyItem;

        struct InventoryItem
        {
            public Item Item;
            public InventoryItemUI ItemUI;
        }

        private List<InventoryItem> items = new List<InventoryItem>();

        public float CurrentAmount { get => currentAmount; }

        private void Start()
        {
            OnEquipItem += SetCurrentEquip;
            OnUnequipItem += RemoveCurrentEquip;
        }

        private void OnDestroy()
        {
            OnEquipItem -= SetCurrentEquip;
            OnUnequipItem -= RemoveCurrentEquip;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I) && !IsOpen) Open();
        }

        private void SetCurrentEquip(Item item)
        {
            if (item.Part == Enums.CustomizableParts.body) currentBodyItem = item;
            else currentHeadItem = item;
        }

        private void RemoveCurrentEquip(Item item)
        {
            if (item.Part == Enums.CustomizableParts.body) currentBodyItem = null;
            else currentHeadItem = null;
        }

        public void AddCurrentAmount(float amount) => currentAmount += amount;

        public override void Open()
        {
            base.Open();
            SetEquipped();
            amountText.text = moneyPrefix + currentAmount.ToString();
        }

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

            itemUi.SetValueText("");
            amountText.text = moneyPrefix + currentAmount.ToString();
        }

        public void SellItem(Item item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                var inventoryItem = items[i];

                if (inventoryItem.Item.Id == item.Id)
                {
                    currentAmount += float.Parse(item.Value);
                    items.Remove(inventoryItem);
                    Destroy(inventoryItem.ItemUI.gameObject);
                    break;
                }
            }

            amountText.text = moneyPrefix + currentAmount.ToString();
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

        public override void OnClickEquip()
        {
            base.OnClickEquip();
            SetEquipped();
        }

        public override void OnClickUnequip()
        {
            base.OnClickUnequip();
            SetEquipped();
        }

        private void SetEquipped()
        {
            foreach (InventoryItem inventoryItem in items)
            {
                if (currentBodyItem != null
                    && inventoryItem.Item.Id == currentBodyItem.Id
                    || currentHeadItem != null
                    && inventoryItem.Item.Id == currentHeadItem.Id)
                    inventoryItem.ItemUI.SetValueText("EQUIPPED");
                else
                    inventoryItem.ItemUI.SetValueText("");
            }
        }
    }
}