using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities;

namespace YY.Frame.AbpCore.Persons
{
public class Book : Entity<long>
	{
		[Required]
		[MaxLength(32)]
		public virtual string Name { get; set; }

		[Required]
		[MaxLength(32)]
		public virtual string Surname { get; set; }

		[MaxLength(255)]
		public virtual string EmailAddress { get; set; }
	}
}
