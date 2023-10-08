using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EDP_Prelims_Enigma
{
    internal static class encryptLogic
    {
        static string control = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string originalRotor_1 = "DMTWSILRUYQNKFEJCAZBPGXOHV";
        static string originalRotor_2 = "HQZGPJTMOBLNCIFDYAWVEUSRKX";
        static string originalRotor_3 = "UQNTLSZFMREHDPXKIBVYGJCWOA";
        static string[] rotors = new string[3];
        static int[] rotorIncrements = new int[3];
        static int[] ringSettings = new int[3];
        public static void getEncryptionData()
        {
            control = "";
            originalRotor_1 = "";
            originalRotor_2 = "";
            originalRotor_3 = "";
            char[][] dataGet = universalData.entryptionArray;
            for (int i = 0; i < dataGet.Length; i++)
            {
                control += dataGet[i][0];
                originalRotor_1 += dataGet[i][1];
                originalRotor_2 += dataGet[i][2];
                originalRotor_3 += dataGet[i][3];
            }
        }

        public static void setDefaultEnigma()
        {
            rotors[0] = originalRotor_1.ToString(); rotors[1] = originalRotor_2.ToString(); rotors[2] = originalRotor_3.ToString();

        }

        public static char Encrypt(char letter)
        {
            int controlIndex = control.IndexOf(letter);
            char encryptedLetter = rotors[0][controlIndex];

            controlIndex = control.IndexOf(encryptedLetter);
            encryptedLetter = rotors[1][controlIndex];

            controlIndex = control.IndexOf(encryptedLetter);
            encryptedLetter = rotors[2][controlIndex];
            return encryptedLetter;
        }
    }
}
