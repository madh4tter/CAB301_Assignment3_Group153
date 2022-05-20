using System;

namespace CAB301_Assignment_3_Group_153
{
    class Program
    {
        static void Main(string[] args)
        {
            //Main Menu
            mainMenu();
        }

        private static void mainMenu()
        {
            Console.WriteLine("=======================================================");
            Console.WriteLine("Welcome to Community Libart Movie DVD Management System");
            Console.WriteLine("=======================================================");
            Console.WriteLine();
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member Login");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
            Console.WriteLine("Enter your choice ==> (1/2/0)");
            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 0:
                    Console.WriteLine("Exiting");
                    break;
                case 1:
                    staffLogin();
                    break;
                case 2:
                    memberLogin();
                    break;
            }
        }

        //Staff menu
        private static void staffLogin()
        {
            Console.WriteLine("======================Staff Menu=======================");
            Console.WriteLine();
            Console.WriteLine("1. Add new DVDs of a new movie to the system");
            Console.WriteLine("2. Remove DVD's of a movie from the system");
            Console.WriteLine("3. Register a new member with the system");
            Console.WriteLine("4. Remove a registered member from the system");
            Console.WriteLine("5. Display a member's contact phone number, given the member's name");
            Console.WriteLine("6. Display all members who are currently renting a particular movie");
            Console.WriteLine("0. return to the main menu");
            Console.WriteLine();
            Console.WriteLine("Enter your choice ==> (1/2/3/4/5/6/0)");
            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 0:
                    Console.WriteLine("Returning to main menu");
                    mainMenu();
                    break;
                case 1:
                    //addDVD();
                    break;
                case 2:
                    //removeDVD();
                    break;
                case 3:
                    //registerMember();
                    break;
                case 4:
                    //removeMember();
                    break;
                case 5:
                    //displayInformation();
                    break;
                case 6:
                    //currentBorrowers();
                    break;
            }
        }

        //Member Menu
        private static void memberLogin()
        {
            Console.WriteLine("======================Member Menu=======================");
            Console.WriteLine();
            Console.WriteLine("1. Browse all the movies");
            Console.WriteLine("2. Display all information about a movie, given the title of the movie");
            Console.WriteLine("3. Borrow a movie DVD");
            Console.WriteLine("4. Return a movie DVD");
            Console.WriteLine("5. List current borrowing movies");
            Console.WriteLine("6. Display the top 3 movies rented by the members");
            Console.WriteLine("0. Return to the main menu");
            Console.WriteLine();
            Console.WriteLine("Enter your choice ==> (1/2/3/4/5/6/0)");
            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 0:
                    Console.WriteLine("Returning to main menu");
                    mainMenu();
                    break;
                case 1:
                    //listAllMovies();
                    break;
                case 2:
                    //movieInformation();
                    break;
                case 3:
                    //borrowMovie();
                    break;
                case 4:
                    //returnMovie();
                    break;
                case 5:
                    //currentBorrowing();
                    break;
                case 6:
                    //topThree();
                    break;
            }
        }
    }
}
