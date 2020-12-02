﻿# Advent of Code 2020

More information about Advent of Code can be found at https://adventofcode.com/2020.

## My Aims for Advent of Code 2020

- Use .Net 5 / and latest versions of C#
- Use Visual Studio for Mac and Rider


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