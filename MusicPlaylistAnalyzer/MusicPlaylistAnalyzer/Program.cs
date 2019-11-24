using System;
using System.Collections.Generic;

namespace MusicPlaylistAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("CrimeAnalyzer <crime_csv_file_path> <report_file_path>");
                Environment.Exit(1);
            }

            string csvDataFilePath = args[0];
            string reportFilePath = args[1];

            List<MusicDetails> crimeStatsList = null;
            try
            {
                crimeStatsList = MusicDetailsLoader.Load(csvDataFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(2);
            }

            var report = MusicDetailsReport.GenerateText(crimeStatsList);

            try
            {
                System.IO.File.WriteAllText(reportFilePath, report);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(3);
            }
            finally
            {
                Console.WriteLine("Thank you for using my music playslist analyzer!");
                Console.WriteLine("A report can be found in MusicPlaylistAnalyzer/MusicPlaylistAnalyzer/bin/debug/netcoreapp2.1\n");
            }
        }
    }
}
