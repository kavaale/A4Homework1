using System;
using System.IO;
using Classes;
using Newtonsoft.Json;

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
            if(!File.Exists("movies.json")){
                StreamWriter sw = new StreamWriter("movies.json");
                sw.Close();
            }
            if(!File.Exists("shows.json")){
                StreamWriter sw = new StreamWriter("shows.json");
                sw.Close();
            }
            if(!File.Exists("videos.json")){
                StreamWriter sw = new StreamWriter("videos.json");
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
            Movie m = new Movie();
            m.AddMovie();
            int x=1;
            String genre = m.genres[0];
            while(x<m.genres.Count){
                genre = genre + "|" + m.genres[x];
                x++;
            }
            /* m.WriteCSV(genre); */
            m.WriteJSON();
            Console.WriteLine("Movie Added");
            Console.WriteLine();
        }

        static void RunAddShow(){
            //adds show into file
            Show m = new Show();
            m.AddShow();
            int x=1;
            String writer = m.writers[0];
            while(x<m.writers.Count){
                writer = writer + "|" + m.writers[x];
                x++;
            }
            /* m.WriteCSV(writer); */
            m.WriteJSON();
            Console.WriteLine("Show Added");
            Console.WriteLine();
        }

        static void RunAddVideo(){
            //adds video into file
            
            Video m = new Video();
            m.AddVideo();
            int x=1;
            String region = m.regions[0];
            while(x<m.regions.Count){
                region = region + "|" + m.regions[x];
                x++;
            }
            /* m.WriteCSV(region); */
            m.WriteJSON();
            Console.WriteLine("Video Added");
            Console.WriteLine();
        }

        static void RunList(){
            Console.WriteLine("Which directory would you like to view?");
            Console.WriteLine("1. movies.json");
            Console.WriteLine("2. shows.json");
            Console.WriteLine("3. videos.json");
            Console.WriteLine("4. Back to main menu");
            int x = int.Parse(Console.ReadLine());
            int y = 1;
            if(x==1){
                Console.WriteLine("Movie List");
                StreamReader sr = new StreamReader("movies.json");
                string[] wholeFile = File.ReadAllLines("movies.json");
                int i = 0;
                while (i < wholeFile.Length)
                {
                    Movie m = JsonConvert.DeserializeObject<Movie>(wholeFile[i]);
                    String genres = m.genres[0];
                    while (y < m.genres.Count){
                        genres = genres + ", " + m.genres[y];
                        y++;
                    }
                    Console.WriteLine("MovieID: " + m.id + " Title: " + m.title + " Genre: " + genres);
                    i++;
                }
            }
            else if(x==2){
                Console.WriteLine("Show List");
                StreamReader sr = new StreamReader("shows.json");
                string[] wholeFile = File.ReadAllLines("shows.json");
                int i = 0;
                while (i < wholeFile.Length)
                {
                    Show m = JsonConvert.DeserializeObject<Show>(wholeFile[i]);
                    String writers = m.writers[0];
                    while (y < m.writers.Count){
                        writers = writers + ", " + m.writers[y];
                        y++;
                    }
                    Console.WriteLine("ShowID: " + m.id + " Title: " + m.title + " Season: " + m.season + 
                    " Episode: " + m.episode + " Writers: " + writers);
                    i++;
                }
            }
            else if(x==3){
                Console.WriteLine("Video List");
                StreamReader sr = new StreamReader("videos.json");
                string[] wholeFile = File.ReadAllLines("videos.json");
                int i = 0;
                while (i < wholeFile.Length)
                {
                    Video m = JsonConvert.DeserializeObject<Video>(wholeFile[i]);
                    String regions = m.regions[0];
                    while (y < m.regions.Count){
                        regions = regions + ", " + m.regions[y];
                        y++;
                    }
                    Console.WriteLine("VideoID: " + m.id + " Title: " + m.title + " Format: " + m.format + 
                    " Length: " + m.length + " Regions: " + regions);
                    i++;
                }
            }
            else if(x!=4){
                Console.WriteLine("Unrecognized Command");
            }
        }
    }
}