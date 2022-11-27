using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Conc;
public class HaberSitesiModel
{
	[Key]
	public string Name { get; set; }
	public virtual List<Kategoriler>? Kategoriler { get; set; }
}
