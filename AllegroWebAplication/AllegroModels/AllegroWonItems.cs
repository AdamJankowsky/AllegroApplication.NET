using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllegroWebAplication.AllegroModels
{
    public class AllegroWonItems
    {
        public int Counter { get; set; }
        public List<WonItem> WonItems { get; set; }

    }

    public class WonItem
    {
        public long ItemId { get; set; }
        public string ItemTitle { get; set; }
        public string ThumbNailUrl { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemQuantity { get; set; }
        public ItemSeller ItemSeller { get; set; }
    }

    public class ItemSeller
    {
        public int SellerId { get; set; }
        public string SellerLogin { get; set; }
    }
}