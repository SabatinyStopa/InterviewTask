using InterviewTask.Enums;
using InterviewTask.Equipables;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

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

        public virtual void SetPreview(CustomizableParts part, AnimatorController controller, Color color, Sprite sprite)
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

        public virtual void SetSkin()
        {
            body.sprite = previewBody.sprite;
            head.sprite = previewHead.sprite;
        }
    }
}