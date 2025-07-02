// Dtos/TodoUpdateDto.cs
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dtos
{
    public class TodoUpdateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }
    }
}
