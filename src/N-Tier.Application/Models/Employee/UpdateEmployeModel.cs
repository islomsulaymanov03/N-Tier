using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Employee
{
	public class UpdateEmployeModel
	{
		public string FullName { get; set; }
	}
	public class UpdateEmployeResponseModel : BaseResponseModel { }
}
