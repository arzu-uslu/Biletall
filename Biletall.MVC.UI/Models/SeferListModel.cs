using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biletall.MVC.UI.Models
{
    public class SeferListModel
    {
        public List<SeferModel> SeferList { get; set; }
        public List<TipOzellikModel> OzellikList { get; set; }

        public List<SelectListItem> Noktalar { get; set; }
        public int KalkisID { get; set; }
        public int VarisID { get; set; }
        public DateTime Tarih { get; set; }
    }
}