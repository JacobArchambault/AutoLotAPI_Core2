using AutoLotDAL_Core2.Models.Metadata;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
namespace AutoLotDAL_Core2.Models
{
    [ModelMetadataType(typeof(InventoryMetaData))]
    public partial class Inventory
    {
        public override string ToString()
        {
            return $"{PetName ?? "**No Name **"} is a {Color} {Make} with ID {Id}.";
        }
        [NotMapped]
        public string MakeColor => $"{Make} ({Color})";
    }
}