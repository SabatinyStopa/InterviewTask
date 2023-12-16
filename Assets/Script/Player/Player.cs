using InterviewTask.Managers;
using TMPro;
using UnityEngine;

namespace InterviewTask.Players
{
    public class Player : MonoBehaviour
    {
        public static Player Instance;
        [SerializeField] private Animator[] animators;
        [SerializeField] private Rigidbody2D body;
        [SerializeField] private float speed = 30f;
        [SerializeField] private string horizontalAxisName = "Horizontal";
        [SerializeField] private string verticalAxisName = "Vertical";
        [SerializeField] private TextMeshPro interactText;
        private Vector3 direction;

        private void Awake() => Instance = this;

        private void Update()
        {
            if (CharacterCustomization.IsOpen) return;

            var horizontal = Input.GetAxisRaw(horizontalAxisName);
            var vertical = Input.GetAxisRaw(verticalAxisName);
            direction = new Vector3(horizontal, vertical, 0) * speed;

            foreach (Animator animator in animators)
            {
                if (!animator.gameObject.activeInHierarchy) continue;
                animator.SetFloat(horizontalAxisName, horizontal);
                animator.SetFloat(verticalAxisName, vertical);
            }
        }

        private void FixedUpdate() => body.velocity = direction * Time.fixedDeltaTime;

        public void DisableAndEnableAnimator()
        {
            foreach (Animator animator in animators)
            {
                if (!animator.gameObject.activeInHierarchy) continue;
                animator.enabled = false;
            }

            foreach (Animator animator in animators)
            {
                if (!animator.gameObject.activeInHierarchy) continue;
                animator.enabled = true;
            }
        }

        public void ShowCanInteractText() => interactText.enabled = true;

        public void HideCanInteractText() => interactText.enabled = false;
    }
}