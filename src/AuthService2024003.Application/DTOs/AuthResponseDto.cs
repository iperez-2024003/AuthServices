namespace AuthService2024003.Application.DTOs;

public class AuthResponseDto
{
    public bool Sucess {get; set;} = false;
    public string Message {get; set;} = string.Empty;
    public string Token {get; set;} = string.Empty;
    public UserDetailsDto UserDetails {get; set;} = new();
    public DateTime ExpireAt {get; set;}
    
    

}