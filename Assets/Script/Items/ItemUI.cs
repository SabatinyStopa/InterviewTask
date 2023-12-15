using UnityEngine.UI;
using UnityEngine;
using TMPro;
using InterviewTask.Managers;

namespace InterviewTask.Items
{
    public class ItemUI : MonoBehaviour
    {
        [SerializeField] protected Image mainImage;
        [SerializeField] protected TextMeshProUGUI itemName;
        [SerializeField] protected TextMeshProUGUI itemValue;

        protected Item item;
        protected CharacterCustomization characterCustomizationManager;

        public void SetItem(Item item, CharacterCustomization characterCustomizationManager)
        {
            this.item = item;

            itemName.text = item.Name;
            itemValue.text = item.Value;
            mainImage.sprite = item.ImageSprite;
            mainImage.color = item.PartColor;

            this.characterCustomizationManager = characterCustomizationManager;
        }

        public virtual void OnSelectItem() => characterCustomizationManager.SetPreview(item.Part, item.Animator, item.PartColor, item.ImageSprite);
    }
}