namespace GildedRose;
public class Factory{
    public IUpdate create(Item item){
        switch(item.Name){
            case "Sulfuras, Hand of Ragnaros":
                return new UpdateSulfuras();
            case "Backstage passes to a TAFKAL80ETC concert":
                return new UpdateBackstage();
            case "Conjured Mana Cake":
                return new UpdateConjured();
            case "Aged Brie":
                return new UpdateAgedBrie();
        }
        return new UpdateNormal();
    }
}