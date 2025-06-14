using System;
using System.Collections.Generic;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (title == null || title.Length > 200)
            throw new ArgumentException("Judul video tidak boleh null dan maksimal 200 karakter.");

        Random rand = new Random();
        this.id = rand.Next(10000, 99999); // ID random 5 digit
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count > 25000000 || count < 0)
            throw new ArgumentException("Play count maksimal 25.000.000 per panggilan " +
                "dan tidak boleh bilangan negatif.");

        checked
        {
            playCount += count;
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"Video ID: {id}");
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Play Count: {playCount}");
    }

    public string GetTitle()
    {
        return title;
    }

    public int GetPlayCount()
    {
        return playCount;
    }
}

class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    public string Username { get; private set; }

    public SayaTubeUser(string username)
    {
        if (username == null || username.Length > 100)
            throw new ArgumentException("Username tidak boleh null dan maksimal 100 karakter.");

        Random rand = new Random();
        this.id = rand.Next(10000, 99999); // ID random 5 digit
        this.Username = username;
        this.uploadedVideos = new List<SayaTubeVideo>();
    }

    public void AddVideo(SayaTubeVideo video)
    {
        if (video == null)
            throw new ArgumentException("Video yang ditambahkan tidak boleh null.");

        uploadedVideos.Add(video);
    }

    public int GetTotalVideoPlayCount()
    {
        int total = 0;
        foreach (var video in uploadedVideos)
        {
            total += video.GetPlayCount();
        }
        return total;
    }

    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine($"User: {Username}");
        for (int i = 0; i < uploadedVideos.Count && i < 8; i++)
        {
            Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].GetTitle()}");
        }
        Console.WriteLine($"\nTotal play count: {GetTotalVideoPlayCount()}");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            SayaTubeUser user = new SayaTubeUser("Kiky");

            List<string> videoTitles = new List<string>
            {
                "Review Film Interstellar oleh Kiky",
                "Review Film Inception oleh Kiky",
                "Review Film The Dark Knight oleh Kiky",
                "Review Film Parasite oleh Kiky",
                "Review Film The Godfather oleh Kiky",
                "Review Film Whiplash oleh Kiky",
                "Review Film Fight Club oleh Kiky",
                "Review Film Joker oleh Kiky",
                "Review Film The Martian oleh Kiky",
                "Review Film Gravity oleh Kiky"
            };

            foreach (var title in videoTitles)
            {
                SayaTubeVideo video = new SayaTubeVideo(title);
                user.AddVideo(video);
            }

            user.PrintAllVideoPlaycount();

            // Simulasi error play count
            try
            {
                SayaTubeVideo testVideo = new SayaTubeVideo("Test Video Error");
                testVideo.IncreasePlayCount(30000000); // Melebihi batas
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
