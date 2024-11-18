using N_Tier.Core.Common;

namespace N_Tier.Core.Entities
{
	public class Teacher : BaseEntity, IAuditedEntity
	{
		public int Salary { get; set; }
		public Person Person { get; set; }
		public IEnumerable<Lesson> Lessons { get; set; }
		public string CreatedBy { get; set; }

		public DateTime CreatedOn { get; set; }

		public string UpdatedBy { get; set; }

		public DateTime? UpdatedOn { get; set; }
	}
}
