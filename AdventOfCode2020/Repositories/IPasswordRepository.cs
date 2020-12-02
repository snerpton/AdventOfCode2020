using System.Collections.Generic;
using AdventOfCode2020.Models;

namespace AdventOfCode2020.Repositories
{
    public interface IPasswordRepository
    {
        IEnumerable<PasswordEntry> ReadFile();
    }
}