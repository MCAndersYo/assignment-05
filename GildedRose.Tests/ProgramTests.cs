namespace GildedRose.Tests;


public class ProgramTests
{
    Program program = new Program();

    [Fact]
    public void Test_negative_quality()
    {
        
    }

    [Fact]
    public void Test_quality_over_50()
    {

    }
    [Fact]
    public void Test_normal_item_degrades_before_sell()
    {

    }

    [Fact]
    public void Legendary_item_quality_always_80(){
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
    public void Legendary_item_SellIn_static(){
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
    public void Conjured_items_degrade_twice(){
        program.Items = new List<Item>{
            new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 10 },
            new Item { Name = "Conjured Cake", SellIn = 0, Quality = 10}
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
        
    }
    [Fact]
    public void Test_backstage_increase_5_days_before_sell()
    {
        
    }


[Fact]
public void Test_backstage_after_sell_worth_0()
{

}
}