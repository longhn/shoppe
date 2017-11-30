using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace shoppe
{
    public class ShopPromotion
    {
        string id;
        string shopName;
        string shopImageUrl;
        string promotion;
        string location;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [Version]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "shopName")]
        public string ShopName
        {
            get { return shopName; }
            set { shopName = value; }
        }

        [JsonProperty(PropertyName = "shopImageUrl")]
        public string ShopImageUrl
        {
            get { return shopImageUrl; }
            set { shopImageUrl = value; }
        }

        [JsonProperty(PropertyName = "promotion")]
        public string Promotion
        {
            get { return promotion; }
            set { promotion = value; }
        }

        [JsonProperty(PropertyName = "location")]
        public string Location
        {
            get { return location; }
            set { location = value; }
        }
    }
}
