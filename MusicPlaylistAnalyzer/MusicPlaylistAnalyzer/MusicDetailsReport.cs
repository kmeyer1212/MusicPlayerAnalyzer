using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlaylistAnalyzer
{
    class MusicDetailsReport
    {
        public static string GenerateText(List<MusicDetails> musicList)
        {
            string questionBarrier = "============================================\n";
            string report = "Music Details Report\n\n";

            if (musicList.Count() < 1)
            {
                report += "No data is available.\n";

                return report;
            }

            report += questionBarrier + "Songs that recieved 200 or more plays: ";
            var test = from musicDeets in musicList
                       where musicDeets.Plays >= 200
                       select ("\nName: " + musicDeets.Name + 
                               "\nArtist: " + musicDeets.Artist +
                               "\nAlbum: " + musicDeets.Album +
                               "\nGenre: " + musicDeets.Genre +
                               "\nSize: " + musicDeets.Size +
                               "\nTime: " + musicDeets.Time +
                               "\nYear: " + musicDeets.Year +
                               "\nPlays: " + musicDeets.Plays);
            if(test.Count() > 0)
            {
                foreach(var play in test)
                {
                    report += play + "\n\n";
                }
            }
            else
            {
                report += "Not Available\n";
            }

            report += questionBarrier + "Number of Alternative Songs: ";
            var numAltSongs = from musicDeets in musicList where musicDeets.Genre == "Alternative" select musicDeets.Name;
            int totalNum = 0;
            if(numAltSongs.Count() > 0)
            {
                foreach(var song in numAltSongs)
                {
                    ++totalNum;
                }
                report += totalNum + "\n\n";
            }
            else
            {
                report += "Not Available\n";
            }

            report += questionBarrier + "Number of Hip-Hop/Rap Songs: ";
            var numRapSongs = from musicDeets in musicList where musicDeets.Genre == "Hip-Hop/Rap" select musicDeets.Name;
            int totalRapNum = 0;
            if(numRapSongs.Count() > 0)
            {
                foreach(var song in numRapSongs)
                {
                    ++totalRapNum;
                }
                report += totalRapNum + "\n\n";
            }
            else
            {
                report += "Not Available\n";
            }

            report += questionBarrier + "Songs from the album Welcome to the Fishbowl: ";
            var fishBowl = from musicDeets in musicList
                       where musicDeets.Album == "Welcome to the Fishbowl"
                       select ("\nName: " + musicDeets.Name +
                               "\nArtist: " + musicDeets.Artist +
                               "\nAlbum: " + musicDeets.Album +
                               "\nGenre: " + musicDeets.Genre +
                               "\nSize: " + musicDeets.Size +
                               "\nTime: " + musicDeets.Time +
                               "\nYear: " + musicDeets.Year +
                               "\nPlays: " + musicDeets.Plays);
            if(fishBowl.Count() > 0)
            {
                foreach(var song in fishBowl)
                {
                    report += song + "\n\n";
                }
            }
            else
            {
                report += "Not Available\n";
            }

            report += questionBarrier + "Songs From Before 1970: ";

            var beforeSeventies = from musicDeets in musicList
                                  where musicDeets.Year < 1970
                                  select ("\nName: " + musicDeets.Name +
                                          "\nArtist: " + musicDeets.Artist +
                                          "\nAlbum: " + musicDeets.Album +
                                          "\nGenre: " + musicDeets.Genre +
                                          "\nSize: " + musicDeets.Size +
                                          "\nTime: " + musicDeets.Time +
                                          "\nYear: " + musicDeets.Year +
                                          "\nPlays: " + musicDeets.Plays);
            if(beforeSeventies.Count() > 0)
            {
                foreach(var song in beforeSeventies)
                {
                    report += song + "\n\n";
                }
            }
            else
            {
                report += "Not Available\n";
            }

            report += questionBarrier + "Song names longer than 85 characters:\n";
            var charNames = from musicDeets in musicList where musicDeets.Name.Length > 85 select musicDeets.Name;
            if(charNames.Count() > 0)
            {
                foreach(var song in charNames)
                {
                    report += song + "\n\n";
                }
            }
            else
            {
                report += "Not Available\n";
            }

            report += questionBarrier + "Longest Song:";
            int maxTime = musicList.Max(musicDeets => musicDeets.Time);
            var longestSong = from musicDeets in musicList
                              where musicDeets.Time == maxTime
                              select ("\nName: " + musicDeets.Name +
                                      "\nArtist: " + musicDeets.Artist +
                                      "\nAlbum: " + musicDeets.Album +
                                      "\nGenre: " + musicDeets.Genre +
                                      "\nSize: " + musicDeets.Size +
                                      "\nTime: " + musicDeets.Time +
                                      "\nYear: " + musicDeets.Year +
                                      "\nPlays: " + musicDeets.Plays);
            if(longestSong.Count() > 0)
            {
                foreach(var song in longestSong)
                {
                    report += song + "\n\n";
                }
            }
            else
            {
                report += "Not Available\n";
            }

            return report;
        }
    }
}