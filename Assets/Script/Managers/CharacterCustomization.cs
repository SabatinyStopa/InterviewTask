using UnityEngine.EventSystems;
using InterviewTask.Enums;
using InterviewTask.Items;
using UnityEngine.UI;
using UnityEngine;
using System;
using InterviewTask.Players;

namespace InterviewTask.Managers
{
    public class CharacterCustomization : MonoBehaviour
    {
        public static bool IsOpen = false;
        public static Action<Item> OnEquipItem;
        public static Action<Item> OnUnequipItem;

        [SerializeField] protected GameObject panel;
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
        [SerializeField] protected RuntimeAnimatorController bodyAnimatorDefault;

        protected string moneyPrefix = "$: ";

        protected ItemUI currentSelectedItem;

        public virtual void Open()
        {
            IsOpen = true;
            panel.SetActive(true);
            OnEnable();
        }

        public virtual void Close()
        {
            IsOpen = false;
            panel.SetActive(false);
        }

        protected void OnEnable() => SetPreviewToRealChar();

        private void SetPreviewToRealChar()
        {
            previewBody.sprite = body.sprite;
            previewBody.color = body.color;

            previewHead.sprite = head.sprite;
            previewHead.color = head.color;
            previewHead.enabled = head.enabled;
        }

        public virtual void OnClickItem(Item item)
        {
            SetPreviewToRealChar();

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

            OnEquipItem?.Invoke(currentSelectedItem.Item);

            EventSystem.current.SetSelectedGameObject(currentSelectedItem.gameObject);

            Player.Instance.DisableAndEnableAnimator();
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

            OnUnequipItem?.Invoke(currentSelectedItem.Item);

            EventSystem.current.SetSelectedGameObject(currentSelectedItem.gameObject);
            Player.Instance.DisableAndEnableAnimator();
        }

        public virtual void Select(ItemUI itemUI) => currentSelectedItem = itemUI;
    }
}