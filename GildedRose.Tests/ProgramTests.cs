namespace GildedRose.Tests;
using GildedRose;

public class ProgramTests
{
    [Fact]
    public void TestTheTruth()
    {
        true.Should().BeTrue();
    }

    [Fact]
    public void Test_never_negative_quality()
    {
        //Arrange
        var program = new Program();
        ;
        program.Items = new List<Item>(){new Item{ Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0 }};
        
        //Act
        program.UpdateQuality();
        
        //Assert
        program.Items.First().SellIn.Should().Be(9);
        program.Items.First().Quality.Should().Be(0);

    }

    public void Test_never_quality_when_added_item_has_negative_quality()
    {
        //Arrange
        var program = new Program();
        ;
        program.Items = new List<Item>(){new Item{ Name = "+5 Dexterity Vest", SellIn = 10, Quality = -1 }};
        
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
        program.Items = new List<Item>(){new Item{ Name = "Aged Brie", SellIn = 2, Quality = 50}};
        
        //Act
        program.UpdateQuality();
        
        //Assert
        program.Items.First().SellIn.Should().Be(1);
        program.Items.First().Quality.Should().Be(50);
    }

    [Fact]
    public void Test_quality_never_over_50_when_added_item_added_has_quality_over_50()
    {
        //Arrange
        var program = new Program();
        ;
        program.Items = new List<Item>(){new Item{ Name = "Aged Brie", SellIn = 2, Quality = 80}};
        
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
        ;
        program.Items = new List<Item>(){new Item{ Name = "+5 Dexterity Vest", SellIn = 10, Quality = 10}};
        
        //Act
        program.UpdateQuality();
        
        //Assert
        program.Items.First().SellIn.Should().Be(9);
        program.Items.First().Quality.Should().Be(9);
    }

    [Fact]
    public void Test_normal_item_degrades_twice_fast_after_sell()
    {
        
    }

    [Fact]
    public void Test_brie_rise_quality_always()
    {
        
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