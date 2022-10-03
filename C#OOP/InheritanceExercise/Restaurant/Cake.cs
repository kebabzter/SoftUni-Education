namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double DegaultGrams = 250;
        private const double DefaultCalories = 1000;
        private const decimal DefaultPrice = 5m;

        public Cake(string name) 
            : base(name, DefaultPrice, DegaultGrams, DefaultCalories)
        {
        }
    }
}
