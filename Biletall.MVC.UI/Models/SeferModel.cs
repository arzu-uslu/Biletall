using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biletall.MVC.UI.Models
{
    public class SeferModel
    {
		public int ID { get; set; }

		public string Vakit { get; set; }

		public int FirmaNo { get; set; }

		public string FirmaAdi { get; set; }

		public DateTime YerelSaat { get; set; }

		public DateTime YerelInternetSaat { get; set; }

		public DateTime Tarih { get; set; }

		public int GunBitimi { get; set; }

		public DateTime Saat { get; set; }

		public int HatNo { get; set; }

		public string IlkKalkisYeri { get; set; }

		public string SonVarisYeri { get; set; }

		public string KalkisYeri { get; set; }

		public string VarisYeri { get; set; }

		public int IlkKalkisNoktaID { get; set; }

		public string IlkKalkisNokta { get; set; }

		public int KalkisNoktaID { get; set; }

		public string KalkisNokta { get; set; }

		public int VarisNoktaID { get; set; }

		public string VarisNokta { get; set; }

		public int SonVarisNoktaID { get; set; }

		public string SonVarisNokta { get; set; }

		public int OtobusTipi { get; set; }

		public string OtobusKoltukYerlesimTipi { get; set; }

		public string OTipAciklamasi { get; set; }

		public string OtobusTelefonu { get; set; }

		public object OtobusPlaka { get; set; }

		public DateTime SeyahatSuresi { get; set; }

		public int SeyahatSuresiGosterimTipi { get; set; }

		public DateTime YaklasikSeyahatSuresi { get; set; }

		public int BiletFiyati1 { get; set; }

		public int BiletFiyatiInternet { get; set; }

		public int SinifFarki { get; set; }

		public int MaxRzvZamani { get; set; }

		public object SeferTipi { get; set; }

		public string SeferTipiAciklamasi { get; set; }

		public object HatSeferNo { get; set; }

		public int OTipSinif { get; set; }

		public int SeferTakipNo { get; set; }

		public int ToplamSatisAdedi { get; set; }

		public int DolulukKuraliVar { get; set; }

		public double OTipOzellik { get; set; }

		public int NormalBiletFiyati { get; set; }

		public int DoluSeferMi { get; set; }

		public string Tesisler { get; set; }

		public int SeferBosKoltukSayisi { get; set; }

		public object KalkisTerminalAdiSaatleri { get; set; }

		public DateTime MaximumRezerveTarihiSaati { get; set; }

		public string Guzergah { get; set; }

		public bool KKZorunluMu { get; set; }
	}
}