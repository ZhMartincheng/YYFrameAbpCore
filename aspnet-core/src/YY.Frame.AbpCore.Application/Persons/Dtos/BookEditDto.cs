
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using YY.Frame.AbpCore.Persons;

namespace  YY.Frame.AbpCore.Persons.Dtos
{
    public class BookEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// Name
		/// </summary>
[MaxLength(32)]
		[Required(ErrorMessage="Name不能为空")]
		public string Name { get; set; }



		/// <summary>
		/// Surname
		/// </summary>
[MaxLength(32)]
		[Required(ErrorMessage="Surname不能为空")]
		public string Surname { get; set; }



		/// <summary>
		/// EmailAddress
		/// </summary>
[MaxLength(255)]
		public string EmailAddress { get; set; }




    }
}