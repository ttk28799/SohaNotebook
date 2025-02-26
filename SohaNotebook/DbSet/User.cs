﻿namespace SohaNotebook.DbSet
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Country { get; set; }

    }
}
