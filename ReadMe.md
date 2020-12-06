# Advent of Code 2020

More information about Advent of Code can be found at https://adventofcode.com/2020.



## My Aims for Advent of Code 2020

- Use .Net 5 / and latest versions of C#
- Use Visual Studio for Mac and Rider
- TDD with `decent` code coverage



## Project Notes

- Taking a break on a tropical island
- Island is cash only
- Local currency is 'Starfish', often abbreviated to 'stars'
- No currency exchanges deal in stars, so only way to obtain enough stars for deposit is to solve puzzles
- Need 50 stars to pay for room deposit in 25 days time
- Two puzzles per day, with each puzzle paying 1 star



## Day 1

- Elves need me to fix my 'expense report' (puzzle input) before leaving on vacation
- Requirement: need to find the two entries that sum to 2020, and then multiply them together. This number is what we are looking for.
- Example: in list:

  - 1721
  - 979
  - 366
  - 299
  - 675
  - 1456

  Answer would be 514579 as (1721 + 299) = 2020 and (1721 x 299) = 514579
  


## Day 2

- Password database corrupted
- List of password provided in following format:

  - 1-3 a: abcde
  - 1-3 b: cdefg
  - 2-9 c: ccccccccc
  
  where the row is made up of a password policy and password delimited my a `:` character. A policy of `1-3 a` indicates `a` must be used 1-3 times in the password. The first and last passwords are valid, but the second one isn't valid as `b` doesn't occur 1-3 times in `cdefg`.
  
 - Requirement: How many passwords are valid according to their policies?
 
 
 
 ### Part 2
 
 - Requirement: password policy of part 1 incorrect, numbers describe positions not occurrence count, such that:
   - `1-3 a: abcde` is valid: position 1 contains a and position 3 does not.
   - `1-3 b: cdefg` is invalid: neither position 1 nor position 3 contains b.
   - `2-9 c: ccccccccc` is invalid: both position 2 and position 9 contain c.
   
   Exactly one of these positions must contain the specified letter.
  
   
   
 ## Day 3
 
 - Puzzle input is a map of trees where `.` represents open space, and `#` represents a tree.
 - Trees grow on a grid pattern.
 - Pattern repeats horizontally.
 - Navigate from top-left to off bottom of map in a move right 3 places and down 1. In this way you navigate diagonally downward.
 - Aim of puzzle is to count the number of trees you stop on i.e. after the 3-right 1-down move.
 
 
 
 ## Day 4
 
 - Passprts have following fields:
   
   - byr (Birth Year)
   - iyr (Issue Year)
   - eyr (Expiration Year)
   - hgt (Height)
   - hcl (Hair Color)
   - ecl (Eye Color)
   - pid (Passport ID)
   - cid (Country ID)
   
 - North Pole Credentials are the same as a passport, but without the `cid` field.
 - Scanner processes passports in batch files (puzzle input).
 - Passport made up of `key:value` pairs separated by spaces or new lines. Passports are separated by new lines.
 - Example batch file:
   ```
   ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
   byr:1937 iyr:2017 cid:147 hgt:183cm
   
   iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
   hcl:#cfa07d byr:1929
   
   hcl:#ae17e1 iyr:2013
   eyr:2024
   ecl:brn pid:760753108 byr:1931
   hgt:179cm
   
   hcl:#cfa07d eyr:2025 pid:166559648
   iyr:2011 ecl:brn hgt:59in 
   ```
   where: 
   
   - passport 1 is valid as all fields are present
   - passport 2 is invalid as `hgt` field is missing
   - passport 3 is in valid as `cid` filed is missing
   - passport 4 is invalid as `cid` and `byr` fields missing.
   
 - As a one-off we should also treat the `cid` as optional, and hence allow North Pole Credentials to be used like a passport i.e passport 3 should be treated as apassport even though it is a North Pole Credential
 - Requirement: how many passports are valid there? 
 
 
 
## Day 5
 
- Your airline you are using to fly to the tropical island identifies your seat using a `binary space partition` map where:

  - `F` indicates front
  - `B` indicates back
  - `L` indicates left
  - `R` indicates
  
 - First 7 characters of your sead number will be either `F` or `B`, and the final 3 `L` or `R` where:
 
   - `L` indicates left
   - `R` indicates right
   
 - First 7 characters describe which row of 0- 128 you are in.
 - Last 3 characters describe which column of 0-7 you are in.
 - Seat ID is calculated by (row x 8 + col)
 - Example boarding passes are:
 
 Here are some other boarding passes:
 
   - `FBFBBFFRLR`: row 44, column 5, seat ID (44 * 8 + 5) = 357
   - `BFFFBBFRRR`: row 70, column 7, seat ID 567.
   - `FFFBBBFRRR`: row 14, column 7, seat ID 119.
   - `BBFFBBFRLL`: row 102, column 4, seat ID 820.
 
 - Requirement: What is the highest seat ID on a boarding pass (puzzle input)?
 
 ### Part 2
 
 - Boarding pass list missing items from front and back as these seats don't exist on this plane.
 - Occupied seats is continuous apart from where I'm sitting (ID+1 and -1 will be in my list).
 - Requirement: what is my seat ID?
 
 My thinking:
 - Seat ID is effectively seat number as `SeatID = row x 8 + col` where `8` is number of seats in row. This means it should be continuous, apart from a block at the start and end we are told is missing. We are also told our seat ±1 is occupied, so we are looking for unoccupied seats... turns out there is only 1 unoccupied seat, so this must be ours.
 
 
 
# Day 6: Custom Customs

- Customs declaration forms have 26 yes/no questions marked a-z.
- Identify any question a member of your group answers `yes`.
- Example group og three people might answer:

  - `abcx`
  - `abcy`
  - `abcz`
  
  In this example 6 questions were marked as yes: `a`, `b`, `c`, `x`, `y`, and `z`.
  
- Puzzle input is every group on the plane's answers, where each person has their own line, and groups are separated by a blank line.
- Example:

  ```
  abc
  
  a
  b
  c
  
  ab
  ac
  
  a
  a
  a
  a
  
  b
  ```
  
  where:
  
  - The first group contains one person who answered "yes" to 3 questions: a, b, and c.
  - The second group contains three people; combined, they answered "yes" to 3 questions: a, b, and c.
  - The third group contains two people; combined, they answered "yes" to 3 questions: a, b, and c.
  - The fourth group contains four people; combined, they answered "yes" to only 1 question, a.
  - The last group contains one person who answered "yes" to only 1 question, b.
  - Sum of `yes` counts is `3 + 3 + 3 + 1 + 1 = 11`
  - Requirement: for each group count the number of questions to which someone answered yes to, and calculat the sum of those counts.