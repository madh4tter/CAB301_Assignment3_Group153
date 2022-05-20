using System;

namespace CAB301_Assignment_3_Group_153
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieCollection aCollection = new MovieCollection();
            //Main Menu
            mainMenu(aCollection);
        }
        //Main menu
        private static void mainMenu(MovieCollection movieList)
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
                    staffLogin(movieList);
                    break;
                case 2:
                    memberLogin(movieList);
                    break;
            }
        }

        //Staff menu
        private static void staffLogin(MovieCollection movieList)
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
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    Console.WriteLine("Returning to main menu");
                    mainMenu(movieList);
                    break;
                case "1":
                    addDVD(movieList);
                    break;
                case "2":
                    //removeDVD();
                    break;
                case "3":
                    //registerMember();
                    break;
                case "4":
                    //removeMember();
                    break;
                case "5":
                    //displayInformation();
                    break;
                case "6":
                    //currentBorrowers();
                    break;
                default:
                    Console.WriteLine("Invalid");
                    staffLogin(movieList);
                    break;
            }
        }

        //Member Menu
        private static void memberLogin(MovieCollection movieList)
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
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    Console.WriteLine("Returning to main menu");
                    mainMenu(movieList);
                    break;
                case "1":
                    //listAllMovies();
                    break;
                case "2":
                    //movieInformation();
                    break;
                case "3":
                    //borrowMovie();
                    break;
                case "4":
                    //returnMovie();
                    break;
                case "5":
                    //currentBorrowing();
                    break;
                case "6":
                    //topThree();
                    break;
                default:
                    memberLogin(movieList);
                    break;
            }
        }

        //Methods for staff menu
        private static void addDVD(MovieCollection movieList)
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Movie title1 = (Movie)movieList.Search(title);
            if (title1 != null)
            {
                Console.WriteLine("Movie found How many DVDs would you like to add:");
                int input = Convert.ToInt32(Console.ReadLine());
                title1.AvailableCopies += input;
                staffLogin(movieList);

            }
            else
            {
                MovieGenre genre = Genre();
                MovieClassification classification = Classification();
                Console.Write("Duration: ");
                int duration = Convert.ToInt32(Console.ReadLine());
                Console.Write("Available Copies: ");
                int availableCopies = Convert.ToInt32(Console.ReadLine());
                Movie add = new Movie(title, genre, classification, duration, availableCopies);
                if (movieList.Insert(add))
                {
                    Console.WriteLine("Movie successfully added to collection");
                    staffLogin(movieList);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            
        }
        //Get input for movie genre
        private static MovieGenre Genre()
        {
            Console.WriteLine("Genre: ");
            Console.WriteLine("1. Action");
            Console.WriteLine("2. Comedy");
            Console.WriteLine("3. History");
            Console.WriteLine("4. Drama");
            Console.WriteLine("5. Western");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    return MovieGenre.Action;
                case "2":
                    return MovieGenre.Action;
                case "3":
                    return MovieGenre.Action;
                case "4":
                    return MovieGenre.Action;
                case "5":
                    return MovieGenre.Action;
                default:
                    Console.WriteLine("Invalid");
                    Genre();
                    break;
            }
            return MovieGenre.Action;
        }

        //Get input for Classification
        private static MovieClassification Classification()
        {
            Console.WriteLine("Classification: ");
            Console.WriteLine("1. G");
            Console.WriteLine("2. PG");
            Console.WriteLine("3. M");
            Console.WriteLine("4. M15 Plus");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    return MovieClassification.G;
                case "2":
                    return MovieClassification.PG;
                case "3":
                    return MovieClassification.M;
                case "4":
                    return MovieClassification.M15Plus;
                default:
                    Console.WriteLine("Invalid");
                    Classification();
                    break;
            }
            return MovieClassification.G;
        }

        //Methods for Member menu

    }
}
