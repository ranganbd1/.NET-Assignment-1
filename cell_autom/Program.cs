using System;
using System.Text;
using System.Threading.Tasks;

namespace cell_autom
{
    class Program
    {
        private const int GENERATIONS = 20;
        static void Main(string[] args)
        {
            int seed;
            bool isValidSeed = CheckSeed(args, out seed);
            
            if (isValidSeed)
            {
                //Create a instance of CellRow & pass the seed value
                CellRow cellRow = new CellRow(seed);
                for (int i = 0; i < GENERATIONS; i++)
                {
                    //Print the States of the current Cellline then produce new Generation
                    cellRow.PrintRow(i);
                    cellRow.NewGeneration(i);
                }
                //Print the Final Hash value of the last generation.
                cellRow.FinalHash(); 
            }
            else
                CellRow.ErrorMessage();
        }

        //<summary>
        //Return true with seed value -
        //If command line argument is positive integer greater than zero,
        //and true for int32 which will be passed to Random(int32) constructor; 
        //Otherwise return false
        //</summary>
        private static bool CheckSeed(string[] args, out int seed)
        {
            seed = 0;
            if (args.Length == 1)
            {
                return Int32.TryParse(args[0], out seed) && seed > 0;
            }
            else
                return false;
        }

    }
}
//-------------------------------------------------//
// Name : Md Rubaiyat Bin Sattar;   ID : 11789005  //
//------------------------------------------------//