namespace OfficeFoosball.DAL.Entities
{
    public class RefreshToken : Entity
    {
        public string Token { get; set; }
        public virtual User User { get; set; }  
        public string UserId { get; set; }      
    }
}
