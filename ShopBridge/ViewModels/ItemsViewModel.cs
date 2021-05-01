using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.ViewModels
{
    public class ItemsViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Item Items { get; set; }
    }
}