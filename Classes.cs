using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Classes{
    public interface IMovie
    {
        int id { get; set; }
        string title { get; set; }
        List<string> genres { get; set; }
    }
    public class Movie : IMovie
    {
        public int id { get; set; }
        public string title { get; set; }
        public List<string> genres { get; set; }
        public void WriteCSV(String _genre) {
            StreamWriter sw = new StreamWriter("movies.csv", true);
            sw.WriteLine(this.id + "," + this.title + "," + _genre);
            sw.Close();
        }
        public void WriteJSON() {
            StreamWriter sw = new StreamWriter("movies.json", true);
            sw.WriteLine(JsonConvert.SerializeObject(this));
            sw.Close();
        }
        public void AddMovie()
        {
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
            this.id = i;
            int x = 1;
            while(x==1){
                Console.Write("Title: ");
                this.title = Console.ReadLine();
                i = 0;
                x=0;
                while(i<movieNames.Length){
                    if(this.title==movieNames[i]){
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
            this.genres = new List<string>();
            Console.Write("Genre: ");
            this.genres.Add(Console.ReadLine());
            Console.WriteLine("Add another genre? 1=yes 2=no");
            x = int.Parse(Console.ReadLine());
            i=1;
            while(x == 1){
                Console.Write("Genre: ");
                this.genres.Add(Console.ReadLine());
                Console.WriteLine("Add another genre? 1=yes 2=no");
                x = int.Parse(Console.ReadLine());
            }
        }
        //csv display
        /* public static void Display()
        {
            Console.WriteLine("Movie List");
            StreamReader sr = new StreamReader("movies.csv");
            string[] wholeFile = File.ReadAllLines("movies.csv");
            int i = 1;
            int x = 1;
            while (i < wholeFile.Length)
            {
                x = 1;
                string[] lineHolder = wholeFile[i].Split(",");
                string[] genreHolder = lineHolder[2].Split("|");
                i++;
                String genreString = genreHolder[0];
                while (x < genreHolder.Length)
                {
                    genreString = genreString + ", " + genreHolder[x];
                    x++;
                }
                Console.WriteLine("MovieID: " + lineHolder[0] + " Title: " + lineHolder[1] + " Genres: " + genreString);
            }
            sr.Close();
            Console.WriteLine();
        } */
    }

    public interface IShow
    {
        int id { get; set; }
        string title { get; set; }
        int season { get; set; }
        int episode { get; set; }
        List<string> writers { get; set; }
    }

    public class Show : IShow
    {
        public int id { get; set; }
        public string title { get; set; }
        public int season { get; set; }
        public int episode { get; set; }
        public List<string> writers { get; set; }
        public void WriteCSV(String _writers) {
            StreamWriter sw = new StreamWriter("shows.csv", true);
            sw.WriteLine(this.id + "," + this.title + "," + _writers);
            sw.Close();
        }
        public void WriteJSON() {
            StreamWriter sw = new StreamWriter("shows.json", true);
            sw.WriteLine(JsonConvert.SerializeObject(this));
            sw.Close();
        }
        public void AddShow()
        {
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
            this.id = i;
            int x = 1;
            while(x==1){
                Console.Write("Title: ");
                this.title = Console.ReadLine();
                i = 0;
                x=0;
                while(i<showNames.Length){
                    if(this.title==showNames[i]){
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
            this.season = int.Parse(Console.ReadLine());
            Console.Write("Episode: ");
            this.episode = int.Parse(Console.ReadLine());
            this.writers = new List<string>();
            Console.Write("Writer: ");
            this.writers.Add(Console.ReadLine());
            Console.WriteLine("Add another writer? 1=yes 2=no");
            x = int.Parse(Console.ReadLine());
            while(x == 1){
                Console.Write("Writer: ");
                this.writers.Add(Console.ReadLine());
                Console.WriteLine("Add another writer? 1=yes 2=no");
                x = int.Parse(Console.ReadLine());
            }
        }
        //csv display
        /* public static void Display()
        {
            Console.WriteLine("Show List");
            StreamReader sr = new StreamReader("shows.csv");
            string[] wholeFile = File.ReadAllLines("shows.csv");
            int i = 1;
            int x = 1;
            while (i < wholeFile.Length)
            {
                x = 1;
                string[] lineHolder = wholeFile[i].Split(",");
                string[] writerHolder = lineHolder[4].Split("|");
                i++;
                String writerString = writerHolder[0];
                while (x < writerHolder.Length)
                {
                    writerString = writerString + ", " + writerHolder[x];
                    x++;
                }
                Console.WriteLine("ShowID: " + lineHolder[0] + " Title: " + lineHolder[1] + " Season: " + lineHolder[2] + " Episode: " + lineHolder[3] + " Writers: " + writerString);
            }
            sr.Close();
            Console.WriteLine();
        } */
    }

    public interface IVideo
    {
        int id { get; set; }
        string title { get; set; }
        string format { get; set; }
        int length { get; set; }
        List<string> regions { get; set; }
    }

    public class Video : IVideo
    {
        public int id { get; set; }
        public string title { get; set; }
        public string format { get; set; }
        public int length { get; set; }
        public List<string> regions { get; set; }
        public void WriteCSV(String _region) {
            StreamWriter sw = new StreamWriter("videos.csv", true);
            sw.WriteLine(this.id + "," + this.title + "," + _region);
            sw.Close();
        }
        public void WriteJSON() {
            StreamWriter sw = new StreamWriter("videos.json", true);
            sw.WriteLine(JsonConvert.SerializeObject(this));
            sw.Close();
        }
        public void AddVideo()
        {
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
            this.id = i;           
            int x = 1;
            while(x==1){
                Console.Write("Title: ");
                this.title = Console.ReadLine();  
                i = 0;
                x=0;
                while(i<videoNames.Length){
                    if(this.title==videoNames[i]){
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
            this.format = Console.ReadLine();
            Console.Write("Length: ");
            this.length = int.Parse(Console.ReadLine());
            this.regions = new List<string>();
            Console.Write("Region: ");
            this.regions.Add(Console.ReadLine());
            Console.WriteLine("Add another region? 1=yes 2=no");
            x = int.Parse(Console.ReadLine());
            i=1;
            while(x == 1){
                Console.Write("Region: ");
                this.regions.Add(Console.ReadLine());
                Console.WriteLine("Add another region? 1=yes 2=no");
                x = int.Parse(Console.ReadLine());
            }
        }
        //csv display
        /* public static void Display()
        {
            Console.WriteLine("Video List");
            StreamReader sr = new StreamReader("videos.csv");
            string[] wholeFile = File.ReadAllLines("videos.csv");
            int i = 1;
            int x = 1;
            while (i < wholeFile.Length)
            {
                x = 1;
                string[] lineHolder = wholeFile[i].Split(",");
                string[] regionHolder = lineHolder[4].Split("|");
                i++;
                String regionString = regionHolder[0];
                while (x < regionHolder.Length)
                {
                    regionString = regionString + ", " + regionHolder[x];
                    x++;
                }
                Console.WriteLine("VideoID: " + lineHolder[0] + " Title: " + lineHolder[1] + " Format: " + lineHolder[2] + " Length: " + lineHolder[3] + " Regions: " + regionString);
            }
            sr.Close();
            Console.WriteLine();
        } */
    }
}