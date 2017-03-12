using BastianRochelle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastianRochelle.Delivery
{
    public class OrderManager
    {
        List<Food> foodList;
        
        public OrderManager()
        {
            this.foodList = new List<Food>();   

            var burger = new Burger(1, "Burger", 0);
            burger.AddFood(new Burger(2, "Just Burger", 29))
                .AddFood(new Burger(3, "Cheese Burger", 39))
                .AddFood(new Burger(4, "Double Bart Burger", 59))
                .AddFood(new Burger(5, "Quarter Pounder Burger", 89));
            this.foodList.Add(burger);

            var chicken = new Chicken(6, "Chicken", 0);
            chicken.AddFood(new Chicken(7, "Bucket of 3", 150))
                .AddFood(new Chicken(8, "Bucket of 5", 225))
                .AddFood(new Chicken(9, "Bucket of 10", 450));
            this.foodList.Add(chicken);

            var fries = new Fries(10, "Fries", 0);
            fries.AddFood(new Fries(11, "Cheese", 30))
                .AddFood(new Fries(12, "Barbeque", 45))
                .AddFood(new Fries(13, "Sour 'n Cream", 50));
            this.foodList.Add(fries);

            var drinks = new Drink(14, "Drink", 0);
            drinks.AddFood(new Drink(15, "Softdrinks", 15))
                .AddFood(new Drink(16, "Juice", 20))
                .AddFood(new Drink(17, "Smoothie", 25));
            this.foodList.Add(drinks);
        }

        public IEnumerable<Food> FoodCategories
        {
            get
            {
                return this.foodList;
            }
        }

        public IEnumerable<Food> GetSpecificFoods(Food food)
        {
            var category = this.foodList.FirstOrDefault(f => f.ID == food.ID);
            return category.SubFoods;
        }
    }
}
