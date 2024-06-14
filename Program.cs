namespace Prog120_S24_Final_Calorie_Counter
{
    internal class Program
    {
        // Field
        static FoodItem[] foodItems = new FoodItem[2];


        static void Main(string[] args)
        {
            // Name: Vicky Le
            // Date: 6/13/2024
            // Assignment Name: Final - Calorie Counter

            Preload();
            Menu();
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
            } // TotalCalories()
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
            } // CategoryName
            public string DisplayInformation()
            {
                return $"Name: {Name}\nCategory: {CategoryName()}\nCalories: {Calories}\nQuantity: {Quantity}\nTotal Calories: {TotalCalories()}\n";
            } // DisplayInformation()

        } // FoodItem

        static void Preload()
        {
            foodItems[0] = new FoodItem("Apple", 0, 95, 1);
            foodItems[1] = new FoodItem("Banana", 0, 105, 2);
        } //Preload()
        static void DisplayAllFoodItems()
        {
            foreach (var item in foodItems)
            {
                if (item != null)
                {
                    Console.WriteLine(item.DisplayInformation());
                }
            }
        } // DisplayAllFoodItems()
        static FoodItem MakeNewItem()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            int category;
            while (true)
            {
                Console.WriteLine("Enter category (0: Fruit, 1: Vegetable, 2: Protein, 3: Grain, 4: Dairy): ");
                if (int.TryParse(Console.ReadLine(), out category) && category >= 0 && category <= 4)
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a number between 0 and 4.");
            }

            int calories;
            while (true)
            {
                Console.Write("Enter calories: ");
                if (int.TryParse(Console.ReadLine(), out calories))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            int quantity;
            while (true)
            {
                Console.Write("Enter quantity: ");
                if (int.TryParse(Console.ReadLine(), out quantity))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            return new FoodItem(name, category, calories, quantity);
        } // MakeNewItem()
        static int FindEmptyIndex()
        {
            for (int i = 0; i < foodItems.Length; i++)
            {
                if (foodItems[i] == null)
                {
                    return i;
                }
            }
            return -1;
        } // FindEmptyIndex()
        static void IncreaseArraySize()
        {
            int newSize = foodItems.Length * 2;
            FoodItem[] newArray = new FoodItem[newSize];
            for (int i = 0; i < foodItems.Length; i++)
            {
                newArray[i] = foodItems[i];
            }
            foodItems = newArray;
        } // IncreaseArraySize()
        public static void AddItem()
        {
            FoodItem newItem = MakeNewItem();
            int firstIndex = FindEmptyIndex();

            if (firstIndex == -1)
            {
                IncreaseArraySize();
                firstIndex = FindEmptyIndex();
            }

            foodItems[firstIndex] = newItem;
        } // AddItem()
        static double TotalCaloriesEaten()
        {
            double totalCalories = 0;
            foreach (var item in foodItems)
            {
                if (item != null)
                {
                    totalCalories += item.TotalCalories();
                }
            }
            return totalCalories;
        } // TotalCaloriesEaten()
        static double AverageCalorieEaten()
        {
            double totalCalories = 0;
            int itemCount = 0;
            foreach (var item in foodItems)
            {
                if (item != null)
                {
                    totalCalories += item.Calories;
                    itemCount++;
                }
            }
            return itemCount > 0 ? totalCalories / itemCount : 0;
        } // AverageCalorieEaten()

        static void DisplayByCategory()
        {
            Console.WriteLine("Select a category (0: Fruit, 1: Vegetable, 2: Protein, 3: Grain, 4: Dairy): ");
            if (int.TryParse(Console.ReadLine(), out int category) && category >= 0 && category <= 4)
            {
                foreach (var item in foodItems)
                {
                    if (item != null && item.Category == category)
                    {
                        Console.WriteLine(item.DisplayInformation());
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid category.");
            }
        } // DisplayByCategory()
        static void DisplayItemWithName()
        {
            Console.Write("Enter food name: ");
            string foodName = Console.ReadLine().ToLower();
            bool found = false;

            foreach (var item in foodItems)
            {
                if (item != null && item.Name.ToLower() == foodName)
                {
                    Console.WriteLine(item.DisplayInformation());
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"The name '{foodName}' doesn't exist.");
            }
        } // DisplayItemWithName()
        static void Menu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Menu Options: \n1. Display all the calories you have eaten \n2. Add New Items \n3. Calculate your total calories eaten \n4. Calculate the average calories of an item you've eaten \n5. Display all food eaten of a certain category \n6. Search for a food item by name \n7. Exit \nPlease select an option (1-7):");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            DisplayAllFoodItems();
                            break;
                        case 2:
                            AddItem();
                            break;
                        case 3:
                            Console.WriteLine($"Your total calories are {TotalCaloriesEaten()}");
                            break;
                        case 4:
                            Console.WriteLine($"Your average calories are {AverageCalorieEaten()}");
                            break;
                        case 5:
                            DisplayByCategory();
                            break;
                        case 6:
                            DisplayItemWithName();
                            break;
                        case 7:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please select a number between 1 and 7.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 7.");
                }
            }
        } // Menu()

    } // Class

} // Namespace
