using InterviewTask.Managers;
using UnityEngine;

namespace InterviewTask.Interactables
{
    public class ShopKeeper : Interactable
    {
        [SerializeField] private ShopManager shopManager;

        private void Start() => ShopManager.OnClose += () => { isBusy = false; };

        private void OnDestroy() => ShopManager.OnClose -= () => { isBusy = false; };

        protected override void Interact()
        {
            base.Interact();
            shopManager.Open();
        }
    }
}