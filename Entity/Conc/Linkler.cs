using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Conc;
public class Linkler
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Key]
	public string Id { get; set; }
	public string HaberSitesi { get; set; }
	public string URL { get; set; }
	public bool Check { get; set; }
}
