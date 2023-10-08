using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace EDP_Prelims_Enigma
{
    /// <summary>
    /// Interaction logic for chooseCSV.xaml
    /// </summary>
    public partial class chooseCSV : Window
    {

        private string csvFilePath = "";
        private List<string> csvData = new List<string>();
        private string[] columnNames;
        private string[] ringNumbers;
        private List<int> refRingNumbers = new List<int>();
        private char[][] ringsChar = { };
        private int[][] ringsInt = { };
        private ComboBox[] selectedIndex = new ComboBox[3];
        public chooseCSV()
        {
            InitializeComponent();
            selectedIndex[0] = cmb_ring1;
            selectedIndex[1] = cmb_ring2;
            selectedIndex[2] = cmb_ring3;
        }
        private void button_browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Pick csv file";
            ofd.DefaultExt = "csv";
            ofd.InitialDirectory = "";
            ofd.Filter = "CSV Files (*.csv)|*.csv";

            if ((bool)ofd.ShowDialog())
            {
                csvFilePath = ofd.FileName;
                label_filepath.Content = csvFilePath;
                button_confirm.IsEnabled = true;
                button_browse.IsEnabled = false;
            }

            readFile();

        }
        private void convertAscii()
        {
            ringsChar = new char[ringsInt.Length][];
            for (int i = 0; i < ringsInt.Length; i++)
            {
                ringsChar[i] = new char[ringsInt[i].Length];

                for (int j = 0; j < ringsChar[i].Length; j++)
                {

                    ringsChar[i][j] = (char)ringsInt[i][j];
                }
            }
            MessageBox.Show("mEME");
        }
        private void displayChoices()
        {
            int numberOfColumns = ringsInt[0].Length;

            for (int i = 1; i < numberOfColumns; i++)
            {
                cmb_ring1.Items.Add(i);
                cmb_ring2.Items.Add(i);
                cmb_ring3.Items.Add(i);
            }
        }
        private void displayData(int column, int whichList)
        {
            listbox_control.Items.Clear();

            for (int i = 0; i < ringsInt.Length; i++)
            {
                if (ringsChar[i].Length > 0)
                {
                    listbox_control.Items.Add(ringsChar[i][0]);
                }
            }

            switch (whichList)
            {
                case 1:
                    listbox_rotor1.Items.Clear();
                    for (int i = 0; i < ringsChar.Length; i++)
                    {
                        if (ringsChar[i].Length > 0)
                        {
                            listbox_rotor1.Items.Add(ringsChar[i][column]);
                        }
                    }
                    break;
                case 2:
                    listbox_rotor2.Items.Clear();
                    for (int i = 0; i < ringsInt.Length; i++)
                    {
                        if (ringsInt[i].Length > 0)
                        {
                            listbox_rotor2.Items.Add(ringsChar[i][column]);
                        }
                    }
                    break;
                case 3:
                    listbox_rotor3.Items.Clear();
                    for (int i = 0; i < ringsInt.Length; i++)
                    {
                        if (ringsInt[i].Length > 0)
                        {
                            listbox_rotor3.Items.Add(ringsChar[i][column]);
                        }
                    }
                    break;
            }

        }
        private void readFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(csvFilePath))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        csvData.Add(line);
                    }
                    columnNames = csvData[1].Split(',');
                    ringNumbers = csvData[0].Split(',');
                    label_ringColumnCount.Content = "Ring Columns: " + ringNumbers[0].ToString();
                    label_ringCharCount.Content = "Character Count: " + ringNumbers[1].ToString();
                    for (int a = 0; a < 2; a++)
                    {
                        csvData.RemoveAt(0);
                    }
                    ringsInt = new int[csvData.Count][];
                    for (int a = 0; a < csvData.Count; a++)
                    {
                        ringsInt[a] = new int[columnNames.Length];
                        string[] elements = csvData[a].Split(',');
                        for (int b = 0; b < columnNames.Length; b++)
                        {
                            if (int.TryParse(elements[b], out int parsedValue))
                            {
                                ringsInt[a][b] = parsedValue;
                            }
                        }
                    }
                }
                convertAscii();
                displayData(0, 0);
                displayChoices();
            }
            catch (Exception e)
            {
                MessageBox.Show("CSV File Cannot be Access or Is being used by another process", "CSV file cannot be access", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }



        private void cmb_ring1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string comboBoxName = "";
            int selectedItem = 0;
            if (sender is ComboBox comboBox)
            {
                comboBoxName = comboBox.Name;
                selectedItem = (int)comboBox.SelectedItem;
            }
            switch (comboBoxName)
            {
                case "cmb_ring1":
                    displayData(selectedItem, 1);
                    break;
                case "cmb_ring2":
                    displayData(selectedItem, 2);
                    break;
                case "cmb_ring3":
                    displayData(selectedItem, 3);
                    break;
            }
        }
        private void sendRotors(char[][] data)
        {
            universalData.ProcessData(data);
            universalData.filePath = csvFilePath;
        }

        public bool hasDuplicates(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            int[] rotorChoice = new int[4];
            rotorChoice[0] = 0;
            if (listbox_rotor1.Items.Count != ringsInt.Length && listbox_rotor2.Items.Count != ringsInt.Length && listbox_rotor3.Items.Count != ringsInt.Length)
            {
                MessageBox.Show("Choose 3 Encryption Rotors");
                return;
            }

            for (int i = 1; i < rotorChoice.Length; i++)
            {
                rotorChoice[i] = (int)selectedIndex[i - 1].SelectedItem;
            }
            if (hasDuplicates(rotorChoice))
            {
                MessageBox.Show("Invalid Rotors: Duplicate Rotors are not allowed");
                return;
            }
            MessageBoxResult ss = MessageBox.Show("Are you sure for this settings?", "Rotor Encrypt", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (ss == MessageBoxResult.Yes)
            {
                MessageBox.Show("Enryption Rotors Set");
                packSelectedRotors(rotorChoice);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }


        }
        private void packSelectedRotors(int[] dataIndex)
        {

            char[][] tempChar = new char[ringsInt.Length][];
            for (int i = 0; i < ringsChar.Length; i++)
            {
                tempChar[i] = new char[dataIndex.Length];
                for (int j = 0; j < dataIndex.Length; j++)
                {
                    tempChar[i][j] = (char)ringsChar[i][dataIndex[j]];
                }
            }
            sendRotors(tempChar);
            MessageBox.Show("Rotors Initialized");
        }

        private void Default_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ss = MessageBox.Show("Use a set of default Rotors?", "Default Rotors", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (ss == MessageBoxResult.Yes)
            {
                universalData.defaultRotors = true;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }

        }
    }
}
