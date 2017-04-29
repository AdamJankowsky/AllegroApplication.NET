using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllegroWebAplication.AllegroModels
{
    public class AllegroSoldItems
    {
        public int Counter { get; set; }
        public List<SoldItem> SoldItems { get; set; }

    }

    public class SoldItem
    {
        public long ItemId { get; set; }
        public string ItemTitle { get; set; }
        public string ThumbNailUrl { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemQuantity { get; set; }
        public Buyer ItemBuyer { get; set; }
    }

    public class Buyer
    {
        public int UserId { get; set; }
        public int UserLogin { get; set; }
    }
}