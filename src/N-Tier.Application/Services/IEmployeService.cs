using N_Tier.Application.Models.TodoItem;
using N_Tier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Employee;

namespace N_Tier.Application.Services
{
	public interface IEmployeService
	{
		Task<CreateEmployeResponseModel> CreateAsync(CreateEmployeModel createEmployeeModel,
	CancellationToken cancellationToken = default);

		Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

		Task<IEnumerable<EmployeResponseModel>>
			GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

		Task<UpdateEmployeResponseModel> UpdateAsync(Guid id, UpdateEmployeModel updateEmployeModel,
			CancellationToken cancellationToken = default);
	}
}
