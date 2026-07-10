namespace dotnet_bookish_starter.Models;

public class User
{
    public int UserID { get; set; }
    public string Name { get; set; }  = string.Empty;
    public string Email { get; set; }  = string.Empty;
    public string Password_hash { get; set; }  = string.Empty;

    public User()
    {
        
    }

    public User(int UserID, string Name, string Email, string Password_hash)
    {
        this.UserID = UserID;
        this.Name = Name;
        this.Email = Email;
        this.Password_hash = Password_hash;
    }
}