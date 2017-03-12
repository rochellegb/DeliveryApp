using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastianRochelle.Model
{
    public class Chicken : Food
    {
        public Chicken(int id, string name, double price)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
        }

        public string[] GetChickenDetails()
        {
            string[] chickenDetails = new string[3];
            chickenDetails[0] = this.ID.ToString();
            chickenDetails[1] = this.Name.ToString();
            
            return chickenDetails;
        }
    }
}
