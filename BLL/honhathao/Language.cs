using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Reflection;
namespace BLL
{
    public class Language
    {
        private static string path_init = string.Empty;
        private static string path_currentLanguege = string.Empty;
        private static string current_Languages = null;
        public static Dictionary<string, string> languages = new Dictionary<string, string>();

        public static string GetCurrentLanguage()
        {
            string appRoot = AppDomain.CurrentDomain.BaseDirectory;
            path_init = Path.GetFullPath(Path.Combine(appRoot, "honhathao", "languages", "initialLanguage.txt"));
            string temp = File.ReadAllText(path_init);
            Console.WriteLine($": {temp}");
            current_Languages = temp;
            return temp;
        }
        public static void SetCurrentLanguage(string nameLanguage)
        {
            File.WriteAllText(path_init, nameLanguage);
            current_Languages = nameLanguage;
            ReadFileLanguges();
        }
        public static string[] getListLanguage()
        {
            List<string> listLanguage = new List<string>();
            string appRoot = AppDomain.CurrentDomain.BaseDirectory;
            string folderPath = Path.Combine(appRoot, "honhathao", "languages", "ListLanguage.txt");
            if (!File.Exists(folderPath))
            {
                throw new FileNotFoundException($"File not found: {folderPath}");
            }
            string[] lines = File.ReadAllLines(folderPath);
            return lines; ;
        }

        public static void ReadFileLanguges()
        {

            string appRoot = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.GetFullPath(Path.Combine(appRoot, "honhathao", "languages", $"{current_Languages}.txt")); // Chuẩn hóa đường dẫn
            path_currentLanguege = filePath;
            Console.WriteLine($"File path: {path_currentLanguege}");
            if (!File.Exists(path_currentLanguege))
            {
                throw new FileNotFoundException($"File not found: {path_currentLanguege}");
            }
            var result = new Dictionary<string, string>();
            var regex = new Regex(@"^\s*(.+?)\s*:\s*(.*?)\s*$");

            foreach (string line in File.ReadAllLines(path_currentLanguege))
            {
                var match = regex.Match(line);
                if (match.Success)
                {
                    result[match.Groups[1].Value] = match.Groups[2].Value;
                }
            }
            languages = result;
        }
        public static string translate(string key)
        {
            if (languages.ContainsKey(key))
            {
                return languages[key];
            }
            else
            {
                return key;
            }
        }
    }
}
