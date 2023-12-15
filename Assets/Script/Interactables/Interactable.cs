using UnityEngine;

namespace InterviewTask.Interactables
{
    public class Interactable : MonoBehaviour
    {
        private bool playerInRange;
        protected bool isBusy;

        private void Update()
        {
            if (playerInRange && Input.GetKeyDown(KeyCode.E) && !isBusy) Interact();
        }

        protected virtual void Interact()
        {
            isBusy = true;
        }

        protected virtual void StopInteract()
        {
            isBusy = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")) playerInRange = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player")) playerInRange = false;
        }
    }
}