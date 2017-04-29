using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AllegroWebAplication.AllegroApiService;
using AllegroWebAplication.AllegroModels;
using AllegroWebAplication.Providers.Interfaces;

namespace AllegroWebAplication.Providers
{
    public class AllegroApiWrapper : IAllegroApiWrapper
    {
        private string sessionHandler;
        private long versionKey;
        servicePortClient serviceClient;
        private long _userId;
        private long _serverTime;

        public AllegroApiWrapper(servicePortClient _sPC)
        {
            serviceClient = _sPC;
            GetLocalVersionKey();
            DoLogin();
        }

        public string DoLogin() //returns sessionhandler string and stores it in private field
        {
            sessionHandler = serviceClient.doLogin(Global.allegroLogin, Global.allegroPassword, 1, Global.allegroApiKey, versionKey, out _userId, out _serverTime);//Country code PL=1 (third parameter)
            return sessionHandler;
        }

        public long GetLocalVersionKey() //returns localVersion key of Api and stores it
        {
            var info = serviceClient.doQuerySysStatus(1, 1, Global.allegroApiKey, out versionKey);//Country code PL=1 (second parameter)
            return versionKey;
        }

        public AllegroSellItems GetMySellItems() //Returning items you are currently selling
        {
            SellItemStruct[] s;
            var response = serviceClient.doGetMySellItems(sessionHandler, null, null, null, 0, null, 0, 0, out s);
            var allegroSellItems = new AllegroSellItems() { sellItemsList = new List<SellItem>() };
            allegroSellItems.sellItemsCounter = response;
            foreach(var item in s)
            {
                allegroSellItems.sellItemsList.Add(new SellItem()
                {
                    itemId = item.itemId,
                    itemEndTimeLeft = item.itemEndTimeLeft,
                    itemPrice = Convert.ToDecimal(item.itemPrice[0].priceValue),
                    itemsLeft = item.itemStartQuantity - item.itemSoldQuantity,
                    itemThumbnailUrl = item.itemThumbnailUrl,
                    itemTitle = item.itemTitle,
                    itemViews = item.itemViewsCounter
                });
            }
            return allegroSellItems;
        }

        public AllegroSoldItems GetMySoldItems() //returning sold items
        {

            SoldItemStruct[] soldItems;
            var response = serviceClient.doGetMySoldItems(sessionHandler, null, null, "", 0, null, 0, 0, out soldItems);
            var allegroSoldItems = new AllegroSoldItems() { SoldItems = new List<SoldItem>() };
            allegroSoldItems.Counter = response;
            foreach(var item in soldItems)
            {
                allegroSoldItems.SoldItems.Add(new SoldItem()
                {
                    ItemId = item.itemId,
                    ItemTitle = item.itemTitle,
                    ItemPrice = Convert.ToDecimal(item.itemPrice[0].priceValue),
                    ItemQuantity = item.itemSoldQuantity,
                    ThumbNailUrl = item.itemThumbnailUrl,
                    ItemBuyer = new Buyer()
                    {
                        UserId = item.itemHighestBidder.userId,
                        UserLogin = item.itemHighestBidder.userLogin
                    }
                });
            }
            return allegroSoldItems;
        }

        public AllegroWonItems GetMyWonItems()
        {
            var allegroWonItems = new AllegroWonItems() { WonItems = new List<WonItem>() };
            WonItemStruct[] wonList;
            var response = serviceClient.doGetMyWonItems(sessionHandler, null, null, 0, null, 0, 0, out wonList);
            allegroWonItems.Counter = response;
            foreach (var item in wonList)
            {
                allegroWonItems.WonItems.Add(new WonItem()
                {
                    ItemId = item.itemId,
                    ItemPrice = Convert.ToDecimal(item.itemPrice[0].priceValue), // I do not get it how you can get whole array of prices for single product same for above 
                    ItemQuantity = item.itemBoughtQuantity,
                    ItemSeller = new ItemSeller()
                    {
                        SellerId = item.itemSeller.userId,
                        SellerLogin = item.itemSeller.userLogin
                    },
                    ItemTitle = item.itemTitle,
                    ThumbNailUrl = item.itemThumbnailUrl
                });
            }

            return allegroWonItems;
        }
    }
}