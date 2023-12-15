namespace InterviewTask.Items
{
    public class ShopItemUI : ItemUI
    {
        public override void OnSelectItem()
        {
            base.OnSelectItem();
            characterCustomizationManager.Select(this);
        }
    }
}