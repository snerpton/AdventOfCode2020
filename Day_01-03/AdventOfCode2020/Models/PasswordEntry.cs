using AdventOfCode2020.Repositories;

namespace AdventOfCode2020.Models
{
    public class PasswordEntry
    {
        public PasswordPolicy PwPolicy { get; set; }
        public string Password { get; set; }
    }
}