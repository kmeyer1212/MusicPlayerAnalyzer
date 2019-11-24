using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MusicPlaylistAnalyzer
{
    class MusicDetailsLoader
    {
        private static int numOfHeaders = 8;

        public static List<MusicDetails> Load(string filePath)
        {
            List<MusicDetails> musicList = new List<MusicDetails>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    int lineNumber = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        lineNumber++;
                        if (lineNumber == 1) continue;

                        var values = line.Split('\t');

                        if (values.Length != numOfHeaders)
                        {
                            throw new Exception($"Row {lineNumber} contains {values.Length} values. It should contain {numOfHeaders}.");
                        }
                        try
                        {
                            string name = values[0];
                            string artist = values[1];
                            string album = values[2];
                            string genre = values[3];
                            int size = Int32.Parse(values[4]);
                            int time = Int32.Parse(values[5]);
                            int year = Int32.Parse(values[6]);
                            int plays = Int32.Parse(values[7]);
                            MusicDetails musicDeets = new MusicDetails(name, artist, album, genre, size, time, year, plays);
                            musicList.Add(musicDeets);
                        }
                        catch (FormatException e)
                        {
                            throw new Exception($"Row {lineNumber} contains invalid data. ({e.Message})");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to open {filePath} ({e.Message}).");
            }

            return musicList;
        }
    }
}
