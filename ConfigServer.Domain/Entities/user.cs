namespace ConfigServer.Domain.Entities

public class user {
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    
    //public string role { get; set;} 

     public User(string email, string password)
    {
        Email = email;
        Password = password;
    }


}