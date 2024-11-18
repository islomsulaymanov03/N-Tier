using N_Tier.Application.Models.TodoItem;
using N_Tier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Teacher;

namespace N_Tier.Application.Services
{
	public interface ITeacherService
	{
		Task<CreateTeacherResponseModel> CreateAsync(CreateTeacherModel createTeacherModel,
	CancellationToken cancellationToken = default);

		Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

		Task<IEnumerable<TeacherResponseModel>>
			GetAll();

		Task<UpdateTeacherResponseModel> UpdateAsync(Guid id, UpdateTeacherModel updateTeacherModel,
			CancellationToken cancellationToken = default);
	}
}
