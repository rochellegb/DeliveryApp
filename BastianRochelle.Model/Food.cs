using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BastianRochelle.Model
{
    public class Food : IComparable<Food>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        private IList<Food> subFoods;

        public Food()
        {
            this.subFoods = new List<Food>();
        }

        public Food AddFood(Food food)
        {
            this.subFoods.Add(food);
            return this;
        }

        public IList<Food> SubFoods
        {
            get
            {
                return subFoods;
            }
        }
            
        public override string ToString()
        {
            return this.Name;
        }

        public int CompareTo(Food other)
        {
            return this.ID.CompareTo(other.ID);
        }
    }
}