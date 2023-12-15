using InterviewTask.Scriptables;
using UnityEngine.EventSystems;
using InterviewTask.Items;
using UnityEngine;

namespace InterviewTask.Managers
{
    public class ShopManager : CharacterCustomization
    {
        [SerializeField] private ItemScriptable[] itemScriptables;

        [SerializeField] private GameObject buyItemButton;
        [SerializeField] private GameObject soldItemButton;
        [SerializeField] private GameObject equipItemButton;
        [SerializeField] private InventoryManager inventoryManager;

        private void Start() => GenerateCustomizableParts();

        public void GenerateCustomizableParts()
        {
            foreach (ItemScriptable itemScriptable in itemScriptables)
            {
                var itemUi = Instantiate(itemUIPrefab, contentParent);
                var item = new Item
                {
                    Name = "Item " + Random.Range(0, 1001),
                    PartColor = itemScriptable.PartColor,
                    Animator = itemScriptable.Animator,
                    Value = itemScriptable.Value,
                    ImageSprite = itemScriptable.ImageSprite,
                    Part = itemScriptable.Part
                };

                itemUi.SetItem(item, this);
            }
        }

        public override void Select(ItemUI itemUI)
        {
            base.Select(itemUI);
            soldItemButton.SetActive(itemUI.IsSold);
            equipItemButton.SetActive(itemUI.IsSold);
            buyItemButton.SetActive(!itemUI.IsSold);
        }

        public void OnClickBuy()
        {
            if (currentSelectedItem == null || currentSelectedItem.IsSold) return;
            if (inventoryManager.CurrentAmount >= float.Parse(currentSelectedItem.Item.Value))
            {
                currentSelectedItem.SetSold();
                inventoryManager.BuyItem(currentSelectedItem.Item);
                soldItemButton.SetActive(true);
                equipItemButton.SetActive(true);
                buyItemButton.SetActive(false);

                EventSystem.current.SetSelectedGameObject(currentSelectedItem.gameObject);
            }
        }

        public void OnClickSell()
        {
            if (currentSelectedItem == null || !currentSelectedItem.IsSold) return;

            if (inventoryManager.IsItemEquipped(currentSelectedItem.Item))
            {
                if (currentSelectedItem.Item.Part == Enums.CustomizableParts.body)
                {
                    body.sprite = bodyDefault;
                    body.color = Color.white;

                    bodyAnimator.runtimeAnimatorController = bodyAnimatorDefault;
                }
                else head.enabled = false;
            }

            currentSelectedItem.SetForSell();
            inventoryManager.SellItem(currentSelectedItem.Item);

            soldItemButton.SetActive(false);
            equipItemButton.SetActive(false);
            buyItemButton.SetActive(true);

            EventSystem.current.SetSelectedGameObject(currentSelectedItem.gameObject);
        }
    }
}