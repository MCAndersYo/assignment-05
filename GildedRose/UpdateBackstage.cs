namespace GildedRose;
public class UpdateBackstage : IUpdate {

    public void updateItem(Item item){
        item.SellIn--;
        if (item.SellIn < 0){
            item.Quality = 0;
        }
        else{
            if (item.SellIn <= 10){
                increaseQuality(item);
                increaseQuality(item);
            }
            if (item.SellIn <= 5){
                increaseQuality(item);
            }
        }
    }

    public void increaseQuality(Item item){
        if (item.Quality < 50){
            item.Quality++;
        }
    }
}