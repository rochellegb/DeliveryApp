﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastianRochelle.Model
{
    public class Burger : Food
    {
        public Burger(int id, string name, double price)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
        }
    }
}
