
namespace DatoriumClicker
{
    public class Elchin : Item
    {
        private decimal StoveMultiplier = 0.01m;
        public Elchin()
        {
            Name = "Elchin";
            Price = 50;
            Yield = 1;
            PriceMultiplier = 1.1m;
        }

        public override decimal GetIncome(List<Item> items)
        {
            var totalIncome = Yield * Count; // Reizina Elchin skaitu ar 
            var stoves = items.OfType<Stove>().ToList();
            var stove = stoves.FirstOrDefault();
            if (stove != null && stove.Count != 0)
            {
                var multiplier = 1 + StoveMultiplier * stove.Count;
                totalIncome = totalIncome * multiplier;
            }
            return totalIncome;
        }
    }
}
