namespace Prog120_S24_Final_Calorie_Counter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Name: Vicky Le
            // Date: 6/13/2024
            // Assignment Name: Final - Calorie Counter





        } // Main

        public class FoodItem
        {
            // Fields
            public string Name { get; set; }
            public int Category { get; set; }
            public int Calories { get; set; }
            public int Quantity { get; set; }

            // Constructor
            public FoodItem(string name, int category, int calories, int quantity)
            {
                Name = name;
                Category = category;
                Calories = calories;
                Quantity = quantity;
            }
            public FoodItem()
            {
                Name = "No Item Listed";
                Category = -1;
                Calories = -1;
                Quantity = -1;
            }
            // Methods
            public double TotalCalories()
            {
                return Calories * Quantity;
            }
            public string CategoryName()
            {
                switch (Category)
                {
                    case 0: return "Fruit";
                    case 1: return "Vegetable";
                    case 2: return "Protein";
                    case 3: return "Grain";
                    case 4: return "Dairy";
                    default: return "No Category Chosen";
                }
            }
            public string DisplayInformation()
            {
                return $"Name: {Name}\nCategory: {CategoryName()}\nCalories: {Calories}\nQuantity: {Quantity}\nTotal Calories: {TotalCalories()}\n";
            }

        } // FoodItem

    } // Class
} // Namespace
