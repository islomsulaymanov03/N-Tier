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
using N_Tier.Application.Models.Exam;

namespace N_Tier.Application.Services.Impl
{
	partial class ExamService:IExamService
	{
		private readonly IClaimService _claimService;
		private readonly IMapper _mapper;
		private readonly IExamRepository _examRepository;
		private object updateTodoListModel;

		public ExamService(IExamRepository examRepository, IClaimService claimService,
			IMapper mapper)
		{
			_examRepository = examRepository;
			_claimService = claimService;
			_mapper = mapper;
		}

		public async Task<CreateExamResponseModel> CreateAsync(CreateExanModel createStudentModel, CancellationToken cancellationToken = default)
		{
			var todoList = _mapper.Map<Exam>(createStudentModel);

			var addedTodoList = await _examRepository.AddAsync(todoList);

			return new CreateExamResponseModel
			{
				Id = addedTodoList.Id
			};
		}

		public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
		{
			var todoList = await _examRepository.GetFirstAsync(tl => tl.Id == id);

			return new BaseResponseModel
			{
				Id = (await _examRepository.DeleteAsync(todoList)).Id
			};
		}

		public async Task<IEnumerable<ExamResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
		{
			var currentUserId = _claimService.GetUserId();

			var todoLists = await _examRepository.GetAllAsync(tl => tl.CreatedBy == currentUserId);

			return _mapper.Map<IEnumerable<ExamResponseModel>>(todoLists);
		}
		public async Task<UpdateExamResponseModel> UpdateAsync(Guid id, UpdateExamModel updateStudentModel, CancellationToken cancellationToken = default)
		{
			var todoList = await _examRepository.GetFirstAsync(tl => tl.Id == id);

			var userId = _claimService.GetUserId();

			if (userId != todoList.CreatedBy)
				throw new BadRequestException("The selected list does not belong to you");

			todoList.Title = updateTodoListModel;

			return new UpdateExamResponseModel
			{
				Id = (await _examRepository.UpdateAsync(todoList)).Id
			};
		}
	}
}
