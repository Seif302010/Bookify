using Bookify.Core.Consts;
using System.ComponentModel;

namespace Bookify.Core.ViewModels
{
    public class UnifiedFormViewModel
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = Errors.MAxLength)]
        [Remote("AllowItem", null!, AdditionalFields = "Id", ErrorMessage = Errors.Dublicated)]
        public string Name { get; set; } = null!;

    }
}


