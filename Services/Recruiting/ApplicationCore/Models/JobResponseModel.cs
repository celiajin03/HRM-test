using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
	public class JobResponseModel
	{
        public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime? StartDate { get; set; }
		public int NumberOfPositions { get; set; }
		
		public Guid JobCode { get; set; }

		public bool? IsActive { get; set; }

		[DisplayFormat(DataFormatString = "{0:dddd d MMMM}", ApplyFormatInEditMode = true)]
		public DateTime? CreatedOn { get; set; }
	}
}

