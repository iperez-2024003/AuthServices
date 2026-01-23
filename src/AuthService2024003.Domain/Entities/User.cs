using System.ComponentModel.DataAnnotations;

namespace AuthService2024003.Domain.Entities;

public class User
{
    [Key]
    [MaxLength(16)]
    public string Id {get; set; } = string.Empty;

    [Required(ErrorMessage ="El nombre es obligatorio")]
    [MaxLength(25,ErrorMessage = "El nombre no puede tner mas de 25 caracteres")]
     public string Name {get; set; } = string.Empty;

    [Required(ErrorMessage ="El Apellido es obligatorio")]
    [MaxLength(25,ErrorMessage = "El Apellido no puede tner mas de 25 caracteres")]
     public string Surname {get; set; } = string.Empty;

    [Required(ErrorMessage ="El Usuario es obligatorio")]
    [MaxLength(25,ErrorMessage = "El Usuario no puede tner mas de 25 caracteres")]
     public string Username {get; set; } = string.Empty;


    [Required(ErrorMessage = "El correo electronico es obligatorio")]
    [EmailAddress(ErrorMessage = "El correo electronico no tiene un")]
    [MaxLength(150, ErrorMessage = "El correo no puede")]
    public string Email {get; set; } = string.Empty;

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [MinLength(8, ErrorMessage = "s")]
    [MaxLength(255, ErrorMessage = "La contra no puede tener mas caracteres")]
    public string password {get; set; } = string.Empty;


    public bool Status {get; set;} = false;

    public DateTime CreateAt {get; set;} 

    public DateTime UpdateAt {get; set;} 

    public UserProfile UserProfile {get; set;} = null!;

    public ICollection<UserRole> UserRoles {get; set;} = [];

    public UserEmail UserEmail {get; set;} = null!;
    
    public UserPasswordReset UserPasswordReset {get; set;} = null!;




}