using Entity.Abstract;

using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Entity.Abstract.Enums;

namespace Service.HaberSiteleri
{
	public class BBC : IHaberSitesi
	{
		public IWebDriver driver { get; set; }
		public Enums.Kategoriler Kategori { get; set; }
		public BBC(IWebDriver driver, Kategoriler kategori)
		{
			this.Kategori = kategori;
			this.driver = driver;
		}
		public string? GetBaslik(string js)
		{
			var list = driver.JsRun(js) as string;
			if (list != null)
			{
				return list;
			}
			return null;
		}
		public string? GetIcerik(string js)
		{
			var icerikList = driver.JsRun(js) as string;
			if (icerikList != null)
				return icerikList;
			return null;
		}
		public DateTime? GetTarih(string js)
		{
			string tarih = driver.JsRun(js) as string;
			if (tarih != null)
			{

				DateTime time = DateTime.Parse(tarih);
				return time;
			}
			return null;
		}
	}
}



//Tarih bbc return document.querySelectorAll('.bbc-1dafq0j.e1mklfmt0')[0].getAttribute('datetime');
//Icerik bb return document.querySelectorAll('[role=main] > div > p, [role=main] > div > h2');
//baslik bbc @$"return document.querySelector('#content').innerText; "