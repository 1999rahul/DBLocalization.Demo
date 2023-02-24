using System.ComponentModel.DataAnnotations.Schema;

namespace DBLocalization.Demo.WebAPI.Models
{
    [Table("StringResources")]
    public partial class StringResource
    {
        public int Id { get; set; }
        
        public int? LanguageId { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }

        public Language? Language { get; set; }
    }
}
