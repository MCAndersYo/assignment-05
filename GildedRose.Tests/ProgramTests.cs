namespace GildedRose.Tests;

public class ProgramTests
{
    [Fact]
    public void TestTheTruth()
    {
        true.Should().BeTrue();
    }

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
        
    }

    [Fact]
    public void Test_brie_rise_quality_always()
    {
        
    }

    [Fact]
    public void Test_backstage_increase_10_days_before_sell()
    {
        //Arrange
        var program = new Program(){
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
        var program = new Program(){
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
        var program = new Program(){
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
}