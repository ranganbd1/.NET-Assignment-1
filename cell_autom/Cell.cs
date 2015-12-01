using System;
using System.Text;
using System.Threading.Tasks;

namespace cell_autom
{
    public enum CellStates
    {
        ZERO,
        ONE,
        TWO,
        THREE,
    }
    class Cell
    {
        private CellStates state;

        public CellStates State
        {
            get { return state; }
        }

        //Constructor that populate the property
        public Cell(CellStates setState)
        {
            state = setState;
        }

        //Return CellStates based on random number; initial cell states 
        public static CellStates CurrentState(int randomNumber)
        {
            if (randomNumber == (int)(CellStates.ZERO))
            {
                return CellStates.ZERO;
            }
            else if (randomNumber == (int)(CellStates.ONE))
            {
                return CellStates.ONE;
            }
            else if (randomNumber == (int)(CellStates.TWO))
            {
                return CellStates.TWO;
            }
            else
                return CellStates.THREE;
        }

        //Change current state to next state( E.g. ZERO to ONE )
        private CellStates NextState
        {
            get
            {
                if (state == CellStates.ZERO)
                {
                    return CellStates.ONE;
                }
                else if (state == CellStates.ONE)
                {
                    return CellStates.TWO;
                }
                else if (state == CellStates.TWO)
                {
                    return CellStates.THREE;
                }
                else
                    return CellStates.ZERO;
            }
        }

        //Change current state to previous state(E.g. ONE to ZERO )
        private CellStates PreviousState
        {
            get
            {
                if (state == CellStates.ZERO)
                {
                    return CellStates.THREE;
                }
                else if (state == CellStates.ONE)
                {
                    return CellStates.ZERO;
                }
                else if (state == CellStates.TWO)
                {
                    return CellStates.ONE;
                }
                else
                    return CellStates.TWO;
            }
        }

        //<Summary>
        //Check neighboring Cell states and then change the states as per rules
        //</Summary>
        public void NewState(Cell prevCell, Cell currentCell, Cell nextCell)
        {
            CellStates prevState = prevCell.state; //state of previous cell
            CellStates nextState = nextCell.state; //state of next cell
            CellStates current = currentCell.state; //state of current cell

            CellStates previous = currentCell.PreviousState; //Previous state of current cellstate
            CellStates next = currentCell.NextState; //Next state of current cellstate

            if (prevState == next && nextState == next)
            {
                state = previous;
            }
            else if (prevState == next || nextState == next)
            {
                state = next;
            }
            else if (prevState == current && nextState == current)
            {
                state = next;
            }
            else
                state = current;
        }
    }
}
