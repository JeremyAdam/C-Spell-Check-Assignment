// Spell Check Starter
// This start code creates two lists
// 1: dictionary: an array containing all of the words from "dictionary.txt"
// 2: aliceWords: an array containing all of the words from "AliceInWonderland.txt"

using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Diagnostics;

class Program {
  public static int BinarySearchInt (string[] array, string toFind)
  {
    int min = 0;
    int max = array.Length;
    for (int mid = (min + max) / 2; min <= max; mid = (min + max) / 2)
    {
      if (String.Compare(array[mid], toFind) == 0) // If toFind is at mid
      {
          return mid;
      }
      if (String.Compare(array[mid], toFind) < 0) // If toFind Is Greater
      {
          min = mid + 1;
      } else // If toFind Is Smaller
      {
          max = mid - 1;
      }
    }
    return -1;
  } 
  public static int LinearSearchInt(string[] array, string toFind)
  {
    for (int i = 0; i < array.Length; i++)
    {
      if (String.Compare(array[i], toFind) == 0)
      {
          return i;
      }
    }
    return -1;
  }  

 
  public static void Main (string[] args) {
    // Load data files into arrays
    String[] dictionary = System.IO.File.ReadAllLines(@"data-files/dictionary.txt");
    String aliceText = System.IO.File.ReadAllText(@"data-files/AliceInWonderLand.txt");
    String[] aliceWords = Regex.Split(aliceText, @"\s+");
    Array.Sort(dictionary);
    Array.Sort(aliceWords);

    // Program Variables
    int select = 0; // For Menu Selecting
    bool wordFound = false; // Display Text Saying Word is Not There
    int wordsFound = 0; // Amount Of Words Found Through Story
    string userWord; // Get Users Input
    int total; // For Calculation
    bool run = true; // Keep The Whole Program Running
    int idx; // For Identifying Strings In Lists
    var timer = new Stopwatch(); // Create Timer

    // Main Loop
    while (run)
    { // Main Menu
      Console.WriteLine(" ");             
      Console.WriteLine("Main Menu");
      Console.WriteLine("1: Spell Check a Word(Linear Search)");
      Console.WriteLine("2: Spell Check a Word(Binary Search)");
      Console.WriteLine("3: Spell Check Alice In Wonderland(Linear Search)");
      Console.WriteLine("4: Spell Check Alice In Wonderland(Binary Search)");
      Console.WriteLine("5: Exit");
      Console.Write("Enter menu selection(1-5): ");
      select = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine(" ");  
                
      switch (select)
      {
        case 1: // Spell Check a Word(Linear Search)
          // Start Up
          Console.Write("Please enter a word: ");
          userWord = Console.ReadLine().ToLower(); // Get The Users Input
          Console.WriteLine(" ");
          Console.WriteLine("Linear Search Starting. . .");            

          // Main Loop
          timer.Start();
          idx = LinearSearchInt(dictionary, userWord);
          timer.Stop();
          if (idx >= 0)
          {
            wordFound = true;
          }
          // Display If Not Found
          if (wordFound) {
            Console.WriteLine(userWord + " is IN the dictionary at position " + idx + " (" + timer.Elapsed + ") ");            
          } else {
            Console.WriteLine(userWord + " is NOT IN the dictionary" + " (" + timer.Elapsed + ") ");
          }

          // Reset Variables
          timer.Reset();
          select = 0;    
          wordFound = false;              
          break;
        case 2: // Spell Check a Word(Binary Search)
          // Start Up
          Console.Write("Please enter a word: ");
          userWord = Console.ReadLine().ToLower(); // Get The Users Input
          Console.WriteLine(" ");
          Console.WriteLine("Binary Search Starting. . .");     

          // Binary Search
          timer.Start();
          idx = BinarySearchInt(dictionary, userWord);
          timer.Stop();
          if (idx >= 0)
          {
            wordFound = true;
          }

          // Display Text Based Off If Words Was Found
          if (wordFound) {
            Console.WriteLine(userWord + " is IN the dictionary at position " + idx + " (" + timer.Elapsed + ") ");
          } else
          {
            Console.WriteLine(userWord + " is NOT IN the dictionary" + " (" + timer.Elapsed + ") ");
          }     

          // Reset Varaibles
          timer.Reset();
          select = 0;
          wordFound = false;
          break;                               
        case 3: // Spell Check Alice In Wonderland(Linear Search)
          // Start Up
          Console.WriteLine("Linear Search Starting. . .");          

          // Main Loop
          timer.Start();
          foreach (string word in aliceWords)
          {
          idx = LinearSearchInt(dictionary, word);
          if (idx >= 0)
            {
              wordsFound++;
            }         
          }
          timer.Stop();
          // Output
          total = aliceWords.Length - wordsFound; // Finds The Total Of Words Not Found
          Console.WriteLine("Number of words not found in the dictionary: " + total + " (" + timer.Elapsed + ") ");

          // Reset Variables
          timer.Reset();
          wordsFound = 0;
          select = 0;
          break;                                        
        case 4: // Spell Check Alice In Wonderland(Binary Search)
          // Start Up
          Console.WriteLine("Binary Search Starting. . ."); 

          // Main Loop
          timer.Start();
          foreach (string word in aliceWords)
          {
            idx = BinarySearchInt(dictionary, word);
            if (idx >= 0)
            {
              wordsFound++;
            }           
          }     
          timer.Stop();

          // Output    
          total = aliceWords.Length - wordsFound; // Finds The Total Of Words Not Found
          Console.WriteLine("Number of words not found in the dictionary: " + total + " (" + timer.Elapsed + ") ");

          // Reset Variables
          timer.Reset();
          wordsFound = 0;              
          select = 0;
          break;                                            
        case 5: // Exit Program
          run = false;
          break;                                            
        default:
          Console.WriteLine("Value does not work");
          select = 0;
          break;
      }
    } 
  }
}