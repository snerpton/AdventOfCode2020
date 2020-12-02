using AdventOfCode2020.Models;

namespace AdventOfCode2020.Services
{
    public interface IPasswordReportService
    {
        int NumberOfInvalidPasswords();

        bool ValidatePassword(PasswordEntry passwordEntry);
    }
}