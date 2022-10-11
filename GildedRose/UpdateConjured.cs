namespace GildedRose;
public class UpdateConjured : IUpdate {

    public void updateItem(Item item){
        item.SellIn--;
        lowerQuality(item);
        if (item.SellIn < 0){
            lowerQuality(item);
        }
    }

    public void lowerQuality(Item item){
        if (item.Quality > 1){
            item.Quality = item.Quality - 2;
        }
        else{
            item.Quality = 0;
        }
    }
}