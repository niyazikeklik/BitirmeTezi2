using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Entity.Abstract.Enums;

namespace Entity.Abstract
{
	public interface IHaberSitesi
	{
		IWebDriver driver { get; set; }
		public string GetBaslik(string js);
		public DateTime? GetTarih(string js);
		public string GetIcerik(string js);

	}
}
