using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionTutor
{
    class Program
    {
        static TrimmerHeader myHeader = new TrimmerHeader();

        static void Main(string[] args)
        {
            // Initialize any object variables I want to change.  The assignment name must always be initialized.
            myHeader.StudentAssignment = "Division Tutor";

            // Print header before printing anything else.
            myHeader.ClearAndPrintHeader();

            // Pause the consol so the user can read the output before it closes.
            Console.Write("\n\nPress any key to continue... ");
            Console.ReadKey(true);
        }
    }
}
