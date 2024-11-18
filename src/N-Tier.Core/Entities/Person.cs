using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities
{
	public class Person:BaseEntity
	{
		public string Name { get; set; }
		public int Age { get; set; }

	}
}
