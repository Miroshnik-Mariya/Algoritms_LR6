using ALg_LR6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Alg_LR6
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Лабораторная работа №6\nВыполнила студентка группы 6201-020302D\nМирошник Мария");
            Console.WriteLine("\n\nЗадача об оптимальном заполнении рюкзака\nБез повторений\n\nТаблица мемоизации");
            //Задачи об оптимальном заполнении рюкзака 
            //
            //
            //без повторений 

            int n = 3; //число вещей
            int k = 4; //грузоподъёмность рюкзака    
                       
            Item[] items = {new Item("гитара", 1, 1500),
               new Item("бензопила", 4, 3000),
               new Item("ноутбук", 3, 2000)};

            Backpack[,] bp = new Backpack[n + 1,k + 1];

            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < k + 1; j++)
                {
                    if (i == 0 || j == 0)
                    { //нулевую строку и столбец заполняем нулями
                        bp[i,j] = new Backpack(new Item[] { }, 0);
                    }
                    else if (i == 1)
                    {
                        //первая строка: первый предмет кладём или не кладём в зависимости от веса
                        bp[1,j] = items[0].GetWeight() <= j ? new Backpack(new Item[] { items[0] }, items[0].GetPrice())
                                : new Backpack(new Item[] { }, 0);
                    }
                    else
                    {
                        if (items[i - 1].GetWeight() > j) //если очередной предмет не влезает в рюкзак,
                            bp[i,j] = bp[i - 1,j];    //записываем предыдущий максимум
                        else
                        {
                            /*рассчитаем цену очередного предмета + максимальную цену для (максимально возможный для рюкзака вес − вес предмета)*/
                            int newPrice = items[i - 1].GetPrice() + bp[i - 1,j - items[i - 1].GetWeight()].GetCost();
                            if (bp[i - 1,j].GetCost() > newPrice) //если предыдущий максимум больше
                                bp[i,j] = bp[i - 1,j]; //запишем его
                            else
                            {
                                /*иначе фиксируем новый максимум: текущий предмет + стоимость свободного пространства*/
                                bp[i, j] = new Backpack(new[] { items[i - 1] }.Concat(bp[i - 1, j - items[i - 1].Weight].items).ToArray(),newPrice);
                            }
                        }
                    }
                }
            }
            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < k + 1; j++)
                {
                    Console.Write(bp[i,j].GetDescription() + "\t");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("Товары:\nГитара - 1кг - 1500руб\nНоутбук - 3кг - 2000руб\nБензопила - 4кг - 3000руб");
            Console.WriteLine("\nОтвет: " + bp[n,k].GetDescription()+"\n\n");



            //
            //
            //задача с повторениями 
            Console.WriteLine("\n\nЗадача об оптимальном заполнении рюкзака\nС повторениями\n");
            int[] maxCost = new int[k + 1]; //макс стоимости
            Item[][] includedItems = new Item[k + 1][]; //комбинация предметов

            
            for (int j = 0; j <= k; j++)
            {
                maxCost[j] = 0;
                includedItems[j] = new Item[0];
            }

            // Заполнение таблицы
            for (int j = 1; j <= k; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (items[i].GetWeight() <= j)
                    {
                        int currentCost = items[i].GetPrice() + maxCost[j - items[i].GetWeight()];
                        if (currentCost > maxCost[j])
                        {
                            maxCost[j] = currentCost;
                            // Объединяем текущий предмет с предыдущим оптимальным набором
                            includedItems[j] = new[] { items[i] }
                                .Concat(includedItems[j - items[i].GetWeight()])
                                .ToArray();
                        }
                    }
                }
            }

            
            Console.WriteLine("Грузоподъёмность\tМакс. стоимость\tСостав");
            for (int j = 1; j <= k; j++)
            {
                Console.Write($"{j} кг\t\t\t{maxCost[j]} руб\t\t");
                Console.WriteLine(string.Join(" + ", includedItems[j].Select(item => item.GetName())));
            }

            Console.WriteLine($"\nОптимальное решение для рюкзака {k} кг:");
            Console.WriteLine($"Состав: {string.Join(" + ", includedItems[k].Select(item => item.GetName()))}");
            Console.WriteLine($"Общая стоимость: {maxCost[k]} руб");
        }
    
    }
}