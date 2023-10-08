using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace EDP_Prelims_Enigma
{
    public static class universalData
    {
        public static char[][] entryptionArray;
        public static string filePath;
        public static bool defaultRotors = false;
        public static void ProcessData(char[][] dataInput)
        {
            entryptionArray = dataInput;
        }

    }
}
