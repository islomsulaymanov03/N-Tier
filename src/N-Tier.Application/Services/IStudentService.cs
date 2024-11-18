using N_Tier.Application.Models.TodoItem;
using N_Tier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Student;
using N_Tier.Core.Entities;

namespace N_Tier.Application.Services
{
	public interface IStudentService
	{
	
		Task<CreateStudentResponseModel> CreateAsync(CreateStudentModel createStudentModel,
	CancellationToken cancellationToken = default);

		Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

		Task<IEnumerable<StudentResponseModel>>
			GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);
		Task<UpdateStudentResponseModel> UpdateAsync(Guid id, UpdateStudentModel updateStudentModel,
			CancellationToken cancellationToken = default);
	}
}
