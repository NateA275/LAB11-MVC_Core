using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace My_First_MVC_App.Models
{
    public class Recipient
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }


        public List<Recipient> RetrieveRecipients(int begYear, int endYear)
        {
            List<Recipient> recipients = new List<Recipient>(); //instantiate new list to hold all recipients

            string path = Environment.CurrentDirectory; //establish current file path

            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv")); //specifiy file path to .csv file

            string[] myFile = File.ReadAllLines(newPath); //declare string array with all lines from .csv

            for (int i = 1; i < myFile.Length; i++) //iterate through CSV, skipping the first line
            {
                string[] fields = myFile[i].Split(','); //seperate each line on commas

                recipients.Add(new Recipient //create new recipient object and add to all recipients list
                {
                    Year = Convert.ToInt32(fields[0]), //assign values from .csv
                    Honor = fields[1],
                    Name = fields[2],
                    Country = fields[3],
                    BirthYear = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]), //if empty string, gets 0
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]), //if empty string, gets 0
                    Title = fields[6],
                    Category = fields[7],
                    Context = fields[8],
                });
            }

            List<Recipient> allRecipients = recipients.Where(n => (n.Year >= begYear) && (n.Year <= endYear)).ToList(); //query recipients list where begYear <= year <= endYear

            return allRecipients; //return results of query
        }
    }
}
