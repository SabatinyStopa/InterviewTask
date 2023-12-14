using UnityEditor.Animations;
using InterviewTask.Enums;
using UnityEngine.UI;
using UnityEngine;
using InterviewTask.Equipables;
using InterviewTask.Scriptables;

namespace InterviewTask.Managers
{
    public class CharacterEquipamentManager : MonoBehaviour
    {
        [Header("Preview")]
        [SerializeField] private Image previewBody;
        [SerializeField] private Image previewHead;
        [Header("Custom player")]
        [SerializeField] private SpriteRenderer body;
        [SerializeField] private SpriteRenderer head;
        [Header("Animators")]
        [SerializeField] private Animator bodyAnimator;
        [SerializeField] private Animator headAnimator;

        [SerializeField] private ItemUI itemUIPrefab;
        [SerializeField] private float quantityToGenerate = 30;
        [SerializeField] private Transform contentParent;
        [SerializeField] private ItemScriptable[] itemScriptables;

        private void Start() => GenerateCustomizableParts();

        public void SetPreview(CustomizableParts part, AnimatorController controller, Color color, Sprite sprite)
        {
            if (part == CustomizableParts.body)
            {
                previewBody.sprite = sprite;
                previewBody.color = color;
                bodyAnimator.runtimeAnimatorController = controller;
            }
            else if (part == CustomizableParts.head)
            {
                previewHead.color = color;
                previewHead.sprite = sprite;
                headAnimator.runtimeAnimatorController = controller;
            }
        }

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