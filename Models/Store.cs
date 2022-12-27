using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace information.Models
{
    public class Store
    {

        public int Id { get; set; }

        [StringLength(5)]
        [Required(ErrorMessage = "الرجاء إدخال اسم الشخص")]
        public string? Name { get; set; }

        [StringLength(5)]

        public string? FamilyName { get; set; }

        [StringLength(10)]
        [Required]
        public string? Address { get; set; }

        public string? CountryOfOrigin { get; set; }
        [EmailAddress]
        [Required]
        public string? EMailAdress { get; set; }
        [Range(20, 60)]
        [Required]
        public int Age { get; set; }
        public bool Hired { get; set; }
    }
}

