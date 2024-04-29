
namespace DatoriumClicker
{
    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal Yield { get; set; }
        public decimal PriceMultiplier { get; set; }
        public virtual decimal GetIncome(List<Item> items)
        {
            return Yield * Count;
        }

        public virtual void Buy(ref decimal cookies)
        {
            if (cookies >= Price)
            {
                cookies -= Price;
                Count++;
                //Palielina cenu
                Price = Price * PriceMultiplier;
            }
        }
    }
}
