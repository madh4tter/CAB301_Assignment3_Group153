using System;

namespace CAB301_Assignment_3_Group_153
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieCollection aCollection = new MovieCollection();
            MemberCollection members = new MemberCollection(10);
            //Main Menu
            MainMenu(aCollection, members);
        }
        //Main menu
        private static void MainMenu(MovieCollection movieList, MemberCollection members)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine("Welcome to Community Librart Movie DVD Management System");
            Console.WriteLine("========================================================");
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
                    //StaffLogin(movieList, members); Uncomment brefore submitting
                    StaffMenu(movieList, members);
                    break;
                case 2:
                    memberLogin(movieList, members);
                    break;
            }
        }

        private static void StaffLogin(MovieCollection movieList, MemberCollection members)
        {
            Console.Write("Username: ");
            string Username = Console.ReadLine();
            Console.Write("Password: ");
            string Password = Console.ReadLine();
            if (Username == "staff" && Password == "today123")
            {
                StaffMenu(movieList, members);
            }
            else
            {
                Console.WriteLine("Incorrect Username or Password");
                Console.WriteLine("1. Try again");
                Console.WriteLine("2. Main menu");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        StaffLogin(movieList, members);
                        break;
                    case "2":
                        MainMenu(movieList, members);
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        MainMenu(movieList, members);
                        break;
                }
            }
        }

        //Staff menu
        private static void StaffMenu(MovieCollection movieList, MemberCollection members)
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
                    MainMenu(movieList, members);
                    break;
                case "1":
                    AddDVD(movieList, members);
                    break;
                case "2":
                    RemoveDVD(movieList, members);
                    break;
                case "3":
                    RegisterMember(movieList, members);
                    break;
                case "4":
                    RemoveMember(movieList, members);
                    break;
                case "5":
                    DisplayInformation(movieList, members);
                    break;
                case "6":
                    CurrentBorrowers(movieList, members);
                    break;
                default:
                    Console.WriteLine("Invalid");
                    StaffMenu(movieList, members);
                    break;
            }
        }

        //Member Menu
        private static void memberLogin(MovieCollection movieList, MemberCollection members)
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
                    MainMenu(movieList, members);
                    break;
                case "1":
                    //ListAllMovies();
                    break;
                case "2":
                    //MovieInformation();
                    break;
                case "3":
                    //BorrowMovie();
                    break;
                case "4":
                    //ReturnMovie();
                    break;
                case "5":
                    //CurrentBorrowing();
                    break;
                case "6":
                    //TopThree();
                    break;
                default:
                    memberLogin(movieList, members);
                    break;
            }
        }

        //Methods for staff menu
        private static void AddDVD(MovieCollection movieList, MemberCollection members)
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Movie title1 = (Movie)movieList.Search(title);
            if (title1 != null)
            {
                Console.WriteLine("Movie found How many DVDs would you like to add:");
                int input = Convert.ToInt32(Console.ReadLine());
                title1.AvailableCopies += input;
                StaffMenu(movieList, members);

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
                    StaffMenu(movieList, members);
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

        private static void RemoveDVD(MovieCollection movieList, MemberCollection members)
        {
            Console.WriteLine("What movie would you like to remove:");
            string remove = Console.ReadLine();
            if (movieList.Delete(movieList.Search(remove)))
            {
                Console.WriteLine($"Movie: {remove} has been removed successfully");
                StaffMenu(movieList, members);
            }
            else
            {
                Console.WriteLine($"Movie: {remove} not found");
                StaffMenu(movieList, members);
            }
        }
        /* m. When a member is being
        registered via a staff member, the member’s fist name, last name, contact
        phone number are recorded in the system, a password is set by the member
        via the staff. The system must check and make sure the phone number and
        the password are valid. A contact phone number is valid if it has 10 digits,
        and the first digit is a ‘0’. A password is valid if it has 4-6 digits. */
        private static void RegisterMember(MovieCollection movieList, MemberCollection members)
        {
            Console.Write("First name:");
            string Firstname = Console.ReadLine();
            Console.Write("Last name:");
            string Lastname = Console.ReadLine();
            string ContactNumber = "1";
            while (true)
            {
                Console.WriteLine("0 - to return to main menu");
                Console.Write("Contact number:");
                ContactNumber = Console.ReadLine();
                if (ContactNumber == "0")
                {
                    StaffMenu(movieList, members);
                    break;
                }
                if (IMember.IsValidContactNumber(ContactNumber))
                {
                    break;
                }
            }
            string Pin = "1";
            while (!IMember.IsValidPin(Pin))
            {
                Console.WriteLine("0 - to return to main menu");
                Console.Write("Password:");
                Pin = Console.ReadLine();
                if (Pin == "0")
                {
                    StaffMenu(movieList, members);
                    break;
                }
            }
            Member newMember = new Member(Firstname, Lastname, ContactNumber, Pin);
            members.Add(newMember);
            StaffMenu(movieList, members);
        }

        private static void RemoveMember(MovieCollection movieList, MemberCollection members)
        {
            Console.WriteLine();
        }

        private static void DisplayInformation(MovieCollection movielist, MemberCollection members)
        {
            Console.Write("First name: ");
            string FirstName = Console.ReadLine();
            Console.Write("Last name: ");
            string LastName = Console.ReadLine();

            Member search = new Member(FirstName, LastName);
            if (members.Search(search))
            {
                Console.WriteLine($"Member Last and First name (Last, First): {members.ToString()}");
            }
            StaffMenu(movielist, members);
            
        }

        private static void CurrentBorrowers(MovieCollection movielist, MemberCollection members)
        {
            Console.Write("Movie: ");
            string movieTitle = Console.ReadLine();
            Movie result = (Movie)movielist.Search(movieTitle);
            Console.WriteLine($"Users currently borrowing {movieTitle}:");
            for (int i = 0; i < result.Borrowers.ToString().Length; i++)
            {
                Console.WriteLine($"{i + 1}. {result.Borrowers.ToString()}");
            }
            StaffMenu(movielist, members);
        }

        //Methods for Member menu

    }
}
