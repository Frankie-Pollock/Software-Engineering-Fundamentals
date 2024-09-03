using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace BankFilteringSystem.Back_End
{
    public class SaveToFile
    {


        public static void JsonS(string jsons)
        {
            /// Getting the current datatest.text from executables directory
            string filesLocation = Environment.CurrentDirectory;
            string filepath = filesLocation + "\\datatest.text";
            JsonSerializer jsonSerializer = new JsonSerializer();
            if (File.Exists(filepath)) File.Delete(filepath);
            /// Writing the contents to the filepath
            StreamWriter sw = new StreamWriter(filepath);
            JsonWriter jsonWriter = new JsonTextWriter(sw);
            /// Serializing the file for input
            jsonSerializer.Serialize(jsonWriter, jsons);
            /// Closing streamwrite and JsonWriter operations
            jsonWriter.Close();
            sw.Close();
        }
    
    }
}