/**
    Copyright(c) Microsoft Open Technologies, Inc.All rights reserved.
    Modified by Michael Osthege (2016)
   The MIT License(MIT)
    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files(the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions :
    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
**/

using System;
using Windows.System;

namespace TCD.Controls.Keyboard
{
    public class KeyAssignmentSet
    {
        #region Keys
        public virtual KeyModel KeyVK_Oem3 { get; set; }
        public virtual KeyModel KeyVK_1 { get; set; }
        public virtual KeyModel KeyVK_2 { get; set; }
        public virtual KeyModel KeyVK_3 { get; set; }
        public virtual KeyModel KeyVK_4 { get; set; }
        public virtual KeyModel KeyVK_5 { get; set; }
        public virtual KeyModel KeyVK_6 { get; set; }
        public virtual KeyModel KeyVK_7 { get; set; }
        public virtual KeyModel KeyVK_8 { get; set; }
        public virtual KeyModel KeyVK_9 { get; set; }
        public virtual KeyModel KeyVK_0 { get; set; }
        public virtual KeyModel KeyVK_OemMinus { get; set; }
        public virtual KeyModel KeyVK_OemPlus { get; set; }
        public virtual KeyModel KeyVK_Q { get; set; }
        public virtual KeyModel KeyVK_W { get; set; }
        public virtual KeyModel KeyVK_E { get; set; }
        public virtual KeyModel KeyVK_R { get; set; }
        public virtual KeyModel KeyVK_T { get; set; }
        public virtual KeyModel KeyVK_Y { get; set; }
        public virtual KeyModel KeyVK_U { get; set; }
        public virtual KeyModel KeyVK_I { get; set; }
        public virtual KeyModel KeyVK_O { get; set; }
        public virtual KeyModel KeyVK_P { get; set; }
        public virtual KeyModel KeyVK_OemOpenBrackets { get; set; }
        public virtual KeyModel KeyVK_Oem6 { get; set; }
        public virtual KeyModel KeyVK_Oem5 { get; set; }
        public virtual KeyModel KeyVK_A { get; set; }
        public virtual KeyModel KeyVK_S { get; set; }
        public virtual KeyModel KeyVK_D { get; set; }
        public virtual KeyModel KeyVK_F { get; set; }
        public virtual KeyModel KeyVK_G { get; set; }
        public virtual KeyModel KeyVK_H { get; set; }
        public virtual KeyModel KeyVK_J { get; set; }
        public virtual KeyModel KeyVK_K { get; set; }
        public virtual KeyModel KeyVK_L { get; set; }
        public virtual KeyModel KeyVK_Oem1 { get; set; }
        public virtual KeyModel KeyVK_Oem7 { get; set; }
        public virtual KeyModel KeyVK_Z { get; set; }
        public virtual KeyModel KeyVK_X { get; set; }
        public virtual KeyModel KeyVK_C { get; set; }
        public virtual KeyModel KeyVK_V { get; set; }
        public virtual KeyModel KeyVK_B { get; set; }
        public virtual KeyModel KeyVK_N { get; set; }
        public virtual KeyModel KeyVK_M { get; set; }
        public virtual KeyModel KeyVK_OemComma { get; set; }
        public virtual KeyModel KeyVK_OemPeriod { get; set; }
        public virtual KeyModel KeyVK_OemQuestion { get; set; }

        private KeyModel _TabKEy = new KeyModel('\t', '\t');
        public KeyModel TabKey
        {
            get { return _TabKEy; }
            set { _TabKEy = value; }
        }

        private KeyModel _EnterKey = new KeyModel('\n', '\n');
        public KeyModel EnterKey
        {
            get { return _EnterKey; }
            set { _EnterKey = value; }
        }

        private ShiftKeyViewModel _ShiftKey = new ShiftKeyViewModel();
        public ShiftKeyViewModel ShiftKey
        {
            get { return _ShiftKey; }
        }
        #endregion

        private KeyModel[] _AllKeys;
        /// <summary>
        /// Get the array of all the KeyAssignment objects within this set, in the same order and number as the key-button array within the virtual keyboard.
        /// </summary>
        public KeyModel[] KeyAssignments
        {
            get
            {
                if (_AllKeys == null)
                {
                    _AllKeys = new KeyModel[] {
                        KeyVK_Oem3, KeyVK_1, KeyVK_2, KeyVK_3, KeyVK_4, KeyVK_5, KeyVK_6, KeyVK_7, KeyVK_8, KeyVK_9, KeyVK_0, KeyVK_OemMinus, KeyVK_OemPlus,
                        KeyVK_Q, KeyVK_W, KeyVK_E, KeyVK_R, KeyVK_T, KeyVK_Y, KeyVK_U, KeyVK_I, KeyVK_O, KeyVK_P, KeyVK_OemOpenBrackets, KeyVK_Oem6, KeyVK_Oem5,
                        KeyVK_A, KeyVK_S, KeyVK_D, KeyVK_F, KeyVK_G, KeyVK_H, KeyVK_J, KeyVK_K, KeyVK_L, KeyVK_Oem1, KeyVK_Oem7,
                        KeyVK_Z, KeyVK_X, KeyVK_C, KeyVK_V, KeyVK_B, KeyVK_N, KeyVK_M, KeyVK_OemComma, KeyVK_OemPeriod, KeyVK_OemQuestion
                    };
                }
                return _AllKeys;
            }
        }

        public KeyAssignmentSet(KeyboardLayouts layout = KeyboardLayouts.English)
        {
            if (layout == KeyboardLayouts.English)
            {
                KeyVK_Oem3 = new KeyModelWithTwoGlyphs('´', '~', false);
                KeyVK_1 = new KeyModelWithTwoGlyphs('1', '!', false);
                KeyVK_2 = new KeyModelWithTwoGlyphs('2', '@', false);
                KeyVK_3 = new KeyModelWithTwoGlyphs('3', '#', false);
                KeyVK_4 = new KeyModelWithTwoGlyphs('4', '$', false);
                KeyVK_5 = new KeyModelWithTwoGlyphs('5', '%', false);
                KeyVK_6 = new KeyModelWithTwoGlyphs('6', '^', false);
                KeyVK_7 = new KeyModelWithTwoGlyphs('7', '&', false);
                KeyVK_8 = new KeyModelWithTwoGlyphs('8', '*', false);
                KeyVK_9 = new KeyModelWithTwoGlyphs('9', '(', false);
                KeyVK_0 = new KeyModelWithTwoGlyphs('0', ')', false);
                KeyVK_OemMinus = new KeyModelWithTwoGlyphs('-', '_', false);
                KeyVK_OemPlus = new KeyModelWithTwoGlyphs('=', '+', false);
                KeyVK_Q = new KeyModel('q', 'Q');
                KeyVK_W = new KeyModel('w', 'W');
                KeyVK_E = new KeyModel('e', 'E');
                KeyVK_R = new KeyModel('r', 'R');
                KeyVK_T = new KeyModel('t', 'T');
                KeyVK_Y = new KeyModel('y', 'Y');
                KeyVK_U = new KeyModel('u', 'U');
                KeyVK_I = new KeyModel('i', 'I');
                KeyVK_O = new KeyModel('o', 'O');
                KeyVK_P = new KeyModel('p', 'P');
                KeyVK_OemOpenBrackets = new KeyModelWithTwoGlyphs('[', '{', false);
                KeyVK_Oem6 = new KeyModelWithTwoGlyphs(']', '}', false);
                KeyVK_Oem5 = new KeyModelWithTwoGlyphs('\\', '|', false);
                KeyVK_A = new KeyModel('a', 'A');
                KeyVK_S = new KeyModel('s', 'S');
                KeyVK_D = new KeyModel('d', 'D');
                KeyVK_F = new KeyModel('f', 'F');
                KeyVK_G = new KeyModel('g', 'G');
                KeyVK_H = new KeyModel('h', 'H');
                KeyVK_J = new KeyModel('j', 'J');
                KeyVK_K = new KeyModel('k', 'K');
                KeyVK_L = new KeyModel('l', 'L');
                KeyVK_Oem1 = new KeyModelWithTwoGlyphs(';', ':', false);
                KeyVK_Oem7 = new KeyModelWithTwoGlyphs('\'', '"', false);
                KeyVK_Z = new KeyModel('z', 'Z');
                KeyVK_X = new KeyModel('x', 'X');
                KeyVK_C = new KeyModel('c', 'C');
                KeyVK_V = new KeyModel('v', 'V');
                KeyVK_B = new KeyModel('b', 'B');
                KeyVK_N = new KeyModel('n', 'N');
                KeyVK_M = new KeyModel('m', 'M');
                KeyVK_OemComma = new KeyModelWithTwoGlyphs(',', '<', false);
                KeyVK_OemPeriod = new KeyModelWithTwoGlyphs('.', '>', false);
                KeyVK_OemQuestion = new KeyModelWithTwoGlyphs('/', '?', false);
            }
            else if (layout == KeyboardLayouts.German)
            {
                KeyVK_Oem3 = new KeyModelWithTwoGlyphs('@', '^', false);
                KeyVK_1 = new KeyModelWithTwoGlyphs('1', '!', false);
                KeyVK_2 = new KeyModelWithTwoGlyphs('2', '"', false);
                KeyVK_3 = new KeyModelWithTwoGlyphs('3', '~', false);
                KeyVK_4 = new KeyModelWithTwoGlyphs('4', '$', false);
                KeyVK_5 = new KeyModelWithTwoGlyphs('5', '%', false);
                KeyVK_6 = new KeyModelWithTwoGlyphs('6', '&', false);
                KeyVK_7 = new KeyModelWithTwoGlyphs('7', '/', false);
                KeyVK_8 = new KeyModelWithTwoGlyphs('8', '(', false);
                KeyVK_9 = new KeyModelWithTwoGlyphs('9', ')', false);
                KeyVK_0 = new KeyModelWithTwoGlyphs('0', '=', false);
                KeyVK_OemMinus = new KeyModelWithTwoGlyphs('ß', '?', false);
                KeyVK_OemPlus = new KeyModelWithTwoGlyphs('´', '`', false);
                KeyVK_Q = new KeyModel('q', 'Q');
                KeyVK_W = new KeyModel('w', 'W');
                KeyVK_E = new KeyModel('e', 'E');
                KeyVK_R = new KeyModel('r', 'R');
                KeyVK_T = new KeyModel('t', 'T');
                KeyVK_Y = new KeyModel('z', 'Z');
                KeyVK_U = new KeyModel('u', 'U');
                KeyVK_I = new KeyModel('i', 'I');
                KeyVK_O = new KeyModel('o', 'O');
                KeyVK_P = new KeyModel('p', 'P');
                KeyVK_OemOpenBrackets = new KeyModel('ü', 'Ü');
                KeyVK_Oem6 = new KeyModelWithTwoGlyphs('+', '*', false);
                KeyVK_Oem5 = new KeyModelWithTwoGlyphs('#', '\'', false);
                KeyVK_A = new KeyModel('a', 'A');
                KeyVK_S = new KeyModel('s', 'S');
                KeyVK_D = new KeyModel('d', 'D');
                KeyVK_F = new KeyModel('f', 'F');
                KeyVK_G = new KeyModel('g', 'G');
                KeyVK_H = new KeyModel('h', 'H');
                KeyVK_J = new KeyModel('j', 'J');
                KeyVK_K = new KeyModel('k', 'K');
                KeyVK_L = new KeyModel('l', 'L');
                KeyVK_Oem1 = new KeyModel('ö', 'Ö');
                KeyVK_Oem7 = new KeyModel('ä', 'Ä');
                KeyVK_Z = new KeyModel('y', 'Y');
                KeyVK_X = new KeyModel('x', 'X');
                KeyVK_C = new KeyModel('c', 'C');
                KeyVK_V = new KeyModel('v', 'V');
                KeyVK_B = new KeyModel('b', 'B');
                KeyVK_N = new KeyModel('n', 'N');
                KeyVK_M = new KeyModel('m', 'M');
                KeyVK_OemComma = new KeyModelWithTwoGlyphs(',', ';', false);
                KeyVK_OemPeriod = new KeyModelWithTwoGlyphs('.', ':', false);
                KeyVK_OemQuestion = new KeyModelWithTwoGlyphs('-', '_', false);
            }
            else
                throw new NotSupportedException($"{layout} is not supported. Please modify the constructor.");
        }
        
    }
    public enum KeyboardLayouts
    {
        English = 0,
        German = 1
    }
}