using System;
using System.IO;
using System.Text.Json;

class TeamMembers2211104005
{
    class Member
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public string nim { get; set; }
    }

    class Team
    {
        public Member[] members { get; set; }
    }

    public static void ReadJSON()
    {
        string filePath = "jurnal7_2_2211104029.json";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File JSON tidak ditemukan.");
            return;
        }

        // Membaca dan melakukan parsing JSON
        Team team = JsonSerializer.Deserialize<Team>(File.ReadAllText(filePath));

        Console.WriteLine("Team member list:");
        foreach (var member in team.members)
        {
            Console.WriteLine($"{member.nim} {member.firstName} {member.lastName}  " +
                $"({member.age} {member.gender})");
        }
    }
}