using AllegroWebAplication.KeySenderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllegroWebAplication.ViewModels
{
    public class KeyManagerViewModel 
    {
        public int Id { get; set; }
        public string ManagerName { get; set; }
        public long AuctionId { get; set; }
        public int NumOfKeys { get; set; }
    }

    
}