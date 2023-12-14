using UnityEngine;

namespace InterviewTask.Players
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Animator[] animators;
        [SerializeField] private Rigidbody2D body;
        [SerializeField] private float speed = 30f;
        [SerializeField] private string horizontalAxisName = "Horizontal";
        [SerializeField] private string verticalAxisName = "Vertical";
        private Vector3 direction;

        private void Update()
        {
            var horizontal = Input.GetAxis(horizontalAxisName);
            var vertical = Input.GetAxis(verticalAxisName);
            direction = new Vector3(horizontal, vertical, 0) * speed;

            foreach (Animator animator in animators)
            {
                animator.SetFloat(horizontalAxisName, horizontal);
                animator.SetFloat(verticalAxisName, vertical);
            }
        }

        private void FixedUpdate() => body.velocity = direction * Time.fixedDeltaTime;
    }
}