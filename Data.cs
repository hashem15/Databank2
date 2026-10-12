using Microsoft.Data.Sqlite;

namespace database;

public class Data
{
    public static void Main()
    {
        try
        {
            using var connection = new SqliteConnection("Data Source=Flashcards.db");
            connection.Open();

            var sql = "INSERT INTO word_pairs (english_word, french_word) " +
                      "VALUES (@english_word, @french_word)";

            AddWord(connection, sql, "hello", "bonjour");
            AddWord(connection, sql, "house", "maison");
            AddWord(connection, sql, "school", "école");
            AddWord(connection, sql, "book", "livre");
            AddWord(connection, sql, "car", "voiture");
            var words = new List<(string English, string French)>

            {

                ("hello", "bonjour"),

                ("house", "maison"),

                ("school", "école"),

                ("book", "livre"),

                ("car", "voiture")

            };

            while (words.Count > 0)

            {

                for (int i = words.Count - 1; i >= 0; i--)

                {

                    Console.Write($"Wat is {words[i].English} in het Frans? ");

                    var answer = Console.ReadLine();

                    if (answer == words[i].French)

                    {

                        Console.WriteLine("Juist!");

                        words.RemoveAt(i);

                    }

                    else

                    {

                        Console.WriteLine("Fout!");

                    }

                }

            }

            Console.WriteLine("Alle woorden zijn juist!");

        }

        catch (SqliteException ex)

        {

            Console.WriteLine(ex.Message);

        }

    }

    static void AddWord(SqliteConnection connection, string sql, string englishWord, string frenchWord)

    {

        using var command = new SqliteCommand(sql, connection);

        command.Parameters.AddWithValue("@english_word", englishWord);

        command.Parameters.AddWithValue("@french_word", frenchWord);

        command.ExecuteNonQuery();

    }
}