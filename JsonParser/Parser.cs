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
        public static void Main()
        {
            var jsonContent = File.ReadAllText("D:\\EPAM\\JsonParser\\JsonParser\\JSON.json");
            JObject jsonObject = JObject.Parse(jsonContent);

            Console.WriteLine("Loaded JSON content:");
            Console.WriteLine(jsonContent);
   
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
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
                         DisplayInterfaceSettings(jsonObject);
                         Console.WriteLine("Enter interface setting name: ");
                         string interfaceSettingName = Console.ReadLine();
                         SearchInterfaceSetting(jsonObject, interfaceSettingName);
                    break;
                    case "2":
                         DisplayMediaInterfaceSettings(jsonObject);
                         Console.WriteLine("Enter media interface setting name: ");
                         string mediaSettingName = Console.ReadLine();
                         SearchMediaInterfaceSetting(jsonObject, mediaSettingName);
                    break;
                    case "3":
                        DisplayPortSettings(jsonObject);
                        break;
                    case "4":
                        DisplayUniqueId(jsonObject);
                        break;
                    case "5":
                        DisplayMacAddress(jsonObject);
                        break;
                    case "6":
                        DisplayComponentInterconnectId(jsonObject);
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        public static void DisplayInterfaceSettings(JObject jsonObject)
        {
            Console.WriteLine("\nInterfaceSettings");

            if (jsonObject["InterfaceSettings"] is JObject interfaceSettings)
            {
                foreach (var setting in interfaceSettings)
                {
                    Console.WriteLine($"{setting.Key}: {setting.Value}");
                }
            }
            else
            {
                Console.WriteLine("Interface settings not found.");
            }
        }

        public static void SearchInterfaceSetting(JObject jsonObject, string settingName)
        {
            Console.WriteLine($"\nSearch for interface setting '{settingName}':");

            if (jsonObject["Interface Settings"] is JObject interfaceSettings && interfaceSettings[settingName] != null)
            {
                Console.WriteLine($"{settingName}: {interfaceSettings[settingName]}");
            }
            else
            {
                Console.WriteLine($"Interface Setting '{settingName}' not found");
            }
        }

        public static void DisplayMediaInterfaceSettings(JObject jsonObject)
        {
            Console.WriteLine("\nMedia Interface Settings");

            if (jsonObject["MediaInterfaceSettings"] is JObject mediaInterfaceSettings)
            {
                foreach (var setting in mediaInterfaceSettings)
                {
                    Console.WriteLine($"{setting.Key}: {setting.Value}");
                }
            }
            else
            {
                Console.WriteLine("Media Interface settings not found.");
            }
        }
        public static void SearchMediaInterfaceSetting(JObject jsonObject, string settingName)
        {
            Console.WriteLine($"\nSearch for media interface setting '{settingName}':");

            if (jsonObject["Media Interface Settings"] is JObject mediaInterfaceSettings && mediaInterfaceSettings[settingName] != null)
            {
                Console.WriteLine($"{settingName}: {mediaInterfaceSettings[settingName]}");
            }
            else
            {
                Console.WriteLine($"Media Interface Setting '{settingName}' not found");
            }
        }
        public static void DisplayPortSettings(JObject jsonObject)
        {
            Console.WriteLine("\nPort Settings:");
            if (jsonObject["Port Settings"] is JObject portSettings)
            {
                foreach (var setting in portSettings)
                {
                    Console.WriteLine($"{setting.Key}: {setting.Value}");
                }
            }
            else
            {
                Console.WriteLine("Port settings not found.");
            }
        }
        public static void DisplayUniqueId(JObject jsonObject)
        {
            Console.WriteLine("\nUnique ID:");
            if (jsonObject["Unique ID"] is JObject uniqueId)
            {
                foreach (var setting in uniqueId)
                {
                    Console.WriteLine($"{setting.Key}: {setting.Value}");
                }
            }
            else
            {
                Console.WriteLine("Unique ID not found.");
            }
        }
        public static void DisplayMacAddress(JObject jsonObject)
        {
            Console.WriteLine("\nMAC Address:");
            if (jsonObject["MAC Address"] is JObject macAddress)
            {
                foreach (var setting in macAddress)
                {
                    Console.WriteLine($"{setting.Key}: {setting.Value}");
                }
            }
            else
            {
                Console.WriteLine("Port settings not found.");
            }
        }
        public static void DisplayComponentInterconnectId(JObject jsonObject)
        {
            Console.WriteLine("\nComponent Interconnect ID:");
            if (jsonObject["Component Interconnect ID"] is JObject componentInterconnectId)
            {
                foreach (var setting in componentInterconnectId)
                {
                    Console.WriteLine($"{setting.Key}: {setting.Value}");
                }
            }
            else
            {
                Console.WriteLine("Component Interconnect Id not found.");
            }
        }
    }

}
