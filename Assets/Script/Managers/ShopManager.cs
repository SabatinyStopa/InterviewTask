using InterviewTask.Scriptables;
using UnityEngine.EventSystems;
using InterviewTask.Items;
using UnityEngine;
using System;
using TMPro;
using InterviewTask.Enums;

namespace InterviewTask.Managers
{
    public class ShopManager : CharacterCustomization
    {
        public static Action OnClose;
        [SerializeField] private ItemScriptable[] itemScriptables;
        [SerializeField] private GameObject buyItemButton;
        [SerializeField] private GameObject soldItemButton;
        [SerializeField] private GameObject equipItemButton;
        [SerializeField] private InventoryManager inventoryManager;
        [SerializeField] private TextMeshProUGUI amountText;
        [SerializeField] private string errorSound = "Error";

        private void Start() => GenerateCustomizableParts();

        public void GenerateCustomizableParts()
        {
            foreach (ItemScriptable itemScriptable in itemScriptables)
            {
                var itemUi = Instantiate(itemUIPrefab, contentParent);
                var item = new Item
                {
                    Name = itemScriptable.Name,
                    PartColor = itemScriptable.PartColor,
                    Animator = itemScriptable.Animator,
                    Value = itemScriptable.Value,
                    ImageSprite = itemScriptable.ImageSprite,
                    Part = itemScriptable.Part,
                    Id = itemScriptable.Id
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

        public override void Open()
        {
            base.Open();
            amountText.text = moneyPrefix + inventoryManager.CurrentAmount.ToString();
        }

        public override void Close()
        {
            base.Close();
            OnClose?.Invoke();
        }

        public void OnClickFilter(int filterIndex)
        {
            if (filterIndex == 0)
            {
                foreach (Transform child in contentParent.transform)
                {
                    if (child.GetComponent<ItemUI>().Item.Part == CustomizableParts.body) child.gameObject.SetActive(true);
                    else child.gameObject.SetActive(false);
                }
            }
            else if (filterIndex == 1)
            {
                foreach (Transform child in contentParent.transform)
                {
                    if (child.GetComponent<ItemUI>().Item.Part == CustomizableParts.head) child.gameObject.SetActive(true);
                    else child.gameObject.SetActive(false);
                }
            }
            else
            {
                foreach (Transform child in contentParent.transform)
                {
                    child.gameObject.SetActive(true);
                }
            }
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

                amountText.text = moneyPrefix + inventoryManager.CurrentAmount.ToString();
                SoundManager.Instance.PlaySound("Cash");
            }
            else
            {
                SoundManager.Instance.PlaySound(errorSound);
                DialogueManager.Instance.PlayDialogue("Cannot buy! Talk to the mage!", 1.2f);
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

            amountText.text = moneyPrefix + inventoryManager.CurrentAmount.ToString();
            SoundManager.Instance.PlaySound("Cash");
            EventSystem.current.SetSelectedGameObject(currentSelectedItem.gameObject);
        }

        // [ContextMenu("Set Id for scriptables")]
        // private void SetIdForScriptables()
        // {
        //     for (int i = 0; i < itemScriptables.Length; i++)
        //     {
        //         var itemScriptable = itemScriptables[i];
        //         itemScriptable.Id = i + 1;
        //         EditorUtility.SetDirty(itemScriptable);
        //     }
        // }
    }
}