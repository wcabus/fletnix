using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fletnix.Domain
{
    public class SubscriptionOptionTemplate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, EnumDataType(typeof(OptionType))]
        public OptionType OptionTypeId { get; set; }

        [Required, StringLength(32)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}