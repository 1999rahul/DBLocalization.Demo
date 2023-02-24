using System.ComponentModel.DataAnnotations.Schema;

namespace DBLocalization.Demo.WebAPI.Models
{
    [Table("Languages")]
    public partial class Language
    {
        public Language()
        {
            StringResources = new HashSet<StringResource>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }

        public ICollection<StringResource>? StringResources { get; set; }
    }
}
