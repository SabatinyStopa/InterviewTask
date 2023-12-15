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
                bodyAnimator.runtimeAnimatorController = item.Animator;
            }
            else if (item.Part == CustomizableParts.head)
            {
                previewHead.color = item.PartColor;
                previewHead.sprite = item.ImageSprite;
                headAnimator.runtimeAnimatorController = item.Animator;
            }
        }

        public virtual void SetSkin()
        {
            body.sprite = previewBody.sprite;
            head.sprite = previewHead.sprite;
        }
    }
}