using InterviewTask.Managers;

namespace InterviewTask.Items
{
    public class ShopItemUI : ItemUI
    {
        public override void OnSelectItem()
        {
            base.OnSelectItem();
            ((ShopManager)characterCustomizationManager).Select(this);
        }
    }
}