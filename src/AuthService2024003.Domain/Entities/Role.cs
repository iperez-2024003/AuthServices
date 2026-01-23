
using System.ComponentModel.DataAnnotations;
namespace AuthService2024003.Domain.Entities;



public class Role
{
    [Key]
    [MaxLength(16)]



    public string Id {get; set;} = string.Empty;


    [Required(ErrorMessage = "El nombre del rol es obligatorio")]
    [MaxLength(100, ErrorMessage = "El nombre del  rol no se puede suoerar los 100 cracterres")]

    public string Name {get; set;} = string.Empty;

    public DateTime CreateAt {get; set;} = DateTime.UtcNow;

    public DateTime UpdateAt {get; set;}  = DateTime.UtcNow;

    public ICollection<UserRole> UserRoles {get; set;} = [];

    

}