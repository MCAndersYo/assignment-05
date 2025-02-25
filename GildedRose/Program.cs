﻿using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public IList<Item>? Items;
        public Factory factory = new Factory();
         static void Main(string[] args)
         {
        //     System.Console.WriteLine("OMGHAI!");

        //     var app = new Program();
        //     app.fillUpItemList();

        //     for (var i = 0; i < 31; i++)
        //     {
        //         Console.WriteLine("-------- day " + i + " --------");
        //         Console.WriteLine("name, sellIn, quality");
        //         for (var j = 0; j < app.Items.Count; j++)
        //         {
        //             Console.WriteLine(app.Items[j].Name + ", " + app.Items[j].SellIn + ", " + app.Items[j].Quality);
        //         }
        //         Console.WriteLine("");
        //         app.UpdateQuality();
        //     }

         }

        public void UpdateQuality(){
            foreach (Item item in Items){
                if(item.Quality < 0){
                    item.Quality = 0;
                }
                factory.create(item).updateItem(item);
            }
        }

        public void fillUpItemList(){
            Items = new List<Item>
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
            };
        }
    }
}