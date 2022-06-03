using System;

namespace CAB301_Assignment_3_Group_153
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieCollection aCollection = new MovieCollection();
            MemberCollection members = new MemberCollection(10);
            
            Member test = new Member("test", "temp", "0333333333", "1234");
            Member temp = new Member("temp", "test", "0333333333", "1234");
            Member wert = new Member("wert", "fee", "0333333333", "1234");
            members.Add(test);
            members.Add(temp);
            members.Add(wert);

            Movie Titanic = new Movie("Titanic", MovieGenre.Drama, MovieClassification.M, 194, 10);
            Movie StarWars = new Movie("Star Wars", MovieGenre.Action, MovieClassification.M, 142, 5);
            Movie IndianaJones = new Movie("Indiana Jones", MovieGenre.Action, MovieClassification.M, 115, 3);
            Movie TheAvengers = new Movie("The Avengers", MovieGenre.Action, MovieClassification.M, 143, 2);
            aCollection.Insert(Titanic);
            aCollection.Insert(StarWars);
            aCollection.Insert(IndianaJones);
            aCollection.Insert(TheAvengers);
            

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
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    Console.WriteLine("Exiting");
                    break;
                case "1":
                    StaffLogin(movieList, members);
                    break;
                case "2":
                    MemberLogin(movieList, members);
                    break;
                default:
                    Console.WriteLine("Invalid");
                    MainMenu(movieList, members);
                    break;
            }
        }

        //Staff Login
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
        
        //Member login
        private static void MemberLogin(MovieCollection movieList, MemberCollection members)
        {
            Console.Write("First name: ");
            string FirstName = Console.ReadLine();
            Console.Write("Last name: ");
            string LastName = Console.ReadLine();
            Console.Write("Pin: ");
            string Pin = Console.ReadLine();
            Member temp = new Member(FirstName, LastName);

            if (members.IsEmpty())
            {
                Console.WriteLine("First name, Last name, or Pin incorrect");
                MainMenu(movieList, members);
            }
            else if (members.Search(temp) && members.Find(temp).Pin == Pin)
            {
                MemberMenu(movieList, members, (Member)members.Find(temp));
            }
            else
            {
                Console.WriteLine("First name, Last name, or Pin incorrect");
                MainMenu(movieList, members);
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
        private static void MemberMenu(MovieCollection movieList, MemberCollection members, Member currentMember)
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
                    ListAllMovies(movieList, members, currentMember);
                    break;
                case "2":
                    MovieInformation(movieList, members, currentMember);
                    break;
                case "3":
                    BorrowMovie(movieList, members, currentMember);
                    break;
                case "4":
                    ReturnMovie(movieList, members, currentMember);
                    break;
                case "5":
                    CurrentBorrowing(movieList, members, currentMember);
                    break;
                case "6":
                    TopThree(movieList, members, currentMember);
                    break;
                default:
                    MemberMenu(movieList, members, currentMember);
                    break;
            }
        }

        //Methods for staff menu
        private static void AddDVD(MovieCollection movieList, MemberCollection members)
        {
            Console.WriteLine("======================Add DVD=======================");
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

                int duration;
                string temp = Console.ReadLine();
                bool parseTest = int.TryParse(temp, out duration);
                if (parseTest == false)
                {
                    StaffMenu(movieList, members);
                }

                int availableCopies;
                Console.Write("Available Copies: ");
                temp = Console.ReadLine();
                parseTest = int.TryParse(temp, out availableCopies);
                if (parseTest == false)
                {
                    StaffMenu(movieList, members);
                }
                //int availableCopies = Convert.ToInt32(Console.ReadLine());

                Movie add = new Movie(title, genre, classification, duration, availableCopies);
                if (movieList.Insert(add))
                {
                    Console.WriteLine("Movie successfully added to collection");
                    Console.WriteLine();
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    StaffMenu(movieList, members);
                }
                else
                {
                    Console.WriteLine("Error");
                    StaffMenu(movieList, members);
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
            Console.WriteLine("======================Remove DVD=======================");
            Console.WriteLine("What movie would you like to remove:");
            string remove = Console.ReadLine();
            //if (movieList.Delete(movieList.Search(remove)))
            Movie toBeRmoved = (Movie)movieList.Search(remove);
            if (toBeRmoved != null)
            {
                Console.WriteLine($"How many copies of {remove} Would you like to remove");
                string copies = Console.ReadLine();
                int i = 0;
                if (int.TryParse(copies, out i) && i >= toBeRmoved.TotalCopies && toBeRmoved.NoBorrowings <= 0)
                {
                    movieList.Delete(toBeRmoved);
                    Console.WriteLine($"{remove} has been removed from the collection");
                }
                else if (i < toBeRmoved.TotalCopies && toBeRmoved.NoBorrowings <= 0)
                {
                    toBeRmoved.TotalCopies -= i;
                    toBeRmoved.AvailableCopies -= i;
                    Console.WriteLine($"{toBeRmoved.Title} now has {toBeRmoved.TotalCopies} copies");
                    
                }
                else
                {
                    Console.WriteLine("Error");
                    Console.WriteLine();
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
                StaffMenu(movieList, members);
            }
            else
            {
                Console.WriteLine($"Movie: {remove} not found");
                StaffMenu(movieList, members);
            }
        }


        private static void RegisterMember(MovieCollection movieList, MemberCollection members)
        {
            Console.WriteLine("======================Register Member=======================");
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
            Console.WriteLine("======================Remove Member=======================");

            Console.Write("First name: ");
            string FirstName = Console.ReadLine();
            Console.Write("Last name: ");
            string LastName = Console.ReadLine();

            Member deletingMember = new Member(FirstName, LastName);

            if(members.Search(deletingMember))
            {
                Movie[] array = (Movie[])movieList.ToArray();
                int foundCount = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != null && array[i].TotalCopies > array[i].AvailableCopies)
                    {
                        if (array[i].Borrowers.Search(deletingMember))
                        {
                            Console.WriteLine($"User has an existing loan on {array[i].Title}");
                            foundCount++;
                            //break;
                        }
                    }
                }
                if (foundCount == 0)
                {
                    members.Delete(deletingMember);
                    Console.WriteLine($"User {deletingMember.FirstName} {deletingMember.LastName} has been deleted");
                }
            }
            else
            {
                Console.WriteLine("User Does Not Exist");
                Console.WriteLine();
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            

            StaffMenu(movieList, members);
        }

        private static void DisplayInformation(MovieCollection movielist, MemberCollection members)
        {
            Console.WriteLine("======================Member Information=======================");
            Console.Write("First name: ");
            string FirstName = Console.ReadLine();
            Console.Write("Last name: ");
            string LastName = Console.ReadLine();

            Member search = new Member(FirstName, LastName);
            IMember foundMember = members.Find(search);
            if (members.Search(search))
            {
                Console.WriteLine($"{search.LastName} and {search.FirstName} (Last, First): {foundMember.ContactNumber}");
            }
            else
            {
                Console.WriteLine($"Member {FirstName} {LastName} Not Found");
            }
            StaffMenu(movielist, members);
            
        }

        private static void CurrentBorrowers(MovieCollection movielist, MemberCollection members)
        {
            Console.WriteLine("=====================Current Borrowers======================");
            Console.Write("Movie: ");
            string movieTitle = Console.ReadLine();
            Movie result = (Movie)movielist.Search(movieTitle);
            
            if(result != null)
            {
                Console.WriteLine($"Users currently borrowing {movieTitle}:");
                for (int i = 0; i < result.Borrowers.Number; i++)
                {
                    Console.WriteLine($"{i + 1}. {result.Borrowers.ToString()}");
                }
                if(result.Borrowers.Number == 0)
                {
                    Console.WriteLine("No One is Renting That Movie");
                }
            }
            else
            {
                Console.WriteLine("Movie Does not Exist");
            }
            
            StaffMenu(movielist, members);
        }

        //Methods for Member menu
        private static void ListAllMovies(MovieCollection movieList, MemberCollection members, Member currentMember)
        {
            Console.WriteLine("======================All Movies=======================");
            Movie[] array = (Movie[])movieList.ToArray();
            int i = 0;
            if(movieList.IsEmpty() == false)
            {
                foreach (var item in array)
                {
                    if (item != null)
                    {
                        Console.WriteLine($"{i++ + 1}. \tCopies: {item.Title} \tAvailable Copies: {item.AvailableCopies}");
                    }
                }
            }
            else

            {
                Console.WriteLine("No Available Movies");
            }
            
            Console.WriteLine();
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            MemberMenu(movieList, members, currentMember);
        }

        private static void MovieInformation(MovieCollection movieList, MemberCollection members, Member currentMember)
        {
            Console.WriteLine("=====================Movie Information======================");
            Console.Write("Movie: ");
            string search = Console.ReadLine();
            Movie temp = (Movie)movieList.Search(search);

            if (temp != null)
            {
                Console.WriteLine(temp.ToString());
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                MemberMenu(movieList, members, currentMember);
            }
            else
            {
                Console.WriteLine($"{search} not found");
                Console.WriteLine();
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                MemberMenu(movieList, members, currentMember);
            }
        }

        private static void BorrowMovie(MovieCollection movieList, MemberCollection members, Member currentMember)
        {
            Console.WriteLine("======================Movie Borrow=======================");
            Console.Write("Search: ");
            string search = Console.ReadLine();
            Movie temp = (Movie)movieList.Search(search);
            bool test = false;
            if (temp != null) { test = temp.AddBorrower(currentMember); }
            if (temp != null && test)
            {
                Console.WriteLine("Movie Successfully borrowed");
                Console.WriteLine();
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                MemberMenu(movieList, members, currentMember);
            }
            else if (temp != null && !test)
            {
                Console.WriteLine();
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                MemberMenu(movieList, members, currentMember);
            }
            else
            {
                Console.WriteLine("No movie found");
                Console.WriteLine();
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                MemberMenu(movieList, members, currentMember);
            }
        }

        private static void ReturnMovie(MovieCollection movieList, MemberCollection members, Member currentMember)
        {
            Console.WriteLine("======================Movie Return=======================");
            Console.Write("DVD Name: ");
            string search = Console.ReadLine();
            Movie temp = (Movie)movieList.Search(search);
            if(temp != null && temp.RemoveBorrower(currentMember))
            {
                Console.WriteLine("Movie Successfully Returned");
                Console.WriteLine();
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                MemberMenu(movieList, members, currentMember);
            }
            else
            {
                Console.WriteLine("No movie found");
                Console.WriteLine();
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                MemberMenu(movieList, members, currentMember);
            }
        }

        private static void CurrentBorrowing(MovieCollection movieList, MemberCollection members, Member currentMember)
        {
            Console.WriteLine("======================Current Borrowing=======================");
            Console.Write("You are currently borrowing: ");
            Console.WriteLine();

            if(movieList.IsEmpty())
            {
                Console.WriteLine("No Available Movies");
                Console.WriteLine();
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                MemberMenu(movieList, members, currentMember);
            }
            else
            {
                Movie[] array = (Movie[])movieList.ToArray();
                int foundCount = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != null && array[i].TotalCopies > array[i].AvailableCopies)
                    {
                        if (array[i].Borrowers.Search(currentMember))
                        {
                            Console.WriteLine($"{foundCount++ + 1}. {array[i].ToString()}");
                        }
                    }
                }
                if (foundCount == 0)
                {
                    Console.WriteLine("No Available Movies");
                }
                Console.WriteLine();
                MemberMenu(movieList, members, currentMember);
            }
        }

        private static void TopThree(MovieCollection movieList, MemberCollection members, Member currentMember)
        {
            Console.WriteLine("======================Top Three DVDS=======================");
            Console.Write("The Current Top Three DVDS are: ");
            Console.WriteLine();

            Movie[] array = (Movie[])movieList.ToArray();
            // Create a temp movie to assign to the three values before they're assigned by the algorithm itself
            Movie TempMovie = new Movie("temp", MovieGenre.Action, MovieClassification.G, 0, 0);
            // Give the temp movie a minvalue, so that any value of NoBorrowings in the real movielist will overwrite the temp movie
            TempMovie.NoBorrowings = int.MinValue;

            if (movieList.IsEmpty())
            {
                Console.WriteLine("No DVDs Available");
            }
            else
            {

                Movie first = TempMovie;
                Movie second = TempMovie;
                Movie third = TempMovie;
                for (int i = 0; i <= (array.Length - 1); i++)
                {
                    if (array[i].NoBorrowings < first.NoBorrowings)
                    {
                        first = array[i];
                    }
                    else if (array[i].NoBorrowings < second.NoBorrowings)
                    {
                        second = array[i];
                    }
                    else if (array[i].NoBorrowings < third.NoBorrowings)
                    {
                        third = array[i];
                    }
                }


                // Display of the top movies
                Console.WriteLine("1: " + first.Title + ", Borrowings: " + first.NoBorrowings);
                // Handling if movielist only has 1 or 2 movies in it.
                if (array.Length > 1)
                {
                    Console.WriteLine("2: " + second.Title + ", Borrowings: " + second.NoBorrowings);
                }
                if (array.Length > 2)
                {
                    Console.WriteLine("3: " + third.Title + ", Borrowings: " + third.NoBorrowings);
                }
            }
            Console.WriteLine();
            MemberMenu(movieList, members, currentMember);
        }
    }
}
