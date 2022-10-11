namespace GildedRose;
public class UpdateNormal : IUpdate {

    public void updateItem(Item item){
        item.SellIn--;
        lowerQuality(item);
        if (item.SellIn < 0){
            lowerQuality(item);
        }
    }

    public void lowerQuality(Item item){
        if (item.Quality > 0){
            item.Quality--;
        }
    }
}