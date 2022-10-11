namespace GildedRose.Tests;
using GildedRose;


public class ProgramTests
{
    Program program = new Program();

    [Fact]
    public void Test_never_negative_quality()
    {
        //Arrange
        var program = new Program();
        ;
        program.Items = new List<Item>() { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0 } };

        //Act
        program.UpdateQuality();

        //Assert
        program.Items.First().SellIn.Should().Be(9);
        program.Items.First().Quality.Should().Be(0);

    }

    [Fact]
    public void Test_never_quality_when_added_item_has_negative_quality()
    {
        //Arrange
        var program = new Program();
        ;
        program.Items = new List<Item>(){
            new Item{ Name = "+5 Dexterity Vest", SellIn = 10, Quality = -1 }
            };

        //Act
        program.UpdateQuality();

        //Assert
        program.Items.First().SellIn.Should().Be(9);
        program.Items.First().Quality.Should().Be(0);

    }

    [Fact]
    public void Test_quality_never_over_50()
    {
        //Arrange
        var program = new Program();
        ;
        program.Items = new List<Item>() { new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 } };

        //Act
        program.UpdateQuality();

        //Assert
        program.Items.First().SellIn.Should().Be(1);
        program.Items.First().Quality.Should().Be(50);
    }

    [Fact]
    public void Test_normal_item_degrades_before_sell()
    {
        //Arrange
        var program = new Program();

        program.Items = new List<Item>() { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 10 } };

        //Act
        program.UpdateQuality();

        //Assert
        program.Items.First().SellIn.Should().Be(9);
        program.Items.First().Quality.Should().Be(9);
    }

    [Fact]
    public void Legendary_item_quality_always_80()
    {
        program.Items = new List<Item>{
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
        };

        program.UpdateQuality();
        int actual_LegendaryQual = program.Items[0].Quality;

        actual_LegendaryQual.Should().Be(80);

        program.UpdateQuality();
        actual_LegendaryQual = program.Items[0].Quality;

        actual_LegendaryQual.Should().Be(80);
    }
    [Fact]
    public void Legendary_item_SellIn_static()
    {
        program.Items = new List<Item>{
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
        };

        program.UpdateQuality();
        int actual_LegendarySellIn = program.Items[0].SellIn;

        actual_LegendarySellIn.Should().Be(0);

        program.UpdateQuality();
        actual_LegendarySellIn = program.Items[0].SellIn;

        actual_LegendarySellIn.Should().Be(0);
    }

    [Fact]
    public void Conjured_items_degrade_twice()
    {
        program.Items = new List<Item>{
            new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 10 },
            new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 10}
        };

        program.UpdateQuality();
        int actual_manaQual = program.Items[0].Quality;
        int actual_CakeQual = program.Items[1].Quality;

        actual_manaQual.Should().Be(8);
        actual_CakeQual.Should().Be(6);
    }
    [Fact]
    public void Test_normal_item_degrades_twice_fast_after_sell()
    {
        program.Items = new List<Item>{
                new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 10 }
        };

        program.UpdateQuality();
        program.UpdateQuality();

        int actual_dexQ = program.Items[0].Quality;

        actual_dexQ.Should().Be(6);
    }

    [Fact]
    public void Test_brie_rise_quality_always()
    {
        Program program = new Program();
        program.Items = new List<Item>{
                new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 }
        };

        program.UpdateQuality();
        program.UpdateQuality();

        int actual_brieQ = program.Items[0].Quality;

        actual_brieQ.Should().Be(12);
    }

    [Fact]
    public void Test_backstage_increase_10_days_before_sell()
    {
        //Arrange
        var program = new Program()
        {
            Items = new List<Item> {
            new Item{
                     Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 38
                    }}
        };

        //Act
        program.UpdateQuality();

        //Assert
        program.Items[0].Quality.Should().Be(40);
    }
    [Fact]
    public void Test_backstage_increase_5_days_before_sell()
    {
        //Arrange
        var program = new Program()
        {
            Items = new List<Item> {
            new Item{
                     Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 38
                    }}
        };

        //Act
        program.UpdateQuality();

        //Assert
        program.Items[0].Quality.Should().Be(41);
    }

    [Fact]
    public void Test_backstage_after_sell_worth_0()
    {
        //Arrange
        var program = new Program()
        {
            Items = new List<Item> {
                new Item{
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 0,
                        Quality = 50
                        }}
        };

        //Act
        program.UpdateQuality();

        //Assert
        program.Items[0].Quality.Should().Be(0);
    }

    [Fact]
    public void test_Conjured_degrade_double_speed()
    {
        var program = new Program();
        program.Items = new List<Item> {
            new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
            };

        program.UpdateQuality();

        program.Items[0].Quality.Should().Be(4);

    }

    [Fact]
    public void test_FillUpItemList_Check_if_items_are_filled()
    {
        var program = new Program();
        program.fillUpItemList();

        IList<Item> oldList = program.Items!;

        oldList.Should().BeEquivalentTo(new List<Item>
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
            });
    }
    [Fact]
    public void test_update_aged_brie()
    {
        UpdateAgedBrie upd = new UpdateAgedBrie();
        Item brie = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };
        Item brieTwo = new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 };
        Item brieCapped = new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 };


        upd.updateItem(brie);
        upd.updateItem(brieTwo);
        upd.updateItem(brieCapped);

        brie.SellIn.Should().Be(1);
        brie.Quality.Should().Be(1);

        brieTwo.SellIn.Should().Be(-1);
        brieTwo.Quality.Should().Be(2);

        brieCapped.SellIn.Should().Be(-1);
        brieCapped.Quality.Should().Be(50);
    }

    [Fact]

    public void test_UpdateBackstage_11Days(){
        var item = new Item {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 11,
                    Quality = 28
                    };

        var update = new UpdateBackstage();

        update.updateItem(item);
        item.SellIn.Should().Be(10);
        item.Quality.Should().Be(30);
    }

     [Fact]
    public void test_UpdateBackstage_4Days(){
        var item = new Item {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 4,
                    Quality = 25
                    };

        var update = new UpdateBackstage();

        update.updateItem(item);
        item.SellIn.Should().Be(3);
        item.Quality.Should().Be(28);
    }

    [Fact]
    public void test_UpdateBackstage_0Days(){
        var item = new Item {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 0,
                    Quality = 25
                    };

        var update = new UpdateBackstage();

        update.updateItem(item);
        item.SellIn.Should().Be(-1);
        item.Quality.Should().Be(0);
    }

    [Fact]
    public void test_UpdateConjured_10Days(){
        var item =  new Item { 
            Name = "Conjured Mana Cake", 
            SellIn = 10, 
            Quality = 10 };

        var update = new UpdateConjured();

        update.updateItem(item);
        item.SellIn.Should().Be(9);
        item.Quality.Should().Be(8);
        }
        
    public void sulfuras_updateItem_should_not_change_quality_or_sellIn(){
        var updater = new UpdateSulfuras();
        var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
        updater.updateItem(item);
        
        item.SellIn.Should().Be(0);
        item.Quality.Should().Be(80);
    }

    [Fact]
    public void normal_item_updateItem_should_lower_quality_and_sellIn_by_1_when_sellIn_more_than_0(){
        var updater = new UpdateNormal();
        var item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
        updater.updateItem(item);
        item.SellIn.Should().Be(9);
        item.Quality.Should().Be(19);

    }

    [Fact]
    public void normal_item_updateItem_should_lower_quality_by_2_and_sellIn_by_1_when_sellIn_less_than_0(){
        var updater = new UpdateNormal();
        var item = new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 };
        updater.updateItem(item);
        item.SellIn.Should().Be(-1);
        item.Quality.Should().Be(18);
    }

    [Fact]
    public void test_factory_normal(){
        var itemNormal =  new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
        var factory = new Factory();

       var normal = new UpdateNormal();
       factory.create(itemNormal).ToString().Should().Be(normal.ToString());
    }

    [Fact]
    public void test_factory_Brie(){
        var itemBrie = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };
        var factory = new Factory();
       var normal = new UpdateAgedBrie();
       factory.create(itemBrie).ToString().Should().Be(normal.ToString());
    }

    [Fact]
    public void test_factory_Sulfras(){
        var itemSulfras =  new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
        var factory = new Factory();
       var normal = new UpdateSulfuras();
       factory.create(itemSulfras).ToString().Should().Be(normal.ToString());
    }

      [Fact]
    public void test_factory_Bakcstage(){
         var itemBackstage = new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                };
        var factory = new Factory();
       var normal = new UpdateBackstage();
       factory.create(itemBackstage).ToString().Should().Be(normal.ToString());
    }

      [Fact]
    public void test_factory_Conjured(){
        var itemConjured = new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 };
        var factory = new Factory();
       var normal = new UpdateConjured();
       factory.create(itemConjured).ToString().Should().Be(normal.ToString());
    }

}
