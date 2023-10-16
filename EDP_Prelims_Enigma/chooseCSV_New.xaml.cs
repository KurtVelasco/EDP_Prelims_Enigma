using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace EDP_Prelims_Enigma
{
    /// <summary>
    /// Interaction logic for chooseCSV_New.xaml
    /// </summary>
    public partial class chooseCSV_New : Window
    {
        private string csvFilePath = "";
        private List<string> csvData = new List<string>();
        private string[] columnNames;
        private string[] ringNumbers;
        private char[][] ringsChar = { };
        private int[][] ringsInt = { };
        private int[] controlInt = { }; 
        private ComboBox[] selectedIndex = new ComboBox[3];
        private int[] rotorInformation = new int[2]; // First is the amount of rotors (not counting control) // Second is char amount


        //Error List:
        // "A Rotor has a invalid Ascii Number or a Empty string value with the csv/txt"
        // "Duplicate keys where found in a rotor
        // "Rotors have Mismatched Lengths"
        // "CSV File Cannot Be Accessed or Another Program is Currently Using it"
        // "A Rotor is Missing an Element Compare to the Control"
        // "The Rotor (Count) Information is Invalid or missing"
        // "The Rotor Header is Missing"
        // "Rotor does not con


        // "Invalid Rotors: Duplicate Rotors are not allowed"

        public chooseCSV_New()
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
                label_filepath.Text = csvFilePath.ToString();
            }
            else
            {
                return;
            }
            button_browse.IsEnabled = false;
            textbox_errorMessage.Text = "No Error Messages";
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
        private void getControlInt(int[][] intArray)
        {
            controlInt = new int[intArray.Length];
            for(int i = 0;i < intArray.Length; i++)
            {
                controlInt[i] = intArray[i][0];
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
                    if(!checkFirst2Rows(ringNumbers, columnNames))
                    {
                        return;
                    }
                    label_ringColumnCount.Content = "Ring Columns: " + ringNumbers[0].ToString();
                    label_ringCharCount.Content = "Character Count: " + ringNumbers[1].ToString();
                    for (int a = 0; a < 2; a++)
                    {
                        csvData.RemoveAt(0);
                    }
                    ringsInt = new int[csvData.Count][];
                    for (int a = 0; a < rotorInformation[1]; a++) //rotorInformation[1] to use the actual information // just use csv.length
                    {
                        ringsInt[a] = new int[columnNames.Length];
                        string[] elements = csvData[a].Split(',');
                        for (int b = 0; b < columnNames.Length; b++) //rotorInformation[0] to use for non Control, use ColumnNames.Lenght
                        {
                            if (int.TryParse(elements[b], out int parsedValue))
                            {
                                ringsInt[a][b] = parsedValue;
                            }
                            else
                            {
                                displayErrorMessages("A Rotor has a invalid Ascii Number or a Empty string value with the csv/txt" );
                                return;
                            }
                        }
                    }
                    if (checkDuplicateChar(ringsInt))
                    {
                        displayErrorMessages("Duplicate keys where found in a rotor");
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                if (e is IndexOutOfRangeException)
                {
                    displayErrorMessages("Rotors have Mismatched Lengths, Either numbers of chars does not match the rotor infomration (Row 1), or an element is missing");
                }
                else if (e is FieldAccessException)
                {
                    //MessageBox.Show(errorMessage[0], "CSV file cannot be access", MessageBoxButton.OK, MessageBoxImage.Error);
                    displayErrorMessages("CSV File Cannot Be Accessed or Another Program is Currently Using it");
                }
                else
                {
                    displayErrorMessages(e.ToString());
                }
                return;
            }
            getControlInt(ringsInt);
            if (!checkRotorswithControl())
            {
                displayErrorMessages("A Rotor is Missing an Element with the Control");
                return;
            }
     

            convertAscii();
            cmb_ring1.IsEnabled = true; cmb_ring2.IsEnabled = true; cmb_ring3.IsEnabled = true;
            displayChoices();


        }
        private void sendRotors(char[][] data)
        {
            universalData.ProcessData(data);
            universalData.filePath = csvFilePath;
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
        private void cmb_ring_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool flag = true;
            foreach (ComboBox a in selectedIndex)
            {
                if (a.SelectedIndex == -1)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                button_confirm.IsEnabled = flag;
            }
        }
        private void button_reset_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ss = MessageBox.Show("Choose another CSV File?", "Reset CSV", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (ss == MessageBoxResult.Yes)
            {
                chooseCSV_New csvM = new chooseCSV_New();
                csvM.Show();
                this.Close();
            }
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            int[] rotorChoice = new int[4];
            rotorChoice[0] = 0;
            for (int i = 1; i < rotorChoice.Length; i++)
            {
                rotorChoice[i] = (int)selectedIndex[i - 1].SelectedItem;
            }
            if (checkSelectedRotors(rotorChoice))
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


        //Error Checkings 
        private void displayErrorMessages(string error)
        {
            textbox_errorMessage.Text = error;
        }
        public bool checkSelectedRotors(int[] arr)
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
        private bool checkDuplicateChar(int[][] array)
        {
            int columnCount = array[0].Length;
            int rowCount = array.Length;

            for (int a = 0; a < columnCount; a++)
            {
                for (int b = 0; b < rowCount - 1; b++)
                {
                    int value1 = array[b][a];

                    for (int c = b + 1; c < rowCount; c++)
                    {
                        int value2 = array[c][a];

                        if (value1 == value2)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private bool checkRotorswithControl()
        {
            for (int a = 0; a < ringsInt[0].Length; a++)
            {
                for (int b = 0; b < ringsInt.Length; b++)
                {
                    int asciiNumber = ringsInt[b][a];
                    if (!controlInt.Contains(asciiNumber))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool checkFirst2Rows(string[] colummInfo, string[] headers)
        {
            bool flag = true;
            if (colummInfo.Length != 2)
            {
                displayErrorMessages("The Rotor (Count) Information is Invalid or missing");
                return false;
            }

            for (int b = 0; b < colummInfo.Length; b++)
            {
                if (int.TryParse(colummInfo[b], out int parsedValue))
                {
                    rotorInformation[b] = parsedValue;
                }
                else
                {
                    displayErrorMessages("The Rotor (Count) Information (Non-Numerical) is Invalid or missing");
                    return false;
                }

            }
            for (int a = 0; a < headers.Length; a++)
            {
                if (int.TryParse(headers[a], out int checkParse))
                {
                    displayErrorMessages("The Rotor Header is Missing");
                    return false;
                }
                else
                {

                }
            }
            if (rotorInformation[0] != headers.Length - 1)
            {
                displayErrorMessages("The amount of Rotors in the Rotor Information is not Equal to the actual amount of rotors \n" + "Number of Rotors: " + rotorInformation[0] +  "Number of actual rotors" + (headers.Length -1) );
                return false;
            }
            return flag;

        }
    }
}
