using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionTutor
{
    class TrimmerHeader
    {
        //Class to make reuse of my header simpler.

        private char borderCharacter = '#';

        public char BorderCharacter
        {
            get { return borderCharacter; }
            set { borderCharacter = value; }
        }


        private string studentName = "Justin Trimmer";

        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }

        private string studentClass = "CSC202";

        public string StudentClass
        {
            get { return studentClass; }
            set { studentClass = value; }
        }

        private string studentBlock = "SP14022";

        public string StudentBlock
        {
            get { return studentBlock; }
            set { studentBlock = value; }
        }

        private string studentAssignment = "Assignment Null";

        public string StudentAssignment
        {
            get { return studentAssignment; }
            set { studentAssignment = value; }
        }

        public void ClearAndPrintHeader()
        {
            // Method to clear the console, and print my personal header.

            int totalCharacterWidth = GetBorderWidth();
            int widthMinusSideChars = totalCharacterWidth - 4;

            // Clear the console.
            Console.Clear();

            // Print my Header.
            Console.WriteLine("\n{0}{0}", new string(borderCharacter, totalCharacterWidth/2));
            Console.WriteLine("{0}{1}{1}{0}", new string(borderCharacter, 2), new string(' ', widthMinusSideChars/2));

            PrintCurrentLine(studentName, widthMinusSideChars);
            PrintCurrentLine(studentClass, widthMinusSideChars);
            PrintCurrentLine(studentBlock, widthMinusSideChars);
            PrintCurrentLine(studentAssignment, widthMinusSideChars);

            Console.WriteLine("{0}{1}{1}{0}", new string(borderCharacter, 2), new string(' ', widthMinusSideChars/2));
            Console.WriteLine("{0}{0}\n\n", new string(borderCharacter, totalCharacterWidth / 2));
        }

        private int GetBorderWidth()
        {
            // Method to make sure the border is always wider than the longest string in the header.

            int nameWidth = studentName.Length;
            int classWidth = studentClass.Length;
            int blockWidth = studentBlock.Length;
            int assignmentWidth = studentAssignment.Length;
            int longestWord = nameWidth;
            int borderWidth = 0;

            if (longestWord < classWidth)
            {
                longestWord = classWidth;
            }
            else if (longestWord < blockWidth)
            {
                longestWord = blockWidth;
            }
            else if (longestWord < assignmentWidth)
            {
                longestWord = assignmentWidth;
            }

            borderWidth = (longestWord % 2 == 0) ? (longestWord + 14) : (longestWord + 13);

            return borderWidth;
        }

        private void PrintCurrentLine(string lineText, int widthMinusSideChars)
        {
            // Method to calculate the number of spaces on each side of the current word between the border.

            int widthOfWord = lineText.Length;
            int spacesToDivide = widthMinusSideChars - widthOfWord;
            // If the length of the word passed in is odd, add one extra space before the word to account for this.
            int numberOfSpacesInFront = (spacesToDivide % 2 == 0) ? (spacesToDivide / 2) : ((spacesToDivide / 2) + 1);
            int numberOfSpacesInBack = spacesToDivide / 2;
            
            Console.WriteLine("{0}{1}{2}{3}{0}", new string(borderCharacter, 2), new string(' ', numberOfSpacesInFront), lineText, new string(' ', numberOfSpacesInBack));
        }
    }
}
