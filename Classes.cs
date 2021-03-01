using System;
using System.IO;

namespace Classes{
    public abstract class Media{
        public int id {get; set;}
        public string title {get; set;}

    }

    public class Movie : Media{
        public string[] genres;
        public Movie(int idi, string titlei, string size){
            this.genres = size.Split("|");
            id = idi;
            title = titlei;
        }

        public static void Display(){
            Console.WriteLine("Movie List");
            StreamReader sr = new StreamReader("movies.csv");
            string[] wholeFile = File.ReadAllLines("movies.csv");
                int i = 1;
                int x = 1;
            while(i < wholeFile.Length){
                x=1;
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

    public class Show : Media{
        public int season {get; set;}
        public int episode {get; set;}
        public string[] writers {get; set;}
        public Show(int idi, string titlei, int seasoni, int episodei, string size){
            this.writers = size.Split("|");
            id = idi;
            title = titlei;
            season = seasoni;
            episode = episodei;
        }
        public static void Display(){
            Console.WriteLine("Show List");
            StreamReader sr = new StreamReader("shows.csv");
            string[] wholeFile = File.ReadAllLines("shows.csv");
                int i = 1;
                int x = 1;
            while(i < wholeFile.Length){
                x=1;
                string[] lineHolder = wholeFile[i].Split(",");
                string[] writerHolder = lineHolder[4].Split("|");
                i++;
                String writerString = writerHolder[0];
                while(x < writerHolder.Length){
                    writerString = writerString + ", " + writerHolder[x];
                    x++;
                }
                Console.WriteLine("ShowID: " + lineHolder[0] + " Title: " + lineHolder[1] + " Season: " + lineHolder[2] + " Episode: " + lineHolder[3] + " Writers: " + writerString);
            }
            sr.Close();
            Console.WriteLine();
        }
    }

    public class Video : Media{
        public string format {get; set;}
        public int length {get; set;}
        public string[] regions {get; set;}
        public Video(int idi, string titlei, string formati, int lengthi, string size){
            this.regions = size.Split("|");
            id = idi;
            title = titlei;
            format = formati;
            length = lengthi;
        }
        public static void Display(){
            Console.WriteLine("Video List");
            StreamReader sr = new StreamReader("videos.csv");
            string[] wholeFile = File.ReadAllLines("videos.csv");
                int i = 1;
                int x = 1;
            while(i < wholeFile.Length){
                x=1;
                string[] lineHolder = wholeFile[i].Split(",");
                string[] regionHolder = lineHolder[4].Split("|");
                i++;
                String regionString = regionHolder[0];
                while(x < regionHolder.Length){
                    regionString = regionString + ", " + regionHolder[x];
                    x++;
                }
                Console.WriteLine("VideoID: " + lineHolder[0] + " Title: " + lineHolder[1] + " Format: " + lineHolder[2] + " Length: " + lineHolder[3] + " Regions: " + regionString);
            }
            sr.Close();
            Console.WriteLine();
        }
    }
}