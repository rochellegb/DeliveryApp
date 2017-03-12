using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BastianRochelle.Model;

namespace BastianRochelle.Delivery
{
    public class Cart : IEnumerable<Food>
    {
        ISet<Food> foodList;

        public double TotalAmount
        {
            get
            {
                //- Lambda expression
                return foodList.Sum(y => y.Quantity * y.Price);
            }
        }

        public Cart()
        {
            this.foodList = new SortedSet<Food>();
        }

        public bool Add(Food food)
        {
            return foodList.Add(food);
        }

        public bool Remove(Food food)
        {
            return foodList.Remove(food);
        }

        public IEnumerator<Food> GetEnumerator()
        {
            return foodList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
