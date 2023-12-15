using InterviewTask.Scriptables;
using InterviewTask.Items;
using UnityEngine;

namespace InterviewTask.Managers
{
    public class ShopManager : CharacterCustomization
    {
        [SerializeField] private ItemScriptable[] itemScriptables;

        [SerializeField] private GameObject buyItemButton;
        [SerializeField] private GameObject soldItemButton;
        [SerializeField] private InventoryManager inventoryManager;


        private ItemUI currentSelectedItem;

        private void Start() => GenerateCustomizableParts();

        public void GenerateCustomizableParts()
        {
            foreach (ItemScriptable itemScriptable in itemScriptables)
            {
                var itemUi = Instantiate(itemUIPrefab, contentParent);
                var item = new Item();

                item.Name = "Item " + Random.Range(0, 1001);
                item.PartColor = itemScriptable.PartColor;
                item.Animator = itemScriptable.Animator;
                item.Value = itemScriptable.Value;
                item.ImageSprite = itemScriptable.ImageSprite;
                item.Part = itemScriptable.Part;

                itemUi.SetItem(item, this);
            }
        }

        public void Select(ItemUI itemUI)
        {
            soldItemButton.SetActive(itemUI.IsSold);
            buyItemButton.SetActive(!itemUI.IsSold);
            currentSelectedItem = itemUI;
        }

        public void OnClickBuy()
        {
            if (currentSelectedItem == null || currentSelectedItem.IsSold) return;
            if (inventoryManager.CurrentAmount >= float.Parse(currentSelectedItem.Item.Value))
            {
                currentSelectedItem.SetSold();
                inventoryManager.BuyItem(currentSelectedItem.Item);
                soldItemButton.SetActive(false);
                buyItemButton.SetActive(false);
            }
        }

        public void OnClickSell()
        {
            if (currentSelectedItem == null || !currentSelectedItem.IsSold) return;

            currentSelectedItem.SetForSell();
            inventoryManager.SellItem(currentSelectedItem.Item);

            soldItemButton.SetActive(false);
            buyItemButton.SetActive(false);
        }
    }
}