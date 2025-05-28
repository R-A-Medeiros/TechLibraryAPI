using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCxLabs.TechLibraryAPI.Domain.Communication.Requests
{
    public class RequestUpdateAuthorJson
    {
        [Required]
        [MinLength(5)]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        public DateTime Birth { get; set; }
        public string? Nationality { get; set; }
    }
}
