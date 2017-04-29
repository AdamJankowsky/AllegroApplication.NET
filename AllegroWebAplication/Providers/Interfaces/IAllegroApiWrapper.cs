using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllegroWebAplication.AllegroModels;

namespace AllegroWebAplication.Providers.Interfaces
{
    interface IAllegroApiWrapper
    {
        string DoLogin();
        long GetLocalVersionKey();
        AllegroSellItems GetMySellItems();
        AllegroSoldItems GetMySoldItems();
        AllegroWonItems GetMyWonItems();
    }
}
