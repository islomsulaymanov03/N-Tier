using N_Tier.Application.Models.TodoItem;
using N_Tier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Grades;
using N_Tier.Application.Models.Exam;

namespace N_Tier.Application.Services
{
	public interface IGradesService
	{
		Task<CreateGradesResponseModel> CreateAsync(CreateGradesModel createGradeModel,
	CancellationToken cancellationToken = default);

		Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

		Task<IEnumerable<GradeResponseModel>>
			GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

		Task<UpdateGradeResponseModel> UpdateAsync(Guid id, UpdateGradesModel updateExamModel,
			CancellationToken cancellationToken = default);
	}
}
