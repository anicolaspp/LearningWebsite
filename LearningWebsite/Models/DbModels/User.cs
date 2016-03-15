namespace LearningWebsite.Models.DbModels
{
    public class User
    {
        public int Id { get; set; }
        public bool IsValid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}