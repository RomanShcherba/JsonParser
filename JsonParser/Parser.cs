using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser
{
    public class Parser
    {
        /// <summary>
        /// Method for parsing data from JSON file.
        /// </summary>
        public static void Main()
        {
            var jsonContent = File.ReadAllText("D:\\EPAM\\JsonParser\\JsonParser\\JSON.json");
            JObject jsonObject = JObject.Parse(jsonContent);

            Console.WriteLine("Loaded JSON content:");
            Console.WriteLine(jsonContent);
   
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Interface Settings");
                Console.WriteLine("2. Media Interface Settings");
                Console.WriteLine("3. Port Settings");
                Console.WriteLine("4. Unique ID");
                Console.WriteLine("5. MAC Address");
                Console.WriteLine("6. Component Interconnect ID");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplaySettings(jsonObject, "Interface Settings");
                        ForSettingSearch(jsonObject, "Interface Settings");
                    break;
                    case "2":
                        DisplaySettings(jsonObject, "Media Interface Settings");
                        ForSettingSearch(jsonObject, "Media Interface Settings");
                    break;
                    case "3":
                        DisplaySettings(jsonObject, "Port Settings");
                        ForSettingSearch(jsonObject, "Port Settings");
                        break;
                    case "4":
                        DisplaySettings(jsonObject, "Unique ID");
                        ForSettingSearch(jsonObject, "Unique ID");
                        break;
                    case "5":
                        DisplaySettings(jsonObject, "MAC Address");
                        ForSettingSearch(jsonObject, "MAC Address");
                        break;
                    case "6":
                        DisplaySettings(jsonObject, "Component Interconnect ID");
                        ForSettingSearch(jsonObject, "Component Interconnect ID");
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        /// <summary>
        /// Method to setting search 
        /// </summary>
        /// <param name="jsonObject">Is a data in JSON file</param>
        /// <param name="sectionName">Is a parameter from specific section in JSON file</param>
        public static void ForSettingSearch(JObject jsonObject, string sectionName)
        {
            Console.WriteLine($"Enter setting name {sectionName}");
            string settingName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(settingName))
            {
                SearchSetting(jsonObject, sectionName, settingName);
            }
        }
        /// <summary>
        /// Method to search settings in console by name
        /// </summary>
        /// <param name="jsonObject">Is a data in JSON file</param>
        /// <param name="sectionName">Is a parameter from specific section in JSON file</param>
        /// <param name="settingName">Naming of a parameters like (Uniqe Id, TIMEOUT and eg. </param>
        public static void SearchSetting(JObject jsonObject, string sectionName, string settingName)
        {
            Console.WriteLine($"\nSearching for '{settingName}' in {sectionName}:");
            if (jsonObject[sectionName] is JObject section && section[settingName] != null)
            {
                Console.WriteLine($"{settingName}: {section[settingName]}");
            }
            else
            {
                Console.WriteLine($"Setting '{settingName}' not found in {sectionName}.");
            }
        }

        /// <summary>
        /// General method that display and choosing all settings
        /// </summary>
        /// <param name="jsonObject">Is a data from JSON file</param>
        /// <param name="sectionName">Is a parameter from specific section in JSON file</param>
        public static void DisplaySettings(JObject jsonObject, string sectionName)
        {
            Console.WriteLine($"{sectionName} Settings");
            if (jsonObject[sectionName] is JObject section)
            {
                foreach(var item in section)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
            else
            {
                Console.WriteLine($"{sectionName} not found");
            }
        }
      
    }
}
