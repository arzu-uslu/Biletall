using Biletall.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Xml;

namespace Biletall.MVC.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<SelectListItem> noktalar = GetNoktalar();
            SeferListModel model = new SeferListModel();
            model.Noktalar = noktalar;
            model.Tarih = DateTime.Now;
            return View(model);
        }
        public List<SelectListItem> GetNoktalar()
        {
            List<SelectListItem> Noktalar = null;
            var Context = System.Web.HttpContext.Current;
            try
            {
                if (Context.Cache["KaraNokta"] == null)
                {
                    DataSet dsKaraNokta = StringtoDataset("<KaraNoktaGetirKomut/>", "stajyerWS", "2324423WSs099");
                    if (dsKaraNokta != null)
                    {
                        Noktalar = new List<SelectListItem>() { new SelectListItem { Text = "Nokta Seçiniz...", Value = "0" } };
                        for (int i = 0; i < dsKaraNokta.Tables[0].Rows.Count; i++)
                        {
                            Noktalar.Add(new SelectListItem() { Text = dsKaraNokta.Tables[0].Rows[i]["Ad"].ToString(), Value = dsKaraNokta.Tables[0].Rows[i]["ID"].ToString() });
                        }
                        Context.Cache["KaraNokta"] = Noktalar;
                    }
                }
                else
                {
                    Noktalar = (List<SelectListItem>)Context.Cache["KaraNokta"];
                }
            }
            catch
            {
                Noktalar = new List<SelectListItem>() { new SelectListItem { Text = "Noktalar Getirilemedi", Value = "0" } };
            }
            return Noktalar;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Getir(int KalkisID, int VarisID, DateTime Tarih)
        {
            SeferListModel seferler = new SeferListModel();
            try
            {
                string istek = GetSeferRequest(KalkisID, VarisID, Tarih);
                List<SelectListItem> noktalar = GetNoktalar();
                seferler.Noktalar = noktalar;
                DataSet dsSefer = StringtoDataset(istek, "stajyerWS", "2324423WSs099");
                if (dsSefer != null)
                {
                    string cevapalt = "";
                    string cevap = dsSefer.Tables[0].Rows[0][1].ToString();
                    if (cevap.Contains("alternatif"))
                        cevapalt = dsSefer.Tables[2].Rows[0][1].ToString();
                    else
                    {
                        List<SeferModel> seferList = new List<SeferModel>();
                        for (int i = 0; i < dsSefer.Tables[0].Rows.Count; i++)
                        {
                            SeferModel sefer = new SeferModel
                            {
                                FirmaAdi = dsSefer.Tables[0].Rows[i]["FirmaAdi"].ToString(),
                                //YerelSaat=Convert.ToDateTime( dsSefer.Tables[0].Rows[i]["YerelSaat"]),
                                KalkisYeri= dsSefer.Tables[0].Rows[i]["KalkisYeri"].ToString(),
                                SonVarisNokta= dsSefer.Tables[0].Rows[i]["SonVarisNokta"].ToString(),
                                OtobusKoltukYerlesimTipi= dsSefer.Tables[0].Rows[i]["OtobusKoltukYerlesimTipi"].ToString(),
                                SeferTipiAciklamasi= dsSefer.Tables[0].Rows[i]["SeferTipiAciklamasi"].ToString(),
                                BiletFiyatiInternet = Convert.ToInt32(dsSefer.Tables[0].Rows[i]["BiletFiyatiInternet"].ToString()),
                               // YaklasikSeyahatSuresi = Convert.ToInt32(dsSefer.Tables[0].Rows[i]["SeyahatSuresiGosterimTipi"])== 1?Convert.ToDateTime(dsSefer.Tables[0].Rows[i]["YaklasikSeyahatSuresi"]):DateTime.MinValue
                            };
                            seferList.Add(sefer);
                            seferler.SeferList = seferList;
                        }

                        seferler.SeferList = seferList;
                        return View("Index", seferler);
                    }
                }
                return View("Index", seferler);

            }
            catch (Exception ex)
            {
                return View("Index", seferler);
            }

        }

        public XmlDocument StrtoXmldocument(string str)
        {
            XmlDocument xd = new XmlDocument();
            try
            {
                string str1 = str;
                xd.LoadXml(str1);
            }
            catch
            {

            }

            return xd;
        }
        public DataSet StringtoDataset(string xmlstring, string kullaniciadi, string sifre)
        {
            BiletallWebService.Service service = new BiletallWebService.Service();
            XmlNodeReader nr = new XmlNodeReader(service.XmlIslet(StrtoXmldocument(xmlstring).DocumentElement, StrtoXmldocument("<Kullanici><Adi>" + kullaniciadi + "</Adi><Sifre>" + sifre + "</Sifre></Kullanici>").DocumentElement));
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml(nr);
            }
            catch
            { }
            return ds;
        }

        public string GetSeferRequest(int kalkis,int varis,DateTime tarih)
        {
            try
            {
                string istek = @"<Sefer>
                                  <FirmaNo>0</FirmaNo>
                                  <KalkisNoktaID>" + kalkis + @"</KalkisNoktaID>
                                  <VarisNoktaID>" + varis + @"</VarisNoktaID>
                                  <Tarih>" + tarih.Year + "-" + tarih.Month + "-" + tarih.Day + @"</Tarih>
                                  <AraNoktaGelsin>1</AraNoktaGelsin>
                                  <IslemTipi>1</IslemTipi>
                                  <YolcuSayisi>1</YolcuSayisi>
                                  <Ip>127.0.0.1</Ip>
                                </Sefer>";
                return istek;
            }
            catch 
            {
                return null;
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}