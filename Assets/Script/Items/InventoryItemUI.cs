namespace InterviewTask.Items
{
    public class InventoryItemUI : ItemUI
    {
        public override void OnSelectItem()
        {
            base.OnSelectItem();
            characterCustomizationManager.Select(this);
        }
    }
}