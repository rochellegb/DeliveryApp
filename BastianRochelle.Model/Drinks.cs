using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastianRochelle.Model
{
    public class Drinks : Food
    {
        public Drinks(int id, string name, double price)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
        }

        public string[] GetDrinksDetails()
        {
            string[] drinkDetails = new string[3];
            drinkDetails[0] = this.ID.ToString();
            drinkDetails[1] = this.Name.ToString();
            drinkDetails[2] = this.Price.ToString();
            return drinkDetails;
        }
    }
}
