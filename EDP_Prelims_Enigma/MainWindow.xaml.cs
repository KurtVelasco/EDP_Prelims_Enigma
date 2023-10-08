using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace EDP_Prelims_Enigma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region KEYBOARD
        private List<char> numbers = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        private List<char> shift_numbers = new List<char>() { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', };
        private List<char> lowerLetters = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
    'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private List<char> upperLetters = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
    'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private List<char> unshift_symbols = new List<char>() { '-', '=', '[', ']', '\\', ';', '\'', ',', '.', '/' };
        private List<char> shift_symbols = new List<char>() { '_', '+', '{', '}', '|', ':', '"', '<', '>', '?' };
        private List<string> commandButtons = new List<string>() { "Tab", "Shift", "Return", "Back", "Shift Lock", "Space bar" };
        private List<char> lightModules = new List<char>()
        {
            '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
            'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
            'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '-', '_', '=', '+', '[', ']', '{', '}',
            '|', '\\', ':', ';', '\'', '"', ',', '<', '.', '>', '/', '?', ' '
        };
        private Rectangle[] rectanglesArray = new Rectangle[52];
        private Label[] labelArray_keyboard = new Label[52];
        private Ellipse[] elipseArray = new Ellipse[95];
        private Label[] labelArray_LightBoard = new Label[95];
        private bool shiftLock = false;
        private bool shiftDown = false;
        private bool activateRotor = false;
        private int nextRow = 0;
        private double nextColumn = 0;
        private bool keyboardToggle = false;
        #endregion

        #region THINGS
        Rectangle rectangle_1 = new Rectangle();
        Rectangle rectangle_2 = new Rectangle();
        Rectangle rectangle_3 = new Rectangle();
        Rectangle rectangle_4 = new Rectangle();
        Rectangle rectangle_5 = new Rectangle();
        Rectangle rectangle_6 = new Rectangle();
        Rectangle rectangle_7 = new Rectangle();
        Rectangle rectangle_8 = new Rectangle();
        Rectangle rectangle_9 = new Rectangle();
        Rectangle rectangle_0 = new Rectangle();
        Rectangle rectangle_dash = new Rectangle();
        Rectangle rectangle_equals = new Rectangle();
        Rectangle rectangle_return = new Rectangle();
        Rectangle rectangle_q = new Rectangle();
        Rectangle rectangle_w = new Rectangle();
        Rectangle rectangle_e = new Rectangle();
        Rectangle rectangle_r = new Rectangle();
        Rectangle rectangle_t = new Rectangle();
        Rectangle rectangle_y = new Rectangle();
        Rectangle rectangle_u = new Rectangle();
        Rectangle rectangle_i = new Rectangle();
        Rectangle rectangle_o = new Rectangle();
        Rectangle rectangle_p = new Rectangle();
        Rectangle rectangle_openBracket = new Rectangle();
        Rectangle rectangle_closeBracket = new Rectangle();
        Rectangle rectangle_backLash = new Rectangle();
        Rectangle rectangle_back = new Rectangle();
        Rectangle rectangle_tab = new Rectangle();
        Rectangle rectangle_a = new Rectangle();
        Rectangle rectangle_s = new Rectangle();
        Rectangle rectangle_d = new Rectangle();
        Rectangle rectangle_f = new Rectangle();
        Rectangle rectangle_g = new Rectangle();
        Rectangle rectangle_h = new Rectangle();
        Rectangle rectangle_j = new Rectangle();
        Rectangle rectangle_k = new Rectangle();
        Rectangle rectangle_l = new Rectangle();
        Rectangle rectangle_semiColon = new Rectangle();
        Rectangle rectangle_apostrophe = new Rectangle();
        Rectangle rectangle_shiftlock = new Rectangle();
        Rectangle rectangle_shift = new Rectangle();
        Rectangle rectangle_z = new Rectangle();
        Rectangle rectangle_x = new Rectangle();
        Rectangle rectangle_c = new Rectangle();
        Rectangle rectangle_v = new Rectangle();
        Rectangle rectangle_b = new Rectangle();
        Rectangle rectangle_n = new Rectangle();
        Rectangle rectangle_m = new Rectangle();
        Rectangle rectangle_comma = new Rectangle();
        Rectangle rectangle_period = new Rectangle();
        Rectangle rectangle_slash = new Rectangle();
        Rectangle rectangle_spaceBar = new Rectangle();

        Label label_1 = new Label();
        Label label_2 = new Label();
        Label label_3 = new Label();
        Label label_4 = new Label();
        Label label_5 = new Label();
        Label label_6 = new Label();
        Label label_7 = new Label();
        Label label_8 = new Label();
        Label label_9 = new Label();
        Label label_0 = new Label();
        Label label_dash = new Label();
        Label label_equals = new Label();
        Label label_return = new Label();
        Label label_q = new Label();
        Label label_w = new Label();
        Label label_e = new Label();
        Label label_r = new Label();
        Label label_t = new Label();
        Label label_y = new Label();
        Label label_u = new Label();
        Label label_i = new Label();
        Label label_o = new Label();
        Label label_p = new Label();
        Label label_openBracket = new Label();
        Label label_closeBracket = new Label();
        Label label_backLash = new Label();
        Label label_back = new Label();
        Label label_tab = new Label();
        Label label_a = new Label();
        Label label_s = new Label();
        Label label_d = new Label();
        Label label_f = new Label();
        Label label_g = new Label();
        Label label_h = new Label();
        Label label_j = new Label();
        Label label_k = new Label();
        Label label_l = new Label();
        Label label_semiColon = new Label();
        Label label_apostrophe = new Label();
        Label label_shiftlock = new Label();
        Label label_shift = new Label();
        Label label_z = new Label();
        Label label_x = new Label();
        Label label_c = new Label();
        Label label_v = new Label();
        Label label_b = new Label();
        Label label_n = new Label();
        Label label_m = new Label();
        Label label_comma = new Label();
        Label label_period = new Label();
        Label label_slash = new Label();
        Label label_spaceBar = new Label();
        #endregion

        #region ELIPSE
        Ellipse ellipse_1 = new Ellipse();
        Ellipse ellipse_2 = new Ellipse();
        Ellipse ellipse_3 = new Ellipse();
        Ellipse ellipse_4 = new Ellipse();


        Ellipse ellipse_5 = new Ellipse();
        Ellipse ellipse_6 = new Ellipse();
        Ellipse ellipse_7 = new Ellipse();
        Ellipse ellipse_8 = new Ellipse();
        Ellipse ellipse_9 = new Ellipse();
        Ellipse ellipse_0 = new Ellipse();

        Ellipse ellipse_exclamation = new Ellipse();
        Ellipse ellipse_atSymbol = new Ellipse();
        Ellipse ellipse_hastag = new Ellipse();
        Ellipse ellipse_dollar = new Ellipse();
        Ellipse ellipse_percent = new Ellipse();
        Ellipse ellipse_exponent = new Ellipse();
        Ellipse ellipse_and = new Ellipse();
        Ellipse ellipse_asterisk = new Ellipse();
        Ellipse ellipse_openParenthesis = new Ellipse();
        Ellipse ellipse_closeParenthesis = new Ellipse();

        Ellipse ellipse_a = new Ellipse();
        Ellipse ellipse_b = new Ellipse();
        Ellipse ellipse_c = new Ellipse();
        Ellipse ellipse_d = new Ellipse();
        Ellipse ellipse_e = new Ellipse();
        Ellipse ellipse_f = new Ellipse();
        Ellipse ellipse_g = new Ellipse();
        Ellipse ellipse_h = new Ellipse();
        Ellipse ellipse_i = new Ellipse();
        Ellipse ellipse_j = new Ellipse();

        Ellipse ellipse_k = new Ellipse();
        Ellipse ellipse_l = new Ellipse();
        Ellipse ellipse_m = new Ellipse();
        Ellipse ellipse_n = new Ellipse();
        Ellipse ellipse_o = new Ellipse();
        Ellipse ellipse_p = new Ellipse();
        Ellipse ellipse_q = new Ellipse();
        Ellipse ellipse_r = new Ellipse();
        Ellipse ellipse_s = new Ellipse();
        Ellipse ellipse_t = new Ellipse();

        Ellipse ellipse_u = new Ellipse();
        Ellipse ellipse_v = new Ellipse();
        Ellipse ellipse_w = new Ellipse();
        Ellipse ellipse_x = new Ellipse();
        Ellipse ellipse_y = new Ellipse();
        Ellipse ellipse_z = new Ellipse();
        Ellipse ellipse_A = new Ellipse();
        Ellipse ellipse_B = new Ellipse();
        Ellipse ellipse_C = new Ellipse();
        Ellipse ellipse_D = new Ellipse();

        Ellipse ellipse_E = new Ellipse();
        Ellipse ellipse_F = new Ellipse();
        Ellipse ellipse_G = new Ellipse();
        Ellipse ellipse_H = new Ellipse();
        Ellipse ellipse_I = new Ellipse();
        Ellipse ellipse_J = new Ellipse();
        Ellipse ellipse_K = new Ellipse();
        Ellipse ellipse_L = new Ellipse();
        Ellipse ellipse_M = new Ellipse();
        Ellipse ellipse_N = new Ellipse();

        Ellipse ellipse_O = new Ellipse();
        Ellipse ellipse_P = new Ellipse();
        Ellipse ellipse_Q = new Ellipse();
        Ellipse ellipse_R = new Ellipse();
        Ellipse ellipse_S = new Ellipse();
        Ellipse ellipse_T = new Ellipse();
        Ellipse ellipse_U = new Ellipse();
        Ellipse ellipse_V = new Ellipse();
        Ellipse ellipse_W = new Ellipse();
        Ellipse ellipse_X = new Ellipse();

        Ellipse ellipse_Y = new Ellipse();
        Ellipse ellipse_Z = new Ellipse();
        Ellipse ellipse_minus = new Ellipse();
        Ellipse ellipse_underScore = new Ellipse();
        Ellipse ellipse_equals = new Ellipse();
        Ellipse ellipse_plus = new Ellipse();
        Ellipse ellipse_openBracket = new Ellipse();
        Ellipse ellipse_closeBracket = new Ellipse();
        Ellipse ellipse_openSquareBracket = new Ellipse();
        Ellipse ellipse_closeSquareBracket = new Ellipse();

        Ellipse ellipse_openWavyBracket = new Ellipse();
        Ellipse ellipse_closeWavyBracket = new Ellipse();
        Ellipse ellipse_line = new Ellipse();
        Ellipse ellipse_backSlash = new Ellipse();
        Ellipse ellipse_dualDot = new Ellipse();
        Ellipse ellipse_semiComma = new Ellipse();
        Ellipse ellipse_quote = new Ellipse();
        Ellipse ellipse_apostrophe = new Ellipse();
        Ellipse ellipse_comma = new Ellipse();
        Ellipse ellipse_leftArrow = new Ellipse();

        Ellipse ellipse_period = new Ellipse();
        Ellipse ellipse_rightArrow = new Ellipse();
        Ellipse ellipse_forwardSlash = new Ellipse();
        Ellipse ellipse_questionMark = new Ellipse();
        Ellipse ellipse_spaceBar = new Ellipse();
        #endregion

        #region LABELELIPSE
        Label label_lm_1 = new Label();
        Label label_lm_2 = new Label();
        Label label_lm_3 = new Label();
        Label label_lm_4 = new Label();
        Label label_lm_5 = new Label();
        Label label_lm_6 = new Label();
        Label label_lm_7 = new Label();
        Label label_lm_8 = new Label();
        Label label_lm_9 = new Label();
        Label label_lm_0 = new Label();

        Label label_lm_exclamation = new Label();
        Label label_lm_atSymbol = new Label();
        Label label_lm_hastag = new Label();
        Label label_lm_dollar = new Label();
        Label label_lm_percent = new Label();
        Label label_lm_exponent = new Label();
        Label label_lm_and = new Label();
        Label label_lm_asterisk = new Label();
        Label label_lm_openParenthesis = new Label();
        Label label_lm_closeParenthesis = new Label();

        Label label_lm_a = new Label();
        Label label_lm_b = new Label();
        Label label_lm_c = new Label();
        Label label_lm_d = new Label();
        Label label_lm_e = new Label();
        Label label_lm_f = new Label();
        Label label_lm_g = new Label();
        Label label_lm_h = new Label();
        Label label_lm_i = new Label();
        Label label_lm_j = new Label();

        Label label_lm_k = new Label();
        Label label_lm_l = new Label();
        Label label_lm_m = new Label();
        Label label_lm_n = new Label();
        Label label_lm_o = new Label();
        Label label_lm_p = new Label();
        Label label_lm_q = new Label();
        Label label_lm_r = new Label();
        Label label_lm_s = new Label();
        Label label_lm_t = new Label();

        Label label_lm_u = new Label();
        Label label_lm_v = new Label();
        Label label_lm_w = new Label();
        Label label_lm_x = new Label();
        Label label_lm_y = new Label();
        Label label_lm_z = new Label();
        Label label_lm_A = new Label();
        Label label_lm_B = new Label();
        Label label_lm_C = new Label();
        Label label_lm_D = new Label();

        Label label_lm_E = new Label();
        Label label_lm_F = new Label();
        Label label_lm_G = new Label();
        Label label_lm_H = new Label();
        Label label_lm_I = new Label();
        Label label_lm_J = new Label();
        Label label_lm_K = new Label();
        Label label_lm_L = new Label();
        Label label_lm_M = new Label();
        Label label_lm_N = new Label();

        Label label_lm_O = new Label();
        Label label_lm_P = new Label();
        Label label_lm_Q = new Label();
        Label label_lm_R = new Label();
        Label label_lm_S = new Label();
        Label label_lm_T = new Label();
        Label label_lm_U = new Label();
        Label label_lm_V = new Label();
        Label label_lm_W = new Label();
        Label label_lm_X = new Label();

        Label label_lm_Y = new Label();
        Label label_lm_Z = new Label();
        Label label_lm_minus = new Label();
        Label label_lm_underScore = new Label();
        Label label_lm_equals = new Label();
        Label label_lm_plus = new Label();
        Label label_lm_openBracket = new Label();
        Label label_lm_closeBracket = new Label();
        Label label_lm_openSquareBracket = new Label();
        Label label_lm_closeSquareBracket = new Label();

        Label label_lm_openWavyBracket = new Label();
        Label label_lm_closeWavyBracket = new Label();
        Label label_lm_line = new Label();
        Label label_lm_backSlash = new Label();
        Label label_lm_dualDot = new Label();
        Label label_lm_semiComma = new Label();
        Label label_lm_quote = new Label();
        Label label_lm_apostrophe = new Label();
        Label label_lm_comma = new Label();
        Label label_lm_leftArrow = new Label();

        Label label_lm_period = new Label();
        Label label_lm_rightArrow = new Label();
        Label label_lm_forwardSlash = new Label();
        Label label_lm_questionMark = new Label();
        Label label_lm_spaceBar = new Label();
        #endregion


        //Enigma Logic
        private string currentSentence = "";
        private string currentEncrypted = "";
        private string currentMirror = "";

        private string control = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string originalRotor_1 = "DMTWSILRUYQNKFEJCAZBPGXOHV";
        private string originalRotor_2 = "HQZGPJTMOBLNCIFDYAWVEUSRKX";
        private string originalRotor_3 = "UQNTLSZFMREHDPXKIBVYGJCWOA";
        private string[] rotors = new string[3];
        private int[] rotorIncrements = new int[3];
        private int[] ringSettings = new int[3];
        private Label[] rotorLabels = new Label[3];

        public MainWindow()
        {
            InitializeComponent();

            keyboardArray();
            generateRectangles();
            generateElipses();
            if (!universalData.defaultRotors)
            {
                getEncryptionData();
            }
            setDefaultEnigma();
            textbox_ring1.Text = 0 + "-" + ((int)control.Length - 1);
            textbox_ring2.Text = 0 + "-" + ((int)control.Length - 1);
            textbox_ring3.Text = 0 + "-" + ((int)control.Length - 1);
        }
        private void keyboardArray()
        {
            #region KEYBOADY
            rectanglesArray[36] = rectangle_dash;
            rectanglesArray[37] = rectangle_equals;
            rectanglesArray[38] = rectangle_return;
            rectanglesArray[39] = rectangle_openBracket;
            rectanglesArray[40] = rectangle_closeBracket;
            rectanglesArray[41] = rectangle_backLash;
            rectanglesArray[42] = rectangle_semiColon;
            rectanglesArray[43] = rectangle_apostrophe;
            rectanglesArray[44] = rectangle_shiftlock;
            rectanglesArray[45] = rectangle_shift;
            rectanglesArray[46] = rectangle_comma;
            rectanglesArray[47] = rectangle_period;
            rectanglesArray[48] = rectangle_slash;
            rectanglesArray[49] = rectangle_spaceBar;
            rectanglesArray[50] = rectangle_back;
            rectanglesArray[51] = rectangle_tab;
            /////////////////////
            rectanglesArray[0] = rectangle_1;
            rectanglesArray[1] = rectangle_2;
            rectanglesArray[2] = rectangle_3;
            rectanglesArray[3] = rectangle_4;
            rectanglesArray[4] = rectangle_5;
            rectanglesArray[5] = rectangle_6;
            rectanglesArray[6] = rectangle_7;
            rectanglesArray[7] = rectangle_8;
            rectanglesArray[8] = rectangle_9;
            rectanglesArray[9] = rectangle_0;

            rectanglesArray[10] = rectangle_a;
            rectanglesArray[11] = rectangle_b;
            rectanglesArray[12] = rectangle_c;
            rectanglesArray[13] = rectangle_d;
            rectanglesArray[14] = rectangle_e;
            rectanglesArray[15] = rectangle_f;
            rectanglesArray[16] = rectangle_g;
            rectanglesArray[17] = rectangle_h;
            rectanglesArray[18] = rectangle_i;
            rectanglesArray[19] = rectangle_j;
            rectanglesArray[20] = rectangle_k;
            rectanglesArray[21] = rectangle_l;
            rectanglesArray[22] = rectangle_m;
            rectanglesArray[23] = rectangle_n;
            rectanglesArray[24] = rectangle_o;
            rectanglesArray[25] = rectangle_p;
            rectanglesArray[26] = rectangle_q;
            rectanglesArray[27] = rectangle_r;
            rectanglesArray[28] = rectangle_s;
            rectanglesArray[29] = rectangle_t;
            rectanglesArray[30] = rectangle_u;
            rectanglesArray[31] = rectangle_v;
            rectanglesArray[32] = rectangle_w;
            rectanglesArray[33] = rectangle_x;
            rectanglesArray[34] = rectangle_y;
            rectanglesArray[35] = rectangle_z;

            rectanglesArray[36] = rectangle_dash;
            rectanglesArray[37] = rectangle_equals;
            rectanglesArray[38] = rectangle_openBracket;
            rectanglesArray[39] = rectangle_closeBracket;
            rectanglesArray[40] = rectangle_backLash;
            rectanglesArray[41] = rectangle_semiColon;
            rectanglesArray[42] = rectangle_apostrophe;
            rectanglesArray[43] = rectangle_comma;
            rectanglesArray[44] = rectangle_period;
            rectanglesArray[45] = rectangle_slash;

            rectanglesArray[46] = rectangle_tab;
            rectanglesArray[47] = rectangle_shift;
            rectanglesArray[48] = rectangle_return;
            rectanglesArray[49] = rectangle_back;
            rectanglesArray[50] = rectangle_shiftlock;
            rectanglesArray[51] = rectangle_spaceBar;
            //////////////////////////
            labelArray_keyboard[0] = label_1;
            labelArray_keyboard[1] = label_2;
            labelArray_keyboard[2] = label_3;
            labelArray_keyboard[3] = label_4;
            labelArray_keyboard[4] = label_5;
            labelArray_keyboard[5] = label_6;
            labelArray_keyboard[6] = label_7;
            labelArray_keyboard[7] = label_8;
            labelArray_keyboard[8] = label_9;
            labelArray_keyboard[9] = label_0;

            labelArray_keyboard[10] = label_a;
            labelArray_keyboard[11] = label_b;
            labelArray_keyboard[12] = label_c;
            labelArray_keyboard[13] = label_d;
            labelArray_keyboard[14] = label_e;
            labelArray_keyboard[15] = label_f;
            labelArray_keyboard[16] = label_g;
            labelArray_keyboard[17] = label_h;
            labelArray_keyboard[18] = label_i;
            labelArray_keyboard[19] = label_j;
            labelArray_keyboard[20] = label_k;
            labelArray_keyboard[21] = label_l;
            labelArray_keyboard[22] = label_m;
            labelArray_keyboard[23] = label_n;
            labelArray_keyboard[24] = label_o;
            labelArray_keyboard[25] = label_p;
            labelArray_keyboard[26] = label_q;
            labelArray_keyboard[27] = label_r;
            labelArray_keyboard[28] = label_s;
            labelArray_keyboard[29] = label_t;
            labelArray_keyboard[30] = label_u;
            labelArray_keyboard[31] = label_v;
            labelArray_keyboard[32] = label_w;
            labelArray_keyboard[33] = label_x;
            labelArray_keyboard[34] = label_y;
            labelArray_keyboard[35] = label_z;

            labelArray_keyboard[36] = label_dash;
            labelArray_keyboard[37] = label_equals;
            labelArray_keyboard[38] = label_openBracket;
            labelArray_keyboard[39] = label_closeBracket;
            labelArray_keyboard[40] = label_backLash;
            labelArray_keyboard[41] = label_semiColon;
            labelArray_keyboard[42] = label_apostrophe;
            labelArray_keyboard[43] = label_comma;
            labelArray_keyboard[44] = label_period;
            labelArray_keyboard[45] = label_slash;

            labelArray_keyboard[46] = label_tab;
            labelArray_keyboard[47] = label_shift;
            labelArray_keyboard[48] = label_return;
            labelArray_keyboard[49] = label_back;
            labelArray_keyboard[50] = label_shiftlock;
            labelArray_keyboard[51] = label_spaceBar;
            #endregion
            #region ELIPSEARRAY
            elipseArray[0] = ellipse_1;
            elipseArray[1] = ellipse_2;
            elipseArray[2] = ellipse_3;
            elipseArray[3] = ellipse_4;
            elipseArray[4] = ellipse_5;
            elipseArray[5] = ellipse_6;
            elipseArray[6] = ellipse_7;
            elipseArray[7] = ellipse_8;
            elipseArray[8] = ellipse_9;
            elipseArray[9] = ellipse_0;
            elipseArray[10] = ellipse_exclamation;
            elipseArray[11] = ellipse_atSymbol;
            elipseArray[12] = ellipse_hastag;
            elipseArray[13] = ellipse_dollar;
            elipseArray[14] = ellipse_percent;
            elipseArray[15] = ellipse_exponent;
            elipseArray[16] = ellipse_and;
            elipseArray[17] = ellipse_asterisk;
            elipseArray[18] = ellipse_openParenthesis;
            elipseArray[19] = ellipse_closeParenthesis;
            elipseArray[20] = ellipse_a;
            elipseArray[21] = ellipse_b;
            elipseArray[22] = ellipse_c;
            elipseArray[23] = ellipse_d;
            elipseArray[24] = ellipse_e;
            elipseArray[25] = ellipse_f;
            elipseArray[26] = ellipse_g;
            elipseArray[27] = ellipse_h;
            elipseArray[28] = ellipse_i;
            elipseArray[29] = ellipse_j;
            elipseArray[30] = ellipse_k;
            elipseArray[31] = ellipse_l;
            elipseArray[32] = ellipse_m;
            elipseArray[33] = ellipse_n;
            elipseArray[34] = ellipse_o;
            elipseArray[35] = ellipse_p;
            elipseArray[36] = ellipse_q;
            elipseArray[37] = ellipse_r;
            elipseArray[38] = ellipse_s;
            elipseArray[39] = ellipse_t;
            elipseArray[40] = ellipse_u;
            elipseArray[41] = ellipse_v;
            elipseArray[42] = ellipse_w;
            elipseArray[43] = ellipse_x;
            elipseArray[44] = ellipse_y;
            elipseArray[45] = ellipse_z;
            elipseArray[46] = ellipse_A;
            elipseArray[47] = ellipse_B;
            elipseArray[48] = ellipse_C;
            elipseArray[49] = ellipse_D;
            elipseArray[50] = ellipse_E;
            elipseArray[51] = ellipse_F;
            elipseArray[52] = ellipse_G;
            elipseArray[53] = ellipse_H;
            elipseArray[54] = ellipse_I;
            elipseArray[55] = ellipse_J;
            elipseArray[56] = ellipse_K;
            elipseArray[57] = ellipse_L;
            elipseArray[58] = ellipse_M;
            elipseArray[59] = ellipse_N;
            elipseArray[60] = ellipse_O;
            elipseArray[61] = ellipse_P;
            elipseArray[62] = ellipse_Q;
            elipseArray[63] = ellipse_R;
            elipseArray[64] = ellipse_S;
            elipseArray[65] = ellipse_T;
            elipseArray[66] = ellipse_U;
            elipseArray[67] = ellipse_V;
            elipseArray[68] = ellipse_W;
            elipseArray[69] = ellipse_X;
            elipseArray[70] = ellipse_Y;
            elipseArray[71] = ellipse_Z;
            elipseArray[72] = ellipse_minus;
            elipseArray[73] = ellipse_underScore;
            elipseArray[74] = ellipse_equals;
            elipseArray[75] = ellipse_plus;
            elipseArray[76] = ellipse_openBracket;
            elipseArray[77] = ellipse_closeBracket;
            elipseArray[78] = ellipse_openSquareBracket;
            elipseArray[79] = ellipse_closeSquareBracket;
            elipseArray[80] = ellipse_openWavyBracket;
            elipseArray[81] = ellipse_closeWavyBracket;
            elipseArray[82] = ellipse_line;
            elipseArray[83] = ellipse_backSlash;
            elipseArray[84] = ellipse_dualDot;
            elipseArray[85] = ellipse_semiComma;
            elipseArray[86] = ellipse_quote;
            elipseArray[87] = ellipse_apostrophe;
            elipseArray[88] = ellipse_comma;
            elipseArray[89] = ellipse_leftArrow;
            elipseArray[90] = ellipse_period;
            elipseArray[91] = ellipse_rightArrow;
            elipseArray[92] = ellipse_forwardSlash;
            elipseArray[93] = ellipse_questionMark;
            elipseArray[94] = ellipse_spaceBar;
            #endregion

            #region LIGHTBOARD
            labelArray_LightBoard[0] = label_lm_1;
            labelArray_LightBoard[1] = label_lm_2;
            labelArray_LightBoard[2] = label_lm_3;
            labelArray_LightBoard[3] = label_lm_4;
            labelArray_LightBoard[4] = label_lm_5;
            labelArray_LightBoard[5] = label_lm_6;
            labelArray_LightBoard[6] = label_lm_7;
            labelArray_LightBoard[7] = label_lm_8;
            labelArray_LightBoard[8] = label_lm_9;
            labelArray_LightBoard[9] = label_lm_0;
            labelArray_LightBoard[10] = label_lm_exclamation;
            labelArray_LightBoard[11] = label_lm_atSymbol;
            labelArray_LightBoard[12] = label_lm_hastag;
            labelArray_LightBoard[13] = label_lm_dollar;
            labelArray_LightBoard[14] = label_lm_percent;
            labelArray_LightBoard[15] = label_lm_exponent;
            labelArray_LightBoard[16] = label_lm_and;
            labelArray_LightBoard[17] = label_lm_asterisk;
            labelArray_LightBoard[18] = label_lm_openParenthesis;
            labelArray_LightBoard[19] = label_lm_closeParenthesis;
            labelArray_LightBoard[20] = label_lm_a;
            labelArray_LightBoard[21] = label_lm_b;
            labelArray_LightBoard[22] = label_lm_c;
            labelArray_LightBoard[23] = label_lm_d;
            labelArray_LightBoard[24] = label_lm_e;
            labelArray_LightBoard[25] = label_lm_f;
            labelArray_LightBoard[26] = label_lm_g;
            labelArray_LightBoard[27] = label_lm_h;
            labelArray_LightBoard[28] = label_lm_i;
            labelArray_LightBoard[29] = label_lm_j;
            labelArray_LightBoard[30] = label_lm_k;
            labelArray_LightBoard[31] = label_lm_l;
            labelArray_LightBoard[32] = label_lm_m;
            labelArray_LightBoard[33] = label_lm_n;
            labelArray_LightBoard[34] = label_lm_o;
            labelArray_LightBoard[35] = label_lm_p;
            labelArray_LightBoard[36] = label_lm_q;
            labelArray_LightBoard[37] = label_lm_r;
            labelArray_LightBoard[38] = label_lm_s;
            labelArray_LightBoard[39] = label_lm_t;
            labelArray_LightBoard[40] = label_lm_u;
            labelArray_LightBoard[41] = label_lm_v;
            labelArray_LightBoard[42] = label_lm_w;
            labelArray_LightBoard[43] = label_lm_x;
            labelArray_LightBoard[44] = label_lm_y;
            labelArray_LightBoard[45] = label_lm_z;
            labelArray_LightBoard[46] = label_lm_A;
            labelArray_LightBoard[47] = label_lm_B;
            labelArray_LightBoard[48] = label_lm_C;
            labelArray_LightBoard[49] = label_lm_D;
            labelArray_LightBoard[50] = label_lm_E;
            labelArray_LightBoard[51] = label_lm_F;
            labelArray_LightBoard[52] = label_lm_G;
            labelArray_LightBoard[53] = label_lm_H;
            labelArray_LightBoard[54] = label_lm_I;
            labelArray_LightBoard[55] = label_lm_J;
            labelArray_LightBoard[56] = label_lm_K;
            labelArray_LightBoard[57] = label_lm_L;
            labelArray_LightBoard[58] = label_lm_M;
            labelArray_LightBoard[59] = label_lm_N;
            labelArray_LightBoard[60] = label_lm_O;
            labelArray_LightBoard[61] = label_lm_P;
            labelArray_LightBoard[62] = label_lm_Q;
            labelArray_LightBoard[63] = label_lm_R;
            labelArray_LightBoard[64] = label_lm_S;
            labelArray_LightBoard[65] = label_lm_T;
            labelArray_LightBoard[66] = label_lm_U;
            labelArray_LightBoard[67] = label_lm_V;
            labelArray_LightBoard[68] = label_lm_W;
            labelArray_LightBoard[69] = label_lm_X;
            labelArray_LightBoard[70] = label_lm_Y;
            labelArray_LightBoard[71] = label_lm_Z;
            labelArray_LightBoard[72] = label_lm_minus;
            labelArray_LightBoard[73] = label_lm_underScore;
            labelArray_LightBoard[74] = label_lm_equals;
            labelArray_LightBoard[75] = label_lm_plus;
            labelArray_LightBoard[76] = label_lm_openBracket;
            labelArray_LightBoard[77] = label_lm_closeBracket;
            labelArray_LightBoard[78] = label_lm_openSquareBracket;
            labelArray_LightBoard[79] = label_lm_closeSquareBracket;
            labelArray_LightBoard[80] = label_lm_openWavyBracket;
            labelArray_LightBoard[81] = label_lm_closeWavyBracket;
            labelArray_LightBoard[82] = label_lm_line;
            labelArray_LightBoard[83] = label_lm_backSlash;
            labelArray_LightBoard[84] = label_lm_dualDot;
            labelArray_LightBoard[85] = label_lm_semiComma;
            labelArray_LightBoard[86] = label_lm_quote;
            labelArray_LightBoard[87] = label_lm_apostrophe;
            labelArray_LightBoard[88] = label_lm_comma;
            labelArray_LightBoard[89] = label_lm_leftArrow;
            labelArray_LightBoard[90] = label_lm_period;
            labelArray_LightBoard[91] = label_lm_rightArrow;
            labelArray_LightBoard[92] = label_lm_forwardSlash;
            labelArray_LightBoard[93] = label_lm_questionMark;
            labelArray_LightBoard[94] = label_lm_spaceBar;
            #endregion

        }
        private void generateRectangles()
        {
            int numberArrays = 0;
            //First Row Numbers
            for (int i = 0; i < 10; i++)
            {
                double widthMeme = 50;
                if (numberArrays == 12)
                {
                    widthMeme = 100;
                }
                rectanglesArray[numberArrays].Width = widthMeme;
                rectanglesArray[numberArrays].Height = 50;
                rectanglesArray[numberArrays].VerticalAlignment = VerticalAlignment.Top;
                rectanglesArray[numberArrays].HorizontalAlignment = HorizontalAlignment.Left;
                rectanglesArray[numberArrays].Stroke = Brushes.Black;
                rectanglesArray[numberArrays].Name = "rectangle_" + numbers[i];
                rectanglesArray[numberArrays].Margin = new Thickness(100 + (i * 55), 400, 0, 0);
                keyBoard.Children.Add(rectanglesArray[numberArrays]);

                labelArray_keyboard[numberArrays].Width = widthMeme;
                labelArray_keyboard[numberArrays].Height = 50;
                labelArray_keyboard[numberArrays].VerticalAlignment = VerticalAlignment.Top;
                labelArray_keyboard[numberArrays].HorizontalAlignment = HorizontalAlignment.Left;
                labelArray_keyboard[numberArrays].Content = numbers[i];
                labelArray_keyboard[numberArrays].Name = labelArray_keyboard[numberArrays].Name.ToString();
                labelArray_keyboard[numberArrays].Margin = new Thickness(100 + (i * 55), 400, 0, 0);
                keyBoard.Children.Add(labelArray_keyboard[numberArrays]);
                numberArrays++;
            }
            // 2nd Row letters
            for (int i = 0; i < 26; i++)
            {
                if (i == 13)
                {
                    nextRow = 0;
                    nextColumn = 55;
                }

                rectanglesArray[numberArrays].Width = 50;
                rectanglesArray[numberArrays].Height = 50;
                rectanglesArray[numberArrays].VerticalAlignment = VerticalAlignment.Top;
                rectanglesArray[numberArrays].HorizontalAlignment = HorizontalAlignment.Left;
                rectanglesArray[numberArrays].Stroke = Brushes.Black;
                rectanglesArray[numberArrays].Name = "rectangle_" + numberArrays;
                rectanglesArray[numberArrays].Margin = new Thickness(100 + (nextRow * 55), 455 + nextColumn, 0, 0);
                keyBoard.Children.Add(rectanglesArray[numberArrays]);

                labelArray_keyboard[numberArrays].Width = 50;
                labelArray_keyboard[numberArrays].Height = 50;
                labelArray_keyboard[numberArrays].VerticalAlignment = VerticalAlignment.Top;
                labelArray_keyboard[numberArrays].HorizontalAlignment = HorizontalAlignment.Left;
                labelArray_keyboard[numberArrays].Content = lowerLetters[i];
                labelArray_keyboard[numberArrays].Name = labelArray_keyboard[numberArrays].Name.ToString();
                labelArray_keyboard[numberArrays].Margin = new Thickness(100 + (nextRow * 55), 455 + nextColumn, 0, 0);
                keyBoard.Children.Add(labelArray_keyboard[numberArrays]);
                numberArrays++;
                nextRow++;
            }
            // 3rd Row Symbols
            for (int i = 0; i < 10; i++)
            {
                rectanglesArray[numberArrays].Width = 50;
                rectanglesArray[numberArrays].Height = 50;
                rectanglesArray[numberArrays].VerticalAlignment = VerticalAlignment.Top;
                rectanglesArray[numberArrays].HorizontalAlignment = HorizontalAlignment.Left;
                rectanglesArray[numberArrays].Stroke = Brushes.Black;
                rectanglesArray[numberArrays].Name = "rectangle_" + numberArrays;
                rectanglesArray[numberArrays].Margin = new Thickness(100 + (i * 55), 565, 0, 0);
                keyBoard.Children.Add(rectanglesArray[numberArrays]);

                labelArray_keyboard[numberArrays].Width = 50;
                labelArray_keyboard[numberArrays].Height = 50;
                labelArray_keyboard[numberArrays].VerticalAlignment = VerticalAlignment.Top;
                labelArray_keyboard[numberArrays].HorizontalAlignment = HorizontalAlignment.Left;
                labelArray_keyboard[numberArrays].Content = unshift_symbols[i];
                labelArray_keyboard[numberArrays].Name = labelArray_keyboard[numberArrays].Name.ToString();
                labelArray_keyboard[numberArrays].Margin = new Thickness(100 + (i * 55), 565, 0, 0);
                keyBoard.Children.Add(labelArray_keyboard[numberArrays]);
                numberArrays++;
            }
            //4th Row
            for (int i = 0; i < 6; i++)
            {

                rectanglesArray[numberArrays].Width = 80;
                rectanglesArray[numberArrays].Height = 58;
                rectanglesArray[numberArrays].VerticalAlignment = VerticalAlignment.Top;
                rectanglesArray[numberArrays].HorizontalAlignment = HorizontalAlignment.Left;
                rectanglesArray[numberArrays].Stroke = Brushes.Black;
                rectanglesArray[numberArrays].Name = "rectangle_" + numberArrays;
                rectanglesArray[numberArrays].Margin = new Thickness(100 + (i * 85), 620, 0, 0);
                keyBoard.Children.Add(rectanglesArray[numberArrays]);

                labelArray_keyboard[numberArrays].Width = 80;
                labelArray_keyboard[numberArrays].Height = 50;
                labelArray_keyboard[numberArrays].VerticalAlignment = VerticalAlignment.Top;
                labelArray_keyboard[numberArrays].HorizontalAlignment = HorizontalAlignment.Left;
                labelArray_keyboard[numberArrays].Content = commandButtons[i];
                labelArray_keyboard[numberArrays].Name = labelArray_keyboard[numberArrays].Name.ToString();
                labelArray_keyboard[numberArrays].Margin = new Thickness(100 + (i * 85), 620, 0, 0);
                keyBoard.Children.Add(labelArray_keyboard[numberArrays]);
                numberArrays++;
            }
        }
        private void generateElipses()
        {
            double widthMeme = 50;
            double heightMeme = 50;
            int numberArrays = 0;
            int rownumber = 0;
            int stopRow = 0;
            //First Row Numbers
            for (int a = 0; a < 10; a++)
            {
                if (a == 9)
                {
                    stopRow = 7;
                }
                for (int i = 0; i < 10 - stopRow; i++)
                {
                    elipseArray[numberArrays].Width = widthMeme;
                    elipseArray[numberArrays].Height = heightMeme;
                    elipseArray[numberArrays].VerticalAlignment = VerticalAlignment.Top;
                    elipseArray[numberArrays].HorizontalAlignment = HorizontalAlignment.Left;
                    elipseArray[numberArrays].Stroke = Brushes.Black;
                    elipseArray[numberArrays].Name = "ellipse" + numbers[i];
                    elipseArray[numberArrays].Margin = new Thickness(850 + (i * 55), 50 + (rownumber * 55), 0, 0);
                    keyBoard.Children.Add(elipseArray[numberArrays]);

                    labelArray_LightBoard[numberArrays].Width = widthMeme;
                    labelArray_LightBoard[numberArrays].Height = heightMeme;
                    labelArray_LightBoard[numberArrays].VerticalAlignment = VerticalAlignment.Top;
                    labelArray_LightBoard[numberArrays].HorizontalAlignment = HorizontalAlignment.Left;
                    labelArray_LightBoard[numberArrays].VerticalContentAlignment = VerticalAlignment.Center;
                    labelArray_LightBoard[numberArrays].HorizontalContentAlignment = HorizontalAlignment.Center;
                    labelArray_LightBoard[numberArrays].Content = lightModules[numberArrays];
                    labelArray_LightBoard[numberArrays].Name = labelArray_LightBoard[numberArrays].Name.ToString();
                    labelArray_LightBoard[numberArrays].Margin = new Thickness(850 + (i * 55), 50 + (rownumber * 55), 0, 0);
                    keyBoard.Children.Add(labelArray_LightBoard[numberArrays]);
                    numberArrays++;
                }
                rownumber++;
            }

        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.FocusedElement is TextBox || keyboardToggle == false)
            {
                return;
            }
            lightButton(e.Key);
            switch (e.Key)
            {
                case Key.Capital:
                    shiftLock = !shiftLock;
                    if (shiftLock == true)
                    {
                        rectanglesArray[50].Fill = Brushes.IndianRed;
                        upperCaps();
                    }
                    else
                    {
                        rectanglesArray[50].Fill = Brushes.Transparent;
                        lowerCaps();
                    }
                    break;
                case Key.LeftShift:
                    shiftDown = !shiftDown;
                    if (shiftDown)
                    {
                        upperCaps();
                    }
                    else
                    {
                        lowerCaps();
                    }
                    break;
                case Key.Back:
                    backSpace();
                    if (activateRotor == true)
                    {
                        rotateRotorBackwards();
                    }
                    break;
                default:
                    char keyChar = keyManager(e.Key);
                    if (shiftDown)
                    {
                        lowerCaps();
                    }
                    if (control.Contains(keyChar))
                    {

                        currentEncrypted += Encrypt(keyChar);
                        currentSentence += keyChar;
                        if (activateRotor == true)
                        {
                            rotateRotorForward();
                        }
                    }
                    break;
            }
            label_encrypted.Text = currentEncrypted;
            label_unecrypted.Text = currentSentence;

        }
        private void lightButton(Key e)
        {
            int index = 0;
            foreach (var rectangle in rectanglesArray)
            {
                if (rectangle.Name != "rectangle_50")
                {
                    rectangle.Fill = Brushes.Transparent;
                }
            }
            switch (e)
            {

                case Key.D0:
                    index = 9;
                    break;
                case Key.D1:
                    index = 0;
                    break;
                case Key.D2:
                    index = 1;
                    break;
                case Key.D3:
                    index = 2;
                    break;
                case Key.D4:
                    index = 3;
                    break;
                case Key.D5:
                    index = 4;
                    break;
                case Key.D6:
                    index = 5;
                    break;
                case Key.D7:
                    index = 6;
                    break;
                case Key.D8:
                    index = 7;
                    break;
                case Key.D9:
                    index = 8;
                    break;
                case Key.A:
                    index = 10;
                    break;
                case Key.B:
                    index = 11;
                    break;
                case Key.C:
                    index = 12;
                    break;
                case Key.D:
                    index = 13;
                    break;
                case Key.E:
                    index = 14;
                    break;
                case Key.F:
                    index = 15;
                    break;
                case Key.G:
                    index = 16;
                    break;
                case Key.H:
                    index = 17;
                    break;
                case Key.I:
                    index = 18;
                    break;
                case Key.J:
                    index = 19;
                    break;
                case Key.K:
                    index = 20;
                    break;
                case Key.L:
                    index = 21;
                    break;
                case Key.M:
                    index = 22;
                    break;
                case Key.N:
                    index = 23;
                    break;
                case Key.O:
                    index = 24;
                    break;
                case Key.P:
                    index = 25;
                    break;
                case Key.Q:
                    index = 26;
                    break;
                case Key.R:
                    index = 27;
                    break;
                case Key.S:
                    index = 28;
                    break;
                case Key.T:
                    index = 29;
                    break;
                case Key.U:
                    index = 30;
                    break;
                case Key.V:
                    index = 31;
                    break;
                case Key.W:
                    index = 32;
                    break;
                case Key.X:
                    index = 33;
                    break;
                case Key.Y:
                    index = 34;
                    break;
                case Key.Z:
                    index = 35;
                    break;
                case Key.Back:
                    index = 49;
                    break;
                case Key.Enter:
                    index = 48;
                    break;
                case Key.LeftShift:
                    index = 47;
                    break;
                case Key.Tab:
                    index = 46;
                    break;
                case Key.OemMinus:
                    index = 36;
                    break;
                case Key.OemPlus:
                    index = 37;
                    break;
                case Key.OemOpenBrackets:
                    index = 38;
                    break;
                case Key.Oem6:
                    index = 39;
                    break;
                case Key.Oem5: // Backslash
                    index = 40;
                    break;
                case Key.Oem1:
                    index = 41;
                    break;
                case Key.OemQuotes: // Apostrophe
                    index = 42;
                    break;
                case Key.OemComma:
                    index = 43;
                    break;
                case Key.OemPeriod:
                    index = 44;
                    break;
                case Key.Space:
                    index = 51;
                    break;
                case Key.Capital:
                    index = 51;
                    break;
                default:
                    break;
            }
            if (index >= 0 && index < rectanglesArray.Length)
            {
                rectanglesArray[index].Fill = Brushes.Yellow;
            }
        }
        private void lightPanel(char nonMirrored, char Mirrored)
        {
            foreach (Ellipse lightButton in elipseArray)
            {
                lightButton.Fill = Brushes.Transparent;
            }
            int indexNon = lightModules.IndexOf(nonMirrored);
            int indexMirrored = lightModules.IndexOf(Mirrored);

            if (indexNon >= 0 && indexNon < elipseArray.Length)
            {
                elipseArray[indexNon].Fill = Brushes.LightBlue;
                elipseArray[indexMirrored].Fill = Brushes.LightPink;
            }
        }
        private char keyManager(Key key)
        {
            char returnKey = '\b';
            string keyString = key.ToString();
            switch (key.ToString())
            {
                case "Tab":
                    returnKey = '\t';
                    break;
                case "Space":
                    returnKey = ' ';
                    break;
                case "Return":
                    returnKey = '\n';
                    break;
                case "Back":
                    backSpace();
                    break;
                case "D0":
                    returnKey = (char)labelArray_keyboard[9].Content;
                    break;
                case "D1":
                    returnKey = (char)labelArray_keyboard[0].Content;
                    break;
                case "D2":
                    returnKey = (char)labelArray_keyboard[1].Content;
                    break;
                case "D3":
                    returnKey = (char)labelArray_keyboard[2].Content;
                    break;
                case "D4":
                    returnKey = (char)labelArray_keyboard[3].Content;
                    break;
                case "D5":
                    returnKey = (char)labelArray_keyboard[4].Content;
                    break;
                case "D6":
                    returnKey = (char)labelArray_keyboard[5].Content;
                    break;
                case "D7":
                    returnKey = (char)labelArray_keyboard[6].Content;
                    break;
                case "D8":
                    returnKey = (char)labelArray_keyboard[7].Content;
                    break;
                case "D9":
                    returnKey = (char)labelArray_keyboard[8].Content;
                    break;
                case "A":
                    returnKey = (char)labelArray_keyboard[10].Content;
                    break;
                case "B":
                    returnKey = (char)labelArray_keyboard[11].Content;
                    break;
                case "C":
                    returnKey = (char)labelArray_keyboard[12].Content;
                    break;
                case "D":
                    returnKey = (char)labelArray_keyboard[13].Content;
                    break;
                case "E":
                    returnKey = (char)labelArray_keyboard[14].Content;
                    break;
                case "F":
                    returnKey = (char)labelArray_keyboard[15].Content;
                    break;
                case "G":
                    returnKey = (char)labelArray_keyboard[16].Content;
                    break;
                case "H":
                    returnKey = (char)labelArray_keyboard[17].Content;
                    break;
                case "I":
                    returnKey = (char)labelArray_keyboard[18].Content;
                    break;
                case "J":
                    returnKey = (char)labelArray_keyboard[19].Content;
                    break;
                case "K":
                    returnKey = (char)labelArray_keyboard[20].Content;
                    break;
                case "L":
                    returnKey = (char)labelArray_keyboard[21].Content;
                    break;
                case "M":
                    returnKey = (char)labelArray_keyboard[22].Content;
                    break;
                case "N":
                    returnKey = (char)labelArray_keyboard[23].Content;
                    break;
                case "O":
                    returnKey = (char)labelArray_keyboard[24].Content;
                    break;
                case "P":
                    returnKey = (char)labelArray_keyboard[25].Content;
                    break;
                case "Q":
                    returnKey = (char)labelArray_keyboard[26].Content;
                    break;
                case "R":
                    returnKey = (char)labelArray_keyboard[27].Content;
                    break;
                case "S":
                    returnKey = (char)labelArray_keyboard[28].Content;
                    break;
                case "T":
                    returnKey = (char)labelArray_keyboard[29].Content;
                    break;
                case "U":
                    returnKey = (char)labelArray_keyboard[30].Content;
                    break;
                case "V":
                    returnKey = (char)labelArray_keyboard[31].Content;
                    break;
                case "W":
                    returnKey = (char)labelArray_keyboard[32].Content;
                    break;
                case "X":
                    returnKey = (char)labelArray_keyboard[33].Content;
                    break;
                case "Y":
                    returnKey = (char)labelArray_keyboard[34].Content;
                    break;
                case "Z":
                    returnKey = (char)labelArray_keyboard[35].Content;
                    break;
                case "OemMinus":
                    returnKey = (char)labelArray_keyboard[36].Content;
                    break;
                case "OemPlus":
                    returnKey = (char)labelArray_keyboard[37].Content;
                    break;
                case "OemOpenBrackets":
                    returnKey = (char)labelArray_keyboard[38].Content;
                    break;
                case "Oem6":
                    returnKey = (char)labelArray_keyboard[39].Content;
                    break;
                case "Oem5": // Backslash
                    returnKey = (char)labelArray_keyboard[40].Content;
                    break;
                case "Oem1":
                    returnKey = (char)labelArray_keyboard[41].Content;
                    break;
                case "OemQuotes": // Apostrophe
                    returnKey = (char)labelArray_keyboard[42].Content;
                    break;
                case "OemComma":
                    returnKey = (char)labelArray_keyboard[43].Content;
                    break;
                case "OemPeriod":
                    returnKey = (char)labelArray_keyboard[44].Content;
                    break;
                case "OemQuestion": // Slash
                    returnKey = (char)labelArray_keyboard[45].Content;
                    break;
                default:
                    break;
            }
            return returnKey;
        }
        private void lowerCaps()
        {
            int count = 0;
            for (int i = 10; i < 36; i++)
            {
                labelArray_keyboard[i].Content = lowerLetters[count];
                count++;
            }
            count = 0;
            for (int i = 0; i < 10; i++)
            {
                labelArray_keyboard[i].Content = numbers[count];
                count++;
            }
            count = 0;
            for (int i = 36; i < 46; i++)
            {
                labelArray_keyboard[i].Content = unshift_symbols[count];
                count++;
            }


        }
        private void backSpace()
        {
            List<char> currentSentenceList = currentSentence.ToCharArray().ToList();
            if (currentSentenceList.Count > 0)
            {
                currentSentenceList.RemoveAt(currentSentenceList.Count - 1);
                currentSentence = new string(currentSentenceList.ToArray());
                label_unecrypted.Text = currentSentence;
            }

            List<char> currentEncryptList = currentEncrypted.ToCharArray().ToList();
            if (currentEncryptList.Count > 0)
            {
                currentEncryptList.RemoveAt(currentEncryptList.Count - 1);
                currentEncrypted = new string(currentEncryptList.ToArray());
                label_encrypted.Text = currentEncrypted;
            }
            List<char> currentMirrorList = currentMirror.ToCharArray().ToList();
            if (currentMirrorList.Count > 0)
            {
                currentMirrorList.RemoveAt(currentMirrorList.Count - 1);
                currentMirror = new string(currentMirrorList.ToArray());
                label_mirror.Text = currentMirror;
            }

        }
        private void upperCaps()
        {
            int count = 0;
            for (int i = 10; i < 36; i++)
            {
                labelArray_keyboard[i].Content = upperLetters[count];
                count++;
            }
            count = 0;
            for (int i = 0; i < 10; i++)
            {
                labelArray_keyboard[i].Content = shift_numbers[count];
                count++;
            }
            count = 0;
            for (int i = 36; i < 46; i++)
            {
                labelArray_keyboard[i].Content = shift_symbols[count];
                count++;
            }

        }

        //Mostly Enigma Logic
        private void getEncryptionData()
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
        private void rotateRotorBackwards()
        {
            if (ringSettings[2] != rotorIncrements[2] || ringSettings[1] != rotorIncrements[1])
            {
                if (ringSettings[1] != rotorIncrements[1] && rotorIncrements[2] == 0)
                {
                    if (ringSettings[0] != rotorIncrements[0] && rotorIncrements[1] == 0)
                    {
                        rotorIncrements[1] = control.Length;
                        rotorIncrements[0]--;
                        char lastChar1 = rotors[0][rotors[0].Length - 1];
                        rotors[0] = lastChar1 + rotors[0].Remove(rotors[0].Length - 1);
                        label_rotor1.Content = GenerateRotorCopy(rotors[0]);
                    }
                    rotorIncrements[2] = control.Length;
                    rotorIncrements[1]--;
                    char lastChar2 = rotors[1][rotors[1].Length - 1];
                    rotors[1] = lastChar2 + rotors[1].Remove(rotors[1].Length - 1);
                    label_rotor2.Content = GenerateRotorCopy(rotors[1]);
                }
                rotorIncrements[2]--;
                char lastChar3 = rotors[2][rotors[2].Length - 1];
                rotors[2] = lastChar3 + rotors[2].Remove(rotors[2].Length - 1);
                label_rotor3.Content = GenerateRotorCopy(rotors[2]);
            }

            //if (rotors[2] != rotor_3_default && rotorIncrements[2] > 0 || rotorRotation[2] > 0)
            //{
            //    if (rotorIncrements[1] > 0 && rotorIncrements[2] <= 0)
            //    {
            //        rotorIncrements[2] = 26;
            //        rotorRotation[2]--;
            //        string copyRotor2 = "";
            //        char lastChar_2 = rotor_2[rotor_2.Length - 1];
            //        rotor_2 = lastChar_2 + rotor_2.Remove(rotor_2.Length - 1);
            //        copyRotor2 = GenerateRotorCopy(rotor_2);
            //        label_rotor2.Content = copyRotor2;
            //        rotorIncrements[1]--;
            //    }
            //    string copyRotor3 = "";
            //    char lastChar = rotor_3[rotor_3.Length - 1];
            //    rotor_3 = lastChar + rotor_3.Remove(rotor_3.Length - 1);
            //    copyRotor3 = GenerateRotorCopy(rotor_3);
            //    label_rotor3.Content = copyRotor3;
            //    rotorIncrements[2]--;
            //}
            textbox_ring3.Text = rotorIncrements[2].ToString();
            textbox_ring1.Text = rotorIncrements[0].ToString();
            textbox_ring2.Text = rotorIncrements[1].ToString();

        }
        private void rotateRotorForward()
        {
            string copyRotor3 = "";
            string copyRotor2 = "";
            string copyRotor1 = "";
            char firstChar = rotors[2][0];
            rotors[2] = rotors[2].Remove(0, 1);
            rotors[2] += firstChar;
            copyRotor3 = GenerateRotorCopy(rotors[2]);
            label_rotor3.Content = copyRotor3;
            rotorIncrements[2]++;

            if (rotorIncrements[2] == rotors[2].Length)
            {
                rotorIncrements[2] = 0;
                char firstCharRotor2 = rotors[1][0];
                rotors[1] = rotors[1].Remove(0, 1);
                rotors[1] += firstCharRotor2;
                copyRotor2 = GenerateRotorCopy(rotors[1]);
                textbox_ring2.Text = rotorIncrements[1].ToString();
                label_rotor2.Content = copyRotor2;
                rotorIncrements[1]++;
            }

            if (rotorIncrements[1] == rotors[1].Length)
            {
                rotorIncrements[1] = 0;
                char firstCharRotor1 = rotors[0][0];
                rotors[0] = rotors[0].Remove(0, 1);
                rotors[0] += firstCharRotor1;
                copyRotor1 = GenerateRotorCopy(rotors[0]);
                rotorIncrements[0]++;
                textbox_ring1.Text = rotorIncrements[0].ToString();
                label_rotor1.Content = copyRotor1;
            }

            textbox_ring3.Text = rotorIncrements[2].ToString();
            textbox_ring2.Text = rotorIncrements[1].ToString();
            textbox_ring1.Text = rotorIncrements[0].ToString();
        }
        private string GenerateRotorCopy(string rotor)
        {
            string copyRotor = "";
            foreach (char c in rotor)
            {
                copyRotor += c.ToString() + '\t';
            }
            return copyRotor;
        }
        private char Encrypt(char letter)
        {
            int controlIndex = control.IndexOf(letter);
            char encryptedLetter = rotors[0][controlIndex];

            controlIndex = control.IndexOf(encryptedLetter);
            encryptedLetter = rotors[1][controlIndex];

            controlIndex = control.IndexOf(encryptedLetter);
            encryptedLetter = rotors[2][controlIndex];

            mirrowEncrypt(encryptedLetter);
            return encryptedLetter;
        }
        private void mirrowEncrypt(char letter)
        {
            int controlIndex = control.IndexOf(letter);
            char encryptedLetter = rotors[2][controlIndex];

            controlIndex = control.IndexOf(encryptedLetter);
            encryptedLetter = rotors[1][controlIndex];

            controlIndex = control.IndexOf(encryptedLetter);
            encryptedLetter = rotors[0][controlIndex];
            currentMirror += encryptedLetter;
            lightPanel(letter, encryptedLetter);
            label_mirror.Text = currentMirror;
        }
        private void setDefaultEnigma()
        {
            rotors[0] = originalRotor_1.ToString(); rotors[1] = originalRotor_2.ToString(); rotors[2] = originalRotor_3.ToString();
            rotorLabels[0] = label_rotor1; rotorLabels[1] = label_rotor2; rotorLabels[2] = label_rotor3;
            foreach (char a in control)
            {
                label_control.Content += a + "\t";
            }
            foreach (char a in rotors[0])
            {
                label_rotor1.Content += a + "\t";
            }
            foreach (char a in rotors[1])
            {
                label_rotor2.Content += a + "\t";
            }
            foreach (char a in rotors[2])
            {
                label_rotor3.Content += a + "\t";
            }
        }
        private void setSettings()
        {
            for (int c = 0; c < 3; c++)
            {
                string copyRotor3 = "";
                int number = ringSettings[c];
                for (int b = 0; b < number; b++)
                {
                    char firstChar = rotors[c][0];
                    rotors[c] = rotors[c].Remove(0, 1);
                    rotors[c] += firstChar;
                    rotorIncrements[c]++;
                }

                foreach (char singleLetter in rotors[c])
                {
                    copyRotor3 += singleLetter.ToString() + '\t';
                }
                rotorLabels[c].Content = copyRotor3;
            }

        }
        private void button_activateRotor_Click(object sender, RoutedEventArgs e)
        {
            int ringValue;
            bool isRotorActive = false;
            string[] textboxValues = { textbox_ring1.Text, textbox_ring2.Text, textbox_ring3.Text };

            for (int i = 0; i < 3; i++)
            {
                if (int.TryParse(textboxValues[i].ToString(), out ringValue))
                {
                    if (ringValue >= 0 && ringValue <= control.Length)
                    {
                        ringSettings[i] = ringValue;
                        isRotorActive = true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid settings: Range out of bounds");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid settings: Non-Integer Inputted");
                    return;
                }
            }

            if (isRotorActive)
            {
                activateRotor = !activateRotor;
                button_activateRotor.Content = "Rotor Active";
                button_activateRotor.IsEnabled = false;
                setSettings();
            }
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int choice = 0;
            string sliderName = "";
            if (sender is Slider slider)
            {
                sliderName = slider.Name;
            }
            switch (sliderName)
            {
                case "slider_keyboardToggle":
                    choice = (int)slider_keyboardToggle.Value;
                    switch (choice)
                    {
                        case 0:
                            keyboardToggle = false;
                            elipse_keyboardON.Fill = Brushes.LightPink;
                            break;
                        case 1:
                            keyboardToggle = true;
                            elipse_keyboardON.Fill = Brushes.LightGreen;
                            break;
                    }
                    break;
                case "slider_uncryptedToggle":
                    choice = (int)slider_uncryptedToggle.Value;
                    switch (choice)
                    {
                        case 0:
                            label_unecrypted.Opacity = 0;
                            elipse_unecryptToggle.Fill = Brushes.LightPink;
                            break;
                        case 1:
                            label_unecrypted.Opacity = 1;
                            elipse_unecryptToggle.Fill = Brushes.LightGreen;
                            break;
                    }
                    break;
                case "slider_rotors":
                    choice = (int)slider_rotors.Value;
                    switch (choice)
                    {
                        case 0:
                            rectangle_cover.Fill = Brushes.White;
                            elipse_rotor.Fill = Brushes.LightPink;
                            break;
                        case 1:
                            rectangle_cover.Fill = Brushes.Transparent;
                            elipse_rotor.Fill = Brushes.LightGreen;
                            break;
                    }
                    break;
                case "slider_mirrored":
                    choice = (int)slider_mirrored.Value;
                    switch (choice)
                    {
                        case 0:
                            label_mirror.Opacity = 0; ;
                            elipse_mirroredToggle.Fill = Brushes.LightPink;
                            break;
                        case 1:
                            label_mirror.Opacity = 1; ;
                            elipse_mirroredToggle.Fill = Brushes.LightGreen;
                            break;
                    }
                    break;
            }

        }
    }
}