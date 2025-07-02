using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dtos
{
    public class TodoCreateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }
    }
}
