namespace SohaNotebook.Dtos.Incomming
{
    public class UserDto
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string DateOfBirth { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }

        public required string Country { get; set; }
    }
}
