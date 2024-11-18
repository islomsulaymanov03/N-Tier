using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities
{
	public class Lesson:BaseEntity
	{
		public Guid TeacherId { get; set; }
		public IEnumerable<Student> Students { get; set; }
		public string CreatedBy { get; set; }
		public object Title { get; set; }
	}
}
