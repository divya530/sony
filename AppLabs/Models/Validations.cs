using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppLabs.Models
{
    [MetadataType(typeof(tblEmployeeMetaData))]
    public partial class tblEmployee
    {
    }
    public partial class tblEmployeeMetaData
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }


        [Required]
        [StringLength(10)]
        public string DrivingLicense { get; set; }

        [Required]
        public string IsInternalEmployee { get; set; }



    }
}
   
