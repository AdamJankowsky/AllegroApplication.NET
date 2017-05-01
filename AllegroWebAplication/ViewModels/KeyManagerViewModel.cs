using AllegroWebAplication.KeySenderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllegroWebAplication.ViewModels
{
    public class KeyManagerViewModel : KeyManagerModel
    {
        public new int? Id { get; set; }
        public new List<KeyManagerKeyViewModel> Keys { get; set; }
    }

    public class KeyManagerKeyViewModel : Key
    {
        public new int? Id { get; set; }
    }
}