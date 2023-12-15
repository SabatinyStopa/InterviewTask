using UnityEngine.UI;
using UnityEngine;
using TMPro;
using InterviewTask.Managers;

namespace InterviewTask.Equipables
{
    public class ItemUI : MonoBehaviour
    {
        [SerializeField] private Image mainImage;
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private TextMeshProUGUI itemValue;

        private Item item;
        private CharacterCustomization characterCustomizationManager;

        public void SetItem(Item item, CharacterCustomization characterCustomizationManager)
        {
            this.item = item;

            itemName.text = item.Name;
            itemValue.text = item.Value;
            mainImage.sprite = item.ImageSprite;
            mainImage.color = item.PartColor;

            this.characterCustomizationManager = characterCustomizationManager;
        }

        public void OnSelectItem() => characterCustomizationManager.SetPreview(item.Part, item.Animator, item.PartColor, item.ImageSprite);
    }
}