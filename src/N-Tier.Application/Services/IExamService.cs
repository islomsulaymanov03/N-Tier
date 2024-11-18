using N_Tier.Application.Models.TodoItem;
using N_Tier.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Exam;

namespace N_Tier.Application.Services
{
	public interface IExamService
	{
		Task<CreateExamResponseModel> CreateAsync(CreateExanModel createExamModel,
	CancellationToken cancellationToken = default);

		Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

		Task<IEnumerable<ExamResponseModel>>
			GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

		Task<UpdateExamResponseModel> UpdateAsync(Guid id, UpdateExamModel updateExamModel,
			CancellationToken cancellationToken = default);
	}
}
