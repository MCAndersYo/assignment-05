namespace GildedRose;
public class UpdateAgedBrie : IUpdate {

    public void updateItem(Item item){
        item.SellIn--;
        increaseQuality(item);
        if (item.SellIn < 0){
            increaseQuality(item);
        }
    }

    public void increaseQuality(Item item){
        if (item.Quality < 50){
            item.Quality++;
        }
    }
}