using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.DTOs
{
    public class StudentDto
    {
        [MaybeNull]
        public int ID { get; set; }
        [NotNull]
        public int Age { get; set; }
        [StringLength(20,MinimumLength =3)]
        public string FirstMidName { get; set; }
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }
       
    }
}
