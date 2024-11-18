using AutoMapper;
using N_Tier.Application.Models.Employee;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles
{
	public class EmployeProfile : Profile
	{
		public EmployeProfile()
		{
			CreateMap<CreateEmployeModel, Employee>();

			CreateMap<Employee, CreateEmployeModel>();

		}
	}
}
