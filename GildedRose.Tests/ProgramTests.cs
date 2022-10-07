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