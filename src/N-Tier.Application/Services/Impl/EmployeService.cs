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
using N_Tier.Application.Models.Employee;
using N_Tier.Application.Common.Email;

namespace N_Tier.Application.Services.Impl
{
	partial class EmployeService:IEmployeService
	{
		private readonly IClaimService _claimService;
		private readonly IMapper _mapper;
		private readonly IEmployeRepository _employeRepository;
		private object updateTodoListModel;

		public EmployeService(IEmployeRepository employeRepository, IClaimService claimService,
			IMapper mapper)
		{
			_employeRepository = employeRepository;
			_claimService = claimService;
			_mapper = mapper;
		}

		public async Task<CreateExamResponseModel> CreateAsync(CreateEmployeModel createStudentModel, CancellationToken cancellationToken = default)
		{
			var todoList = _mapper.Map<Employee>(createStudentModel);

			var addedTodoList = await _employeRepository.AddAsync(todoList);

			return new CreateExamResponseModel
			{
				Id = addedTodoList.Id
			};
		}

		public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
		{
			var todoList = await _employeRepository.GetFirstAsync(tl => tl.Id == id);

			return new BaseResponseModel
			{
				Id = (await _employeRepository.DeleteAsync(todoList)).Id
			};
		}

		public async Task<IEnumerable<EmployeResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
		{
			var currentUserId = _claimService.GetUserId();

			var todoLists = await _employeRepository.GetAllAsync(tl => tl.CreatedBy == currentUserId);

			return _mapper.Map<IEnumerable<EmployeResponseModel>>(todoLists);
		}

		public async Task<UpdateEmployeResponseModel> UpdateAsync(Guid id, UpdateEmployeModel updateStudentModel, CancellationToken cancellationToken = default)
		{
			var todoList = await _employeRepository.GetFirstAsync(tl => tl.Id == id);

			var userId = _claimService.GetUserId();

			if (userId != todoList.CreatedBy)
				throw new BadRequestException("The selected list does not belong to you");

			todoList.Title = updateTodoListModel;

			return new UpdateEmployeResponseModel
			{
				Id = (await _employeRepository.UpdateAsync(todoList)).Id
			};
		}

		Task<CreateEmployeResponseModel> IEmployeService.CreateAsync(CreateEmployeModel createEmployeeModel, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
