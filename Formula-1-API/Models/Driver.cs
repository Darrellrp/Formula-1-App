using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula_1_API.Models
{
    public class Driver : IIdentifier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Ref { get; set; }
        public int? Number { get; set; }
        public string Code { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Dob { get; set; } // Date of Birth
        public string Nationality { get; set; }
        public string Url { get; set; }

        public Driver() { }


    }
}
