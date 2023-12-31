﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;


namespace NameCleanerForMusic
{
    public class NameEditor
    {
        string nameOfFile;
        string tempName;
        string tempNameOfSong;
        string nameOfSong;
       
        public NameEditor(string name)
        {
            nameOfFile = name;
        }

        public string GetNameFromPath(string fullPath)
        {
            tempNameOfSong = fullPath;
            nameOfSong = Path.GetFileName(tempNameOfSong);
            return nameOfSong;
        }

        public string RenameMusic()
        {
            string first_pattern = @"\s\(vksaver\)|\s\(zaycev.net\)|\s\[Best-Muzon.com\]|&#\d{1,}|&#|#|\d{3,10}|\s\(www.mp3zv.me\)|&amp|;|&quot|\(\)";
            string space_pattern = @"_|\s{2,}";
            string extension_pattern = @"(.mp3){2,}";
            string dot_pattern = @"\.{2,}";
            string replacement = "";
            string dot_replacement = ".";
            string space_replacement = " ";
            string extension_replacement = ".mp3";
            tempName = Regex.Replace(nameOfFile, space_pattern, space_replacement);
            tempName = Regex.Replace(tempName, extension_pattern, extension_replacement);
            tempName = Regex.Replace(tempName, dot_pattern, dot_replacement);
            nameOfFile = Regex.Replace(tempName, first_pattern, replacement);
            return nameOfFile;
        }

    }
}
