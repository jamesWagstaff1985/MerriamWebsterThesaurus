namespace MyProject.Models
{
    public interface IUser
    {
        int Id { get; set; }
        string Password { get; set; }
        string Username { get; set; }
    }
}