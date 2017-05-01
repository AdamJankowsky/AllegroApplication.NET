using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AllegroWebAplication.KeySenderModels
{
    public class KeyFactoryModel
    {
        public int Id { get; set; }
        public string FactoryName { get; set; }
        public List<Auction> AuctionIDs { get; set; } //Id aukcji danego klucza
        public List<Key> Keys { get; set; }
    }

    public class Auction
    {
        public int Id { get; set; }
        public long AuctionNumber { get; set; }
    }

    public class Key
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool Used { get; set; }
    }

}