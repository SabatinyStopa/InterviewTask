using System.Collections;
using InterviewTask.Managers;
using UnityEngine;

namespace InterviewTask.Interactables
{
    public class ShopKeeper : Interactable
    {
        [SerializeField] private ShopManager shopManager;
        [SerializeField] private Animator animator;

        private void Start() => ShopManager.OnClose += () => { isBusy = false; };

        private void OnDestroy() => ShopManager.OnClose -= () => { isBusy = false; };

        protected override void Interact()
        {
            base.Interact();
            StartCoroutine(OpenPanel());
            animator.SetTrigger("Jump");
            StartCoroutine(DialogueManager.Instance.PlayDialogue("Uhul! Someone will buy my things!"));
        }

        private IEnumerator OpenPanel()
        {
            yield return new WaitForSeconds(3f);
            shopManager.Open();
        }
    }
}