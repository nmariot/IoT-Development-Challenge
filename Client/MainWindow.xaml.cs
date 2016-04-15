﻿using IO.Swagger.Client;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEnvoiMessage_Click(object sender, RoutedEventArgs e)
        {
            var c = new ApiClient("http://127.0.0.1:90");
            IRestResponse reponse = c.CallApi("/messages", RestSharp.Method.POST, new Dictionary<string, string>(), 
                "{  \"id\": \"12\",  \"timestamp\": \"sdf\",  \"sensorType\": 123,  \"value\": 123123}", 
                new Dictionary<string, string>(), new Dictionary<string, string>(), new Dictionary<string, FileParameter>(), new Dictionary<string, string>(), "application / json") as IRestResponse;
        }
    }
}
