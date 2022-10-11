namespace GildedRose;
public class UpdateSulfuras : IUpdate {

    public void updateItem(Item item){
        item.SellIn = item.SellIn;
        item.Quality = item.Quality;
    }
}