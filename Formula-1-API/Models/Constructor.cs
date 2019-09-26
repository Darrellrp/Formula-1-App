using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula_1_API.Models
{
    public class Constructor : IIdentifier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Ref { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string Url { get; set; }

        public Constructor()
        {
        }
    }
}
