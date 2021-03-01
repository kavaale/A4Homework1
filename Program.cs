using System;
using System.IO;
using Classes;

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
            if(!File.Exists("shows.csv")){
                StreamWriter sw = new StreamWriter("shows.csv");
                sw.WriteLine("movieId,title,season,episode,writers");
                sw.Close();
            }
            if(!File.Exists("videos.csv")){
                StreamWriter sw = new StreamWriter("videos.csv");
                sw.WriteLine("movieId,title,format,length,regions");
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
            Console.WriteLine("2. Add Show");
            Console.WriteLine("3. Add Video");
            Console.WriteLine("4. Show Directory");
            Console.WriteLine("5. Close");
            String choice = Console.ReadLine();
            if(choice == "1"){
                Console.WriteLine();
                RunAddMovie();
            }
            else if(choice == "2"){
                Console.WriteLine();
                RunAddShow();
            }
            else if(choice == "3"){
                Console.WriteLine();
                RunAddVideo();
            }
            else if(choice == "4"){
                Console.WriteLine();
                RunList();
            }
            else if(choice == "5"){
                x = 0;
            }
            else{
                Console.WriteLine("Unrecognized Command");
            }
            return x;
        }


        static void RunAddMovie(){
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
            Console.Write("Genre: ");
            genre = Console.ReadLine();
            Console.WriteLine("Add another genre? 1=yes 2=no");
            x = int.Parse(Console.ReadLine());
            i=1;
            while(x == 1){
                Console.Write("Genre: ");
                genre = genre + "|" + Console.ReadLine();
                Console.WriteLine("Add another genre? 1=yes 2=no");
                x = int.Parse(Console.ReadLine());
            }
            Movie m = new Movie(movieID, title, genre);
            x=1;
            genre = m.genres[0];
            while(x<m.genres.Length){
                genre = genre + "|" + m.genres[x];
                x++;
            }
            String fullString = m.id + "," + m.title + "," + genre;
            StreamWriter sw = new StreamWriter("movies.csv", true);
            sw.WriteLine(fullString);
            sw.Close();
            Console.WriteLine("Movie Added");
            Console.WriteLine();
        }

        static void RunAddShow(){
            //adds show into file
            Console.WriteLine("Enter Show Info");
            
            StreamReader sr = new StreamReader("shows.csv");
            String[] wholeFile = File.ReadAllLines("shows.csv");
            sr.Close();
            String[] showNames = new String[wholeFile.Length - 1];
            int i = 1;
            while(i < wholeFile.Length){
                String[] lineHolder = wholeFile[i].Split(',');
                showNames[i-1] = lineHolder[1];
                i++;
            }

            int showID = i;
            
            int x = 1;
            String title = "";
            while(x==1){
                Console.Write("Title: ");
                title = Console.ReadLine();
                
                i = 0;
                x=0;
                while(i<showNames.Length){
                    if(title==showNames[i]){
                        i=showNames.Length+1;
                        Console.WriteLine("Selection already in database");
                        x=1;
                    }
                    else{
                        i++;
                    }

                }
            }
            x = 1;
            Console.Write("Season: ");
            int season = int.Parse(Console.ReadLine());
            Console.Write("Episode: ");
            int episode = int.Parse(Console.ReadLine());
            String writer = String.Empty;
            Console.Write("Writer: ");
            writer = Console.ReadLine();
            Console.WriteLine("Add another writer? 1=yes 2=no");
            x = int.Parse(Console.ReadLine());
            i=1;
            while(x == 1){
                Console.Write("Writer: ");
                writer = writer + "|" + Console.ReadLine();
                Console.WriteLine("Add another writer? 1=yes 2=no");
                x = int.Parse(Console.ReadLine());
            }
            Show m = new Show(showID, title, season, episode, writer);
            x=1;
            writer = m.writers[0];
            while(x<m.writers.Length){
                writer = writer + "|" + m.writers[x];
                x++;
            }
            String fullString = m.id + "," + m.title + "," + m.season + "," + m.episode + "," + writer;
            StreamWriter sw = new StreamWriter("shows.csv", true);
            sw.WriteLine(fullString);
            sw.Close();
            Console.WriteLine("Show Added");
            Console.WriteLine();
        }

static void RunAddVideo(){
            //adds video into file
            Console.WriteLine("Enter Video Info");
            
            StreamReader sr = new StreamReader("videos.csv");
            String[] wholeFile = File.ReadAllLines("videos.csv");
            sr.Close();
            String[] videoNames = new String[wholeFile.Length - 1];
            int i = 1;
            while(i < wholeFile.Length){
                String[] lineHolder = wholeFile[i].Split(',');
                videoNames[i-1] = lineHolder[1];
                i++;
            }

            int videoID = i;
            
            int x = 1;
            String title = "";
            while(x==1){
                Console.Write("Title: ");
                title = Console.ReadLine();
                
                i = 0;
                x=0;
                while(i<videoNames.Length){
                    if(title==videoNames[i]){
                        i=videoNames.Length+1;
                        Console.WriteLine("Selection already in database");
                        x=1;
                    }
                    else{
                        i++;
                    }

                }
            }
            x = 1;
            Console.Write("Format: ");
            string format = Console.ReadLine();
            Console.Write("Length: ");
            int length = int.Parse(Console.ReadLine());
            String region = String.Empty;
            Console.Write("Region: ");
            region = Console.ReadLine();
            Console.WriteLine("Add another region? 1=yes 2=no");
            x = int.Parse(Console.ReadLine());
            i=1;
            while(x == 1){
                Console.Write("Region: ");
                region = region + "|" + Console.ReadLine();
                Console.WriteLine("Add another region? 1=yes 2=no");
                x = int.Parse(Console.ReadLine());
            }
            Video m = new Video(videoID, title, format, length, region);
            x=1;
            region = m.regions[0];
            while(x<m.regions.Length){
                region = region + "|" + m.regions[x];
                x++;
            }
            String fullString = m.id + "," + m.title + "," + m.format + "," + length + "," + region;
            StreamWriter sw = new StreamWriter("videos.csv", true);
            sw.WriteLine(fullString);
            sw.Close();
            Console.WriteLine("Video Added");
            Console.WriteLine();
        }

        static void RunList(){
            Console.WriteLine("Which directory would you like to view?");
            Console.WriteLine("1. movies.csv");
            Console.WriteLine("2. shows.csv");
            Console.WriteLine("3. videos.csv");
            Console.WriteLine("4. Back to main menu");
            int x = int.Parse(Console.ReadLine());
            if(x==1){
                Classes.Movie.Display();
            }
            else if(x==2){
                Classes.Show.Display();
            }
            else if(x==3){
                Classes.Video.Display();
            }
            else if(x!=4){
                Console.WriteLine("Unrecognized Command");
            }
            
            //lists movies
            // Console.WriteLine("Movie List");
            // StreamReader sr = new StreamReader("movies.csv");
            // string[] wholeFile = File.ReadAllLines("movies.csv");
            //     int i = 1;
            //     int x = 1;
            // while(i < wholeFile.Length){
            //     x=1;
            //     string[] lineHolder = wholeFile[i].Split(",");
            //     string[] genreHolder = lineHolder[2].Split("|");
            //     i++;
            //     String genreString = genreHolder[0];
            //     while(x < genreHolder.Length){
            //         genreString = genreString + ", " + genreHolder[x];
            //         x++;
            //     }
            //     Console.WriteLine("MovieID: " + lineHolder[0] + " Title: " + lineHolder[1] + " Genres: " + genreString);
            // }
            // sr.Close();
            // Console.WriteLine();
        }
    }
}