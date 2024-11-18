using AutoMapper;
using N_Tier.Application.Models.Teacher;
using N_Tier.Application.Models.TodoList;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.MappingProfiles
{
	public class TeacherProfile: Profile
	{
        public TeacherProfile()
        {
			CreateMap<CreateTeacherModel, Teacher>();

			CreateMap<Teacher, CreateTeacherModel>();
		}
    }
}
