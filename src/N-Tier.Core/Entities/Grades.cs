using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities
{
	public class Grades:BaseEntity
	{
		public int GradesPrice {  get; set; }
		public Student Student { get; set; }
		public Teacher Teacher { get; set; }
		public Lesson Lesson { get; set; }
		public string CreatedBy { get; set; }
		public object Title { get; set; }
	}
}
