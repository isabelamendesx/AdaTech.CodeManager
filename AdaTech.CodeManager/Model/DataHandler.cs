using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.CodeManager.Model
{
    public class DataHandler
    {
        public static void LoadData<T>(ref List<T> dataList, string filePath)
        {
            if (File.Exists(filePath))
            {
                Console.WriteLine($"Loading data from file '{filePath}'...");

                string json = File.ReadAllText(filePath);

                var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

                try
                {
                    dataList = JsonConvert.DeserializeObject<List<T>>(json, settings);
                    MessageBox.Show($"Data loaded successfully. Count: {dataList.Count}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
        }

        public static void SaveData<T>(List<T> dataList, string filePath)
        {
            Console.WriteLine($"Saving data to file '{filePath}'...");

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            try
            {
                string json = JsonConvert.SerializeObject(dataList, settings);
                File.WriteAllText(filePath, json);
                Console.WriteLine("Data saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}");
            }
        }
    }
}
