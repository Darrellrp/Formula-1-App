using System;
namespace Formula_1_API.Models
{
    public class ResultStatus : IIdentifier
    {
        public int? Id { get; set; }
        public string Status { get; set; }

        public ResultStatus()
        {
        }
    }
}
