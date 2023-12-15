using UnityEngine.EventSystems;
using UnityEditor.Animations;
using InterviewTask.Enums;
using InterviewTask.Items;
using UnityEngine.UI;
using UnityEngine;

namespace InterviewTask.Managers
{
    public class CharacterCustomization : MonoBehaviour
    {
        [Header("Preview")]
        [SerializeField] protected Image previewBody;
        [SerializeField] protected Image previewHead;
        [Header("Custom player")]
        [SerializeField] protected SpriteRenderer body;
        [SerializeField] protected SpriteRenderer head;
        [Header("Animators")]
        [SerializeField] protected Animator bodyAnimator;
        [SerializeField] protected Animator headAnimator;

        [SerializeField] protected ItemUI itemUIPrefab;
        [SerializeField] protected Transform contentParent;

        [SerializeField] protected Sprite bodyDefault;
        [SerializeField] protected AnimatorController bodyAnimatorDefault;

        protected ItemUI currentSelectedItem;

        public virtual void Open() => OnEnable();

        protected void OnEnable()
        {
            previewBody.sprite = body.sprite;
            previewBody.color = body.color;

            previewHead.sprite = head.sprite;
            previewHead.color = head.color;
            previewHead.enabled = head.enabled;
        }

        public virtual void OnClickItem(Item item)
        {
            if (item.Part == CustomizableParts.body)
            {
                previewBody.sprite = item.ImageSprite;
                previewBody.color = item.PartColor;
            }
            else if (item.Part == CustomizableParts.head)
            {
                previewHead.color = item.PartColor;
                previewHead.sprite = item.ImageSprite;

                previewHead.enabled = true;
            }
        }

        public virtual void OnClickEquip()
        {
            if (currentSelectedItem == null || !currentSelectedItem) return;

            if (currentSelectedItem.Item.Part == CustomizableParts.body)
            {
                body.sprite = currentSelectedItem.Item.ImageSprite;
                body.color = currentSelectedItem.Item.PartColor;
                previewBody.sprite = currentSelectedItem.Item.ImageSprite;
                previewBody.color = currentSelectedItem.Item.PartColor;
                bodyAnimator.runtimeAnimatorController = currentSelectedItem.Item.Animator;
            }
            else
            {
                head.sprite = currentSelectedItem.Item.ImageSprite;
                head.color = currentSelectedItem.Item.PartColor;
                previewHead.sprite = currentSelectedItem.Item.ImageSprite;
                previewHead.color = currentSelectedItem.Item.PartColor;
                headAnimator.runtimeAnimatorController = currentSelectedItem.Item.Animator;
                previewHead.enabled = true;
                head.enabled = true;
            }

            EventSystem.current.SetSelectedGameObject(currentSelectedItem.gameObject);
        }

        public virtual void OnClickUnequip()
        {
            if (currentSelectedItem == null || !currentSelectedItem) return;

            if (currentSelectedItem.Item.Part == CustomizableParts.body)
            {
                body.sprite = bodyDefault;
                body.color = Color.white;
                previewBody.sprite = bodyDefault;
                previewBody.color = Color.white;
                bodyAnimator.runtimeAnimatorController = bodyAnimatorDefault;
            }
            else
            {
                previewHead.enabled = false;
                head.enabled = false;
            }

            EventSystem.current.SetSelectedGameObject(currentSelectedItem.gameObject);
        }

        public virtual void Select(ItemUI itemUI) => currentSelectedItem = itemUI;
    }
}