using InterviewTask.Scriptables;
using InterviewTask.Equipables;
using UnityEditor.Animations;
using InterviewTask.Enums;
using UnityEngine.UI;
using UnityEngine;

namespace InterviewTask.Managers
{
    public class ShopManager : CharacterCustomization
    {
        [SerializeField] private ItemScriptable[] itemScriptables;
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
    }
}