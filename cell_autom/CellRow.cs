using System;
using System.Text;
using System.Threading.Tasks;

namespace cell_autom
{
    class CellRow
    {
        private const int TOTALCELLS = 64;
        private const int GENERATIONS = 20;

        private Cell[] cellLine;
        private Cell[] newLine;
        private Cell[] tempArray;

        public CellRow(int seed)
        {
            cellLine = new Cell[TOTALCELLS];
            newLine = new Cell[TOTALCELLS];
            
            //Set up random object and initialise with given seed value
            Random random = new Random(seed);

            int randomNumber;
            for (int i = 0; i < TOTALCELLS; i++)
            {
                //Generate a random number of  0 to 3 
                randomNumber = random.Next((int)(CellStates.THREE) + 1);
                //Based on random number, generate corresponding cell states
                CellStates state = Cell.CurrentState(randomNumber);
                //<summary>
                //Create (TOTALCELLLS) instances of of Cell class with 
                //constructor parameter and put them in array
                //Resulting Array - cellLine[x].state = CellStates.(state)
                //cellLine for storing automa and newLine for building new generation
                //</Summary>
                cellLine[i] = new Cell(state);
                newLine[i] = new Cell(state);
            }
        }

        public void NewGeneration(int i)
        {
            //Determine index number in array ( E.g. prev=0, current=1 and next=2 )
            for (int current = 0; current < TOTALCELLS; current++)
            {
                int prev;
                if (current > 0)
                {
                    prev = current - 1;
                }
                else
                    prev = TOTALCELLS - 1;

                int next;
                if (current == (TOTALCELLS - 1))
                {
                    next = 0;
                }
                else
                    next = current + 1;

                //Check neighboring Cell states of cellLine and update states of newLine.
                newLine[current].NewState(cellLine[prev], cellLine[current], cellLine[next]);
            }

            //Swapping Array elements for printing and building new generation.
            //Note : Last generation is built in No. (GENERATIONS - 1) loop in newLine
           if (i < (GENERATIONS - 1))
            {
                tempArray = cellLine;
                cellLine = newLine;
                newLine = tempArray;
            }
        }

        public void PrintRow(int i)
        {
            if (i < (int)(CellStates.THREE) * (int)(CellStates.THREE))
            {
                //Print 1 to 9, with space of three after 'gen'
                Console.Write("gen   " + (i+1) + " ");
                StateBuilder();
                Console.WriteLine();
            }
            else
            {
                //Print 9 to rest, with space of two after 'gen'
                Console.Write("gen  " + (i+1) + " ");
                StateBuilder();
                Console.WriteLine();
            }
        }

        private void StateBuilder()
        {
            //Print Corresponding special character of CellStates in the row
            for (int i = 0; i < TOTALCELLS; i++)
            {
                CellStates state = cellLine[i].State;
                if (state == CellStates.ZERO)
                {
                    Console.Write(" ");
                }
                else if (state == CellStates.ONE)
                {
                    Console.Write(".");
                }
                else if (state == CellStates.TWO)
                {
                    Console.Write("+");
                }
                else
                    Console.Write("#");
            }
        }

        public void FinalHash()
        {
            // Calculate hash value of the last line of cell
            int finalHash = 0;
            int stateValue = 0;
            for (int i = 0; i < TOTALCELLS; i++)
            {
                stateValue = (int)cellLine[i].State;
                finalHash += (i + 1) * stateValue; 
            }
            Console.WriteLine("Final hash = {0}", finalHash);
        }


        public static void ErrorMessage()
        {
            //Print this message if command line argument is invalid.
            Console.WriteLine("ERROR. Invalid Command line argument");
            Console.WriteLine("Systax: cell_autom seed");
            Console.WriteLine("Seed must be a positive integer\n");
        }
    }
}
