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
        private CharacterEquipamentManager characterEquipamentManager;

        public void SetItem(Item item, CharacterEquipamentManager characterEquipamentManager)
        {
            this.item = item;

            itemName.text = item.Name;
            itemValue.text = item.Value;
            mainImage.sprite = item.ImageSprite;
            mainImage.color = item.PartColor;

            this.characterEquipamentManager = characterEquipamentManager;
        }

        public void OnSelectItem() => characterEquipamentManager.SetPreview(item.Part, item.Animator, item.PartColor, item.ImageSprite);
    }
}