using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Mod_Builder.Classes
{
    public class Translate
    {
        Dictionary<string, string> strings = new Dictionary<string, string>();
        Log log;

        public Translate(Log log)
        {
            this.log = log;

            // Get the current culture.
            string currLang = new RegionInfo(Thread.CurrentThread.CurrentCulture.LCID).Name.ToLower();

            this.changeLanguage(currLang);
        }

        public string translate(string key)
        {
            // Check if we have the language key in here.
            if (!this.strings.ContainsKey(key))
                throw new LanguageKeyNotFoundException("Could not find language key: " + key);

            // Return.
            string value;
            if (!this.strings.TryGetValue(key, out value) || value.Length == 0)
                throw new LanguageKeyNotFoundException("The specified key is either not valid or it has no data associated: " + key);

            return value;
        }

        public void loadTranslationFile(string file)
        {
            if (!File.Exists(file))
                throw new LanguageFileNotFoundException("Could not find the specified language file: " + file);

            try
            {
                string[] lines = File.ReadAllLines(file);
                Dictionary<string, string> nstrings = new Dictionary<string, string>();

                string[] pieces;
                foreach (string line in lines)
                {
                    // Ignore any lines starting with #, and empty lines.
                    if (line.Trim().Length == 0 || line.Substring(0, 1) == "#")
                        continue;

                    // Split the string.
                    pieces = line.Split(new string[] { ": " }, 2, StringSplitOptions.None);

                    if (pieces.Length < 2)
                        throw new InvalidLanguageEntryException("An invalid language entry was found in file " + file);

                    nstrings.Add(pieces[0], pieces[1]);
                }

                this.log.log("Loaded " + nstrings.Count + " language strings into memory from language file " + file, "LANG");
                this.strings = nstrings;
            }
            catch
            {
                throw new LanguageFileNotFoundException("An error occured while loading and parsing the language file.");
            }
        }

        public bool changeLanguage(string code)
        {
            // Attempt to load the language file for this language.
            try
            {
                this.loadTranslationFile(Environment.CurrentDirectory + "/lang/" + code + ".mblang");
                return true;
            }

            // If this failed for whatever reason, default to the English language file.
            catch
            {
                this.log.log("Could not load language file for language code " + code + ", falling back to English.", "LANG");
                this.loadTranslationFile(Environment.CurrentDirectory + "/lang/en.mblang");
                return false;
            }
        }
    }

    public class LanguageKeyNotFoundException : Exception
    {
        public LanguageKeyNotFoundException()
        {
        }

        public LanguageKeyNotFoundException(string message)
            : base(message)
        {
        }

        public LanguageKeyNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class LanguageFileNotFoundException : Exception
    {
        public LanguageFileNotFoundException()
        {
        }

        public LanguageFileNotFoundException(string message)
            : base(message)
        {
        }

        public LanguageFileNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class InvalidLanguageEntryException : Exception
    {
        public InvalidLanguageEntryException()
        {
        }

        public InvalidLanguageEntryException(string message)
            : base(message)
        {
        }

        public InvalidLanguageEntryException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
