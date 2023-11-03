using Newtonsoft.Json;
using SchoolChatGPT_v1._0.NeuralNetworkClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SchoolChatGPT_v1._0;


namespace ShoolChat_Beta_v1._0
{
    public class DataChats
    {
        public List<List<string>> dataChats;
        public List<Button> buttonsChat;
        private string json;

        /// <summary>
        /// Конструктор класса Data, инициализирующий объект Data с предоставленными данными.
        /// </summary>
        public DataChats(List<List<string>> dataChats, List<Button> buttonsChat)
        {
            this.dataChats = dataChats;
            this.buttonsChat = buttonsChat;
        }

        /// <summary>
        /// Пустой конструктор класса Data.
        /// </summary>
        public DataChats()
        {
            this.dataChats = new List<List<string>>();
            this.buttonsChat = new List<Button>();
        }

        /// <summary>
        /// Получить данные из файла JSON.
        /// </summary>
        public DataChats GetData()
        {
            try
            {
                json = File.ReadAllText(@"E:\Alex\Prodaction\Programming\Unity\SchoolChatGPT_v1.0\SchoolChatGPT_v1.0\dataChats.json");
                DataChats data = JsonConvert.DeserializeObject<DataChats>(json);
                return data;
            }
            catch
            {
                SetData(dataChats, buttonsChat);
                return this;
            }
        }

        /// <summary>
        /// Установить данные в файл JSON.
        /// </summary>
        public void SetData(List<List<string>> dataChats, List<Button> buttonsChat)
        {
            UpdateData(dataChats,buttonsChat);
            DataChats data = this;
            json = JsonConvert.SerializeObject(data);
            File.WriteAllText(@"E:\Alex\Prodaction\Programming\Unity\SchoolChatGPT_v1.0\SchoolChatGPT_v1.0\dataChats.json", json);
        }

        private void UpdateData(List<List<string>> dataChats, List<Button> buttonsChat)
        {
            this.dataChats = dataChats;
            this.buttonsChat = buttonsChat;
        }
    }
}
