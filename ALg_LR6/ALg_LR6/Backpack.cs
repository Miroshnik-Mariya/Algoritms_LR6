using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ALg_LR6
{
    internal class Backpack
    {
        public Item[] items;
        public int totalCost; 

        public Backpack(Item[] items, int totalCost)
        {
            this.items = items;
            this.totalCost = totalCost;
        }

        public Item[] GetItems()
        {
            return items;
        }

        public int GetCost()
        {
            return totalCost;
        }

        public string GetDescription()
        {
            return items == null
                ? ""
                : string.Join("+", items.Select(item => item.GetName())) + "-" + GetCost();
        }
    }
}
