using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSachin_Chourasiya
{
    class assignment
    {
    
        static void Main(string[] args)
        {
            List<Movie> movies = GetMovies();

            Console.WriteLine("Welcome to the Movie Database!");

            while (true)
            {
                Console.WriteLine("Are you an Admin or a User? (Enter 'Exit' to quit)");
                string role = Console.ReadLine();

                if (role.ToLower() == "admin")
                {
                    AdminMenu(movies);
                }
                else if (role.ToLower() == "user")
                {
                    UserMenu(movies);
                }
                else if (role.ToLower() == "exit")
                {
                    ExitProgram();
                }
                else
                {
                    Console.WriteLine("Invalid role selected.");
                }
            }
        }

        static void AdminMenu(List<Movie> movies)
        {
            Console.WriteLine("Admin Menu:");
            Console.WriteLine("1. View Movies Data");
            Console.WriteLine("2. Modify Data");
            Console.WriteLine("3. Search Data");
            Console.WriteLine("4. Exit");

            int choice = GetChoice();

            switch (choice)
            {
                case 1:
                    ViewMoviesData(movies);
                    break;
                case 2:
                    ModifyData(movies);
                    break;
                case 3:
                    SearchData(movies);
                    break;
                case 4:
                    ExitProgram();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        static void UserMenu(List<Movie> movies)
        {
            Console.WriteLine("User Menu:");
            Console.WriteLine("1. View Movies List");
            Console.WriteLine("2. Add Favorite");
            Console.WriteLine("3. Remove Favorite");
            Console.WriteLine("4. Exit");

            int choice = GetChoice();

            switch (choice)
            {
                case 1:
                    ViewMoviesList(movies);
                    break;
                case 2:
                    AddFavorite(movies);
                    break;
                case 3:
                    RemoveFavorite(movies);
                    break;
                case 4:
                    ExitProgram();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        static int GetChoice()
        {
            Console.Write("Enter your choice: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static void ViewMoviesData(List<Movie> movies)
        {
            Console.WriteLine("Movies Data:");
            foreach (var movie in movies)
            {
               
                Console.WriteLine($"Title: {movie.Title}");
                Console.WriteLine($"Genre: {movie.Genre}");
                Console.WriteLine($"Date of Launch: {movie.DateOfLaunch}");
                Console.WriteLine($"Box Office Collection: {movie.BoxOfficeCollection}");
                Console.WriteLine();
            }
        }

        static void ViewMoviesList(List<Movie> movies)
        {
            Console.WriteLine("Movies List:");
            foreach (var movie in movies)
            {
                Console.WriteLine($"Title: {movie.Title}");
                Console.WriteLine($"Genre: {movie.Genre}");
                Console.WriteLine($"Date of Launch: {movie.DateOfLaunch}");
                Console.WriteLine($"Box Office Collection: {movie.BoxOfficeCollection}");
                Console.WriteLine();
            }
        }

        static void ModifyData(List<Movie> movies)
        {
            Console.WriteLine("Enter the title of the movie you want to modify:");
            string title = Console.ReadLine();

            Movie movieToModify = movies.Find(movie => movie.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (movieToModify != null)
            {
                Console.WriteLine($"Movie '{movieToModify.Title}' found. Please enter the new details:");

                Console.Write("Enter the new title: ");
                movieToModify.Title = Console.ReadLine();

                Console.Write("Enter the new genre: ");
                movieToModify.Genre = Console.ReadLine();

                Console.Write("Enter the new date of launch (YYYY-MM-DD): ");
                string dateString = Console.ReadLine();
                DateTime newDateOfLaunch;
                if (DateTime.TryParse(dateString, out newDateOfLaunch))
                {
                    movieToModify.DateOfLaunch = newDateOfLaunch.ToString("yyyy-MM-dd");
                }
                else
                {
                    Console.WriteLine("Invalid date format. Movie modification failed.");
                }

                Console.Write("Enter the new box-office collection: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal newBoxOfficeCollection))
                {
                    movieToModify.BoxOfficeCollection = newBoxOfficeCollection;
                }
                else
                {
                    Console.WriteLine("Invalid box-office collection format. Movie modification failed.");
                }

                Console.WriteLine($"Movie '{movieToModify.Title}' has been modified successfully!");
            }
            else
            {
                Console.WriteLine($"Movie with title '{title}' not found. Movie modification failed.");
            }
        }

        static void SearchData(List<Movie> movies)
        {
            Console.WriteLine("Enter the title of the movie you want to search:");
            string title = Console.ReadLine();

            Movie movie = movies.Find(mov => mov.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (movie != null)
            {
                Console.WriteLine($"Movie '{movie.Title}' found!");
                Console.WriteLine($"Title: {movie.Title}");
                Console.WriteLine($"Genre: {movie.Genre}");
                Console.WriteLine($"Date of Launch: {movie.DateOfLaunch}");
                Console.WriteLine($"Box Office Collection: {movie.BoxOfficeCollection}");
            }
            else
            {
                Console.WriteLine($"Movie with title '{title}' not found.");
            }
        }

        static void AddFavorite(List<Movie> movies)
        {
            Console.WriteLine("Enter the title of the movie you want to add to favorites:");
            string title = Console.ReadLine();

            Movie movie = movies.Find(mov => mov.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (movie != null)
            {
                // Additional logic to add the movie to the user's favorites
                Console.WriteLine($"Movie '{movie.Title}' added to favorites successfully!");
            }
            else
            {
                Console.WriteLine($"Movie with title '{title}' not found. Unable to add to favorites.");
            }
        }

        static void RemoveFavorite(List<Movie> movies)
        {
            Console.WriteLine("Enter the title of the movie you want to remove from favorites:");
            string title = Console.ReadLine();

            Movie movie = movies.Find(mov => mov.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (movie != null)
            {
                // Additional logic to remove the movie from the user's favorites
                Console.WriteLine($"Movie '{movie.Title}' removed from favorites successfully!");
            }
            else
            {
                Console.WriteLine($"Movie with title '{title}' not found in favorites. Unable to remove.");
            }
        }

        static void ExitProgram()
        {
            Console.WriteLine("Exiting the program. Goodbye!");
            Environment.Exit(0);
        }

        static List<Movie> GetMovies()
        {
            return new List<Movie>
        {
            new Movie("Radhe", "Action", "2021-05-30", 100000),
            new Movie("Jay Ho", "Action&Comedy", "2015-06-01", 50000),
            new Movie("Race 3", "Drama&Action", "2018-06-05", 75000),
             new Movie("Bhaijan", "Action", "2022/04/23", 100000),
            new Movie("Hum Apke Hai Kon", "Drama", "1996/04/14", 100000),
            new Movie("Veer", "Action", "2008/06/03", 100000),
            new Movie("Hungama", "Comedy", "2005/12/31", 50000),
            new Movie("Welcome", "Comedy", "2010/08/23", 50000),
            new Movie("Durva", "Action", "2014/05/21", 75000)
        };
        }
    }

    class Movie
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string DateOfLaunch { get; set; }
        public decimal BoxOfficeCollection { get; set; }

        public Movie(string title, string genre, string dateOfLaunch, decimal boxOfficeCollection)
        {
            Title = title;
            Genre = genre;
            DateOfLaunch = dateOfLaunch;
            BoxOfficeCollection = boxOfficeCollection;
        }
    }

}
