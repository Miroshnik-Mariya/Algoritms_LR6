using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALg_LR6
{
    class Item
    {
        string name; //название вещи
        int weight; //вес
        int price; //стоимость

        public Item(string name, int weight, int price)
        {
            Name = name;
            Weight = weight;
            Price = price;
        }

        public string Name
        {
            get
            {   return name; }
            set
            {
                if(value == null)
                {
                    value ="нераспознанное имя объекта";
                }
                name = value;
            }
        }

        public int Weight
        {
            get
            {   return weight; }
            set
            {
                if (value < 0)
                {
                    weight = 0;
                }
                weight = value;
            }
        }

        public int Price
        {
            get
            {   return price; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                price = value;
            }
        }


        public Item()
        {
            name = "chocolate";
            weight = 2;
            price = 5; 
        }

        public String GetName()
        {
            return name;
        }

        public int GetWeight()
        {
            return weight;
        }

        public int GetPrice()
        {
            return price;
        }


    }
}
