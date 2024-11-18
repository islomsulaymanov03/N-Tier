using AutoMapper;
using N_Tier.Application.Exceptions;
using N_Tier.Application.Models.Student;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;
using N_Tier.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Grades;

namespace N_Tier.Application.Services.Impl
{
	public class GradesService:IGradesService
	{
		private readonly IClaimService _claimService;
		private readonly IMapper _mapper;
		private readonly IGradesRepository _gradesRepository;
		private object updateTodoListModel;

		public GradesService(IGradesRepository gradesRepository, IClaimService claimService,
			IMapper mapper)
		{
			_gradesRepository = gradesRepository;
			_claimService = claimService;
			_mapper = mapper;
		}

		public async Task<CreateGradesResponseModel> CreateAsync(CreateGradesModel createStudentModel, CancellationToken cancellationToken = default)
		{
			var todoList = _mapper.Map<Grades>(createStudentModel);

			var addedTodoList = await _gradesRepository.AddAsync(todoList);

			return new CreateGradesResponseModel
			{
				Id = addedTodoList.Id
			};
		}

		public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
		{
			var todoList = await _gradesRepository.GetFirstAsync(tl => tl.Id == id);

			return new BaseResponseModel
			{
				Id = (await _gradesRepository.DeleteAsync(todoList)).Id
			};
		}

		public async Task<IEnumerable<GradeResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
		{
			var currentUserId = _claimService.GetUserId();

			var todoLists = await _gradesRepository.GetAllAsync(tl => tl.CreatedBy == currentUserId);

			return _mapper.Map<IEnumerable<GradeResponseModel>>(todoLists);
		}
		public async Task<UpdateGradeResponseModel> UpdateAsync(Guid id, UpdateGradesModel updateStudentModel, CancellationToken cancellationToken = default)
		{
			var todoList = await _gradesRepository.GetFirstAsync(tl => tl.Id == id);

			var userId = _claimService.GetUserId();

			if (userId != todoList.CreatedBy)
				throw new BadRequestException("The selected list does not belong to you");

			todoList.Title = updateTodoListModel;

			return new UpdateGradeResponseModel
			{
				Id = (await _gradesRepository.UpdateAsync(todoList)).Id
			};
		}
	}
}
