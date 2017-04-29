using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllegroWebAplication.AllegroModels
{
    public class AllegroSellItems
    {
        public int sellItemsCounter { get; set; }
        public List<SellItem> sellItemsList { get; set; }

    }

    public class SellItem
    {
        public long itemId { get; set; }
        public string itemTitle { get; set; }
        public string itemThumbnailUrl { get; set; }
        public decimal itemPrice { get; set; } // I'm getting float from API but I think it should be decimal
        public int itemsLeft { get; set; }
        public string itemEndTimeLeft { get; set; }
        public int itemViews { get; set; }
    }

    
}