using AutoLotDAL_Core2.Models.Base;
using System.ComponentModel.DataAnnotations;
namespace AutoLotDAL_Core2.Models
{
    public partial class CreditRisk : EntityBase
    {
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
    }
}