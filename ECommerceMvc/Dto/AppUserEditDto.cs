namespace ECommerceMvc.Dto
{
    public class AppUserEditDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }
        public int ConfirmPassword { get; set; }
    }
}
