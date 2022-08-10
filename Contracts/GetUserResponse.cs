namespace FrontTest.Contracts
{
    public class GetUserResponse
    {
        public Guid Id { get; set; }
        public string? Phone { get; set; }
        public string? Name { get; set; }
        public string? Birth { get; set; }
        public string? Tg { get; set; }
        public string? Email { get; set; }
    }
}
