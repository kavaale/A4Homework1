using System;
using System.IO;

namespace A4Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            if(!File.Exists("movies.csv")){
                StreamWriter sw = new StreamWriter("movies.csv");
                sw.WriteLine("movieId,title,genres");
                sw.Close();
            }
            int x = 1;
            while(x == 1){
                x = MainMenu();
            }
        }

        static int MainMenu(){
            //terminal for program
            int x = 1;
            Console.WriteLine("Select Command");
            Console.WriteLine("1. Add Movie");
            Console.WriteLine("2. List Movies");
            Console.WriteLine("3. Close");
            String choice = Console.ReadLine();
            if(choice == "1"){
                Console.WriteLine();
                RunAdd();
            }
            else if(choice == "2"){
                Console.WriteLine();
                RunList();
            }
            else if(choice == "3"){
                x = 0;
            }
            else{
                Console.WriteLine("Unrecognized Command");
            }
            return x;
        }


        static void RunAdd(){
            //adds movie into file
            Console.WriteLine("Enter Movie Info");
            
            StreamReader sr = new StreamReader("movies.csv");
            String[] wholeFile = File.ReadAllLines("movies.csv");
            sr.Close();
            String[] movieNames = new String[wholeFile.Length - 1];
            int i = 1;
            while(i < wholeFile.Length){
                String[] lineHolder = wholeFile[i].Split(',');
                movieNames[i-1] = lineHolder[1];
                i++;
            }

            int movieID = i;
            
            int x = 1;
            String title = "";
            while(x==1){
                Console.Write("Title: ");
                title = Console.ReadLine();
                
                i = 0;
                x=0;
                while(i<movieNames.Length){
                    if(title==movieNames[i]){
                        i=movieNames.Length+1;
                        Console.WriteLine("Selection already in database");
                        x=1;
                    }
                    else{
                        i++;
                    }

                }
            }
            x = 1;
            String genre = String.Empty;
            while(x == 1){
                Console.Write("Genre: ");
                genre = genre + "|" + Console.ReadLine();
                Console.WriteLine("Add another genre? 1=yes 2=no");
                x = int.Parse(Console.ReadLine());
            }
            genre=genre.Substring(1);
            String fullString = movieID + "," + title + "," + genre;
            StreamWriter sw = new StreamWriter("movies.csv", true);
            sw.WriteLine(fullString);
            sw.Close();
            Console.WriteLine("Movie Added");
            Console.WriteLine();
        }

        static void RunList(){
            //lists movies
            Console.WriteLine("Movie List");
            StreamReader sr = new StreamReader("movies.csv");
            string[] wholeFile = File.ReadAllLines("movies.csv");
                int i = 1;
                int x = 1;
            while(i < wholeFile.Length){
                string[] lineHolder = wholeFile[i].Split(",");
                string[] genreHolder = lineHolder[2].Split("|");
                i++;
                String genreString = genreHolder[0];
                while(x < genreHolder.Length){
                    genreString = genreString + ", " + genreHolder[x];
                    x++;
                }
                Console.WriteLine("MovieID: " + lineHolder[0] + " Title: " + lineHolder[1] + " Genres: " + genreString);
            }
            sr.Close();
            Console.WriteLine();
        }
    }
}
