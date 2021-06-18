using KomodoInsurance.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class ProgramUI
    {
        private DeveloperRepo _newDeveloper = new DeveloperRepo();

        private DevTeamRepo _newDevTeam = new DevTeamRepo();

        public void Run()
        {
            SeedDeveloperList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select an Option:\n" +
                    "1. Add a New Developer\n" +
                    "2. Remove an Existing Developer\n" +
                    "3. Add a Developer by ID\n" +
                    "4. Remove a Developer by ID\n" +
                    "5. Existing Developers by Name\n" +
                    "6. Existing Developers by ID\n" +
                    "7. Create Developer Team\n" +
                    "8. Remove a Developer from a Team\n" +
                    "9. Current Developer Teams\n" +
                    "10. Developer Directory\n" +
                    "11. Developer that needs Pluralsight\n" +
                    "12. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewDeveloper();
                        break;

                    case "2":
                        RemoveExistingDeveloperByName();
                        break;

                    case "3":
                        CreateDeveloperByID();
                        break;

                    case "4":
                        RemoveDeveloperByID();
                        break;

                    case "5":
                        ExistingDevelopers();
                        break;

                    case "6":
                        ExistingDevelopersByID();
                        break;

                    case "7":
                        CreateDeveloperTeam();
                        break;

                    case "8":
                        RemoveDeveloperFromTeam();
                        break;

                    case "9":
                        CurrentDeveloperTeams();
                        break;

                    case "10":
                        DeveloperDirectory();
                        break;

                    case "11":
                        DeveloperPluralsight();
                        break;

                    case "12":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Enter a valid option.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                
            }
        }

        //Switch 1
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            Console.WriteLine("Enter the Name of the New Developer:");
            newDeveloper.DevName = Console.ReadLine();

            Console.WriteLine("Enter the ID of the New Developer:");
            newDeveloper.DevID = Console.ReadLine();

            Console.WriteLine("Does this Developer have Pluralsight?");
            string pluralsight = Console.ReadLine().ToLower();

            switch (pluralsight)
            {
                case "yes":
                    Console.WriteLine("Developer does have Pluralsight.");
                    break;
                case "no":
                    Console.WriteLine("Developer does not have Pluralsight.");
                    break;
                default:
                    Console.WriteLine("Invalid Option. Yes or No");
                    break;
            }

            _newDeveloper.AddDeveloper(newDeveloper);
        }

        //Switch 2
        private void RemoveExistingDeveloperByName()
        {
            Console.Clear();

            DeveloperDirectory();
            Console.WriteLine("Enter the name of the Developer you would like to remove.");
            string input = Console.ReadLine();

            bool wasDeleted = _newDeveloper.DeleteDevelopersFromListByName(input);

            if (wasDeleted)
            {
                Console.WriteLine("The Developer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The Developer could not be deleted.");
            }
        }

        //Switch 3
        private void CreateDeveloperByID()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            Console.WriteLine("Enter the ID of the New Developer:");
            newDeveloper.DevID = Console.ReadLine();

            Console.WriteLine("Enter the name of the New Developer:");
            newDeveloper.DevName = Console.ReadLine();

            Console.WriteLine("Does this Developer have Pluralsight?");
            string pluralsight = Console.ReadLine().ToLower();

                switch (pluralsight)
                {
                    case "yes":
                        Console.WriteLine("Developer does have Pluralsight.");
                        break;
                    case "no":
                        Console.WriteLine("Developer does not have Pluralsight.");
                        break;
                    default:
                        Console.WriteLine("Invalid Option. Yes or No");
                        break;
            }

            _newDeveloper.AddDeveloper(newDeveloper);
        }

        //Switch 4
        private void RemoveDeveloperByID()
        {
            Console.Clear();
            DeveloperDirectory();
            Console.WriteLine("Enter the ID of the Developer you would like to remove.");
            string input = Console.ReadLine();

            bool wasDeleted = _newDeveloper.DeleteDevelopersFromListByID(input);

            if (wasDeleted)
            {
                Console.WriteLine("The Developer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The Developer could not be deleted.");
            }
        }

        //Switch 5
        private void ExistingDevelopers()
        {
            Console.Clear();

            Console.WriteLine("Enter the name of the Developer you would like to view.");

            string existingDeveloper = Console.ReadLine();

            Developer developer = _newDeveloper.GetDeveloperByDevName(existingDeveloper);

            if (developer != null)
            {
                Console.WriteLine($"Developer Name: {developer.DevName}\n" +
                    $"Developer ID: {developer.DevID}\n" +
                    $"Pluralsight: {developer.Pluralsight}");
            }
            else
            {
                Console.WriteLine("No Developer by that name.");
            }
        }

        //Switch 6
        private void ExistingDevelopersByID()
        {
            Console.Clear();

            Console.WriteLine("Enter the ID of the Developer you would like to view.");

            string existingDeveloperByID = Console.ReadLine();

            Developer developer = _newDeveloper.GetDeveloperByID(existingDeveloperByID);

            if (developer != null)
            {
                Console.WriteLine($"Developer Name: {developer.DevName}\n" + 
                                 $"Developer ID: {developer.DevID}\n" + 
                                 $"Pluralsight: {developer.Pluralsight}");
            }
            else
            {
                Console.WriteLine("No Developer by that ID.");
            }
        }

        //Switch 7
        private void CreateDeveloperTeam()
        {
            Console.Clear();
            DeveloperTeam developerTeam = new DeveloperTeam();

            Console.WriteLine("Enter the name of the Developer Team:");
            developerTeam.TeamName = Console.ReadLine();

            Console.WriteLine("Enter the ID of the team:");
            developerTeam.TeamID = Console.ReadLine();

            _newDevTeam.AddDevelopersToTeam(developerTeam);
        }

        //Switch 8
        private void RemoveDeveloperFromTeam()
        {
            CurrentDeveloperTeams();

            Console.WriteLine("Enter the name of the Developer you would like to remove:");

            string input = Console.ReadLine();

            bool wasDeleted = _newDevTeam.RemoveDeveloperFromTeam(input);

            if (wasDeleted)
            {
                Console.WriteLine("The Team Member was successfully removed.");
            }
            else
            {
                Console.WriteLine("The Team Member could not be removed.");
            }
        }

        //Switch 9
        private void CurrentDeveloperTeams()
        {
            Console.Clear();

            Console.WriteLine("Enter the name of the team you would like to view:");

            string devTeam = Console.ReadLine();

            DeveloperTeam developerTeam = _newDevTeam.GetDeveloperByTeamName(devTeam);

            if (developerTeam != null)
            {
                Console.WriteLine($"Team Name: {developerTeam.TeamName}\n" +
                    $"Team ID: {developerTeam.TeamID}");
            }
            else
            {
                Console.WriteLine("Could not find that team.");
            }

        }

        //Switch 10
        private void DeveloperDirectory()
        {
            Console.Clear();

            List<Developer> listOfDevelopers = _newDeveloper.GetDeveloperList();

            foreach (Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"Developer: {developer.DevName}\n" +
                    $"Developer ID: {developer.DevID}\n" +
                    $"Pluralsight: {developer.Pluralsight}");
            }
        }

        //Switch 11
        private void DeveloperPluralsight()
        {
            List<Developer> DeveloperHasPluralsight = _newDeveloper.GetAllDevelopersThatDontHavePluralsight();

            foreach (Developer developer in DeveloperHasPluralsight)
            {
            
                    Console.WriteLine($"Developer: {developer.DevName}\n" +
                         $"Developer ID: {developer.DevID}\n" +
                         $"Pluralsight: {developer.Pluralsight}");
            }

        }

        private void SeedDeveloperList()
        {
            Developer developer = new Developer("Kyle", "123456", false);

            _newDeveloper.AddDeveloper(developer);
        }
    }
}
            
            


            
                
            
     

                
                 
                
