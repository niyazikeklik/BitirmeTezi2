using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Conc
{
	public class Haber
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string? Kaynak { get; set; }

		public string? Baslik { get; set; }

		public DateTime? Tarih { get; set; }

		public string? Kategori { get; set; }

		public string? Icerik { get; set; }

		public bool IsValid()
		{
			if (string.IsNullOrEmpty(Baslik) || string.IsNullOrEmpty(Kaynak) || string.IsNullOrEmpty(Kategori) || string.IsNullOrEmpty(Icerik))
			{
				return false;
			}
			return true;
		}

	}
}
