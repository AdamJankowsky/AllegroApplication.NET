using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AllegroWebAplication.KeySenderModels
{
    public class KeyManagerModel
    {
        public int Id { get; set; }
        public string FactoryName { get; set; }
        public long AuctionID { get; set; } //Id aukcji dla danego managera
        public virtual IList<Key> Keys { get; set; }
    }

    public class Key
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }

}