namespace DatoriumClicker
{
    public class CookieService
    {
        public List<Item> Items = new List<Item>();
        public CookieService()
        {
            Items.Add(new Elchin());
            Items.Add(new Stove());
        }
        public decimal Cookies = 0;
        public decimal AddCookie()
        {
            return Cookies++;
        }

        public void BuyItem(Item item)
        {
            var itemToBuy = Items.FirstOrDefault(x => x.Name == item.Name);
            if (itemToBuy != null)
            {
                itemToBuy.Buy(ref Cookies);
            }
        }

        public void AddPassiveCookies()
        {
            foreach (var item in Items)
            {
                Cookies += item.GetIncome(Items);
            }
        }
    }
}
