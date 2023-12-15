using InterviewTask.Managers;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace InterviewTask.Items
{
    public class ItemUI : MonoBehaviour
    {
        [SerializeField] protected Image mainImage;
        [SerializeField] protected TextMeshProUGUI itemName;
        [SerializeField] protected TextMeshProUGUI itemValue;

        private bool isSold = false;
        protected Item item;
        protected CharacterCustomization characterCustomizationManager;

        public Item Item { get => item; }
        public bool IsSold { get => isSold; set => isSold = value; }

        public void SetItem(Item item, CharacterCustomization characterCustomizationManager)
        {
            this.item = item;

            itemName.text = item.Name;
            itemValue.text = item.Value;
            mainImage.sprite = item.ImageSprite;
            mainImage.color = item.PartColor;

            this.characterCustomizationManager = characterCustomizationManager;
        }

        public virtual void OnSelectItem() => characterCustomizationManager.OnClickItem(Item);

        public void SetSold()
        {
            itemValue.text = "SOLD";
            isSold = true;
        }

        public void SetValueText(string valueString) => itemValue.text = valueString;

        public void SetForSell()
        {
            itemValue.text = item.Value;
            isSold = false;
        }
    }
}