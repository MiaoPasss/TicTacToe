public class GameLogic
{
    private Player[,] GameBoard = new Player[3,3];
    public enum Player
    {
        empty = 0,
        circle = 1,
        cross = -1
    }
    public enum WinningType
    {
        ROW,
        COL,
        DIAG,
        DRAW
    }
    public enum Direction
    {
        TLtoBR,
        TRtoBL
    }

    public int NumRow
    {
        get
        {
            return GameBoard.GetLength(0);
        }
    }

    public int NumCol
    {
        get
        {
            return GameBoard.GetLength(1);
        }
    }

    public GameLogic()
    {
        for(int row = 0; row < NumRow; row++)
        {
            for (int col = 0; col < NumCol; col++)
            {
                GameBoard[row, col] = Player.empty;
            }
        }
    }

    public struct GameResult {
        public readonly bool Is_Game_Over;
        public readonly Player Winning_Player;
        public readonly WinningType Winning_Type;
        public readonly int Winning_Pos;

        public GameResult(bool isGameOver, Player winningPlayer, WinningType winningType, int winningPos)
        {
            Is_Game_Over = isGameOver;
            Winning_Player = winningPlayer;
            Winning_Type = winningType;
            Winning_Pos = winningPos;
        }
    }

    public bool Make_Move(Player player, int row, int col)
    {
        if (this.Check_Empty_Spot(row, col))
        {
            GameBoard[row, col] = player;
            return true;
        }

        return false;
    }

    public GameResult Check_Game_Over()
    {
        bool is_game_over = false;
        Player winning_player = Player.empty;
        WinningType winning_type = WinningType.ROW;
        int winning_pos = -1;

        for (int row = 0; row < NumRow; row++)
        {
            if (this.Check_Row_GameOver(row))
            {
                is_game_over = true;
                winning_player = GameBoard[row, 0];
                winning_type = WinningType.ROW;
                winning_pos = row;
            }
        }

        for (int col = 0; col < NumCol; col++)
        {
            if (this.Check_Col_GameOver(col))
            {
                is_game_over = true;
                winning_player = GameBoard[0, col];
                winning_type = WinningType.COL;
                winning_pos = col;
            }
        }

        if (this.Check_Diag_GameOver(Direction.TLtoBR))
        {
            is_game_over = true;
            winning_player = GameBoard[0, 0];
            winning_type = WinningType.DIAG;
            winning_pos = 0;
        }

        if (this.Check_Diag_GameOver(Direction.TRtoBL))
        {
            is_game_over = true;
            winning_player = GameBoard[0, NumCol - 1];
            winning_type = WinningType.DIAG;
            winning_pos = NumCol;
        }

        if (is_game_over == false)
        {
            if (this.Check_Board_Filled())
            {
                is_game_over = true;
                winning_player = Player.empty;
                winning_type = WinningType.DRAW;
                winning_pos = -1;
            }
        }

        return new GameResult(is_game_over, winning_player, winning_type, winning_pos);
    }

    private bool Check_Empty_Spot(int row, int col)
    {
        return GameBoard[row, col] == Player.empty;
    }

    private bool Check_Col_GameOver(int row)
    {
        for(int col = 0; col < NumCol - 1; col++)
        {
            if ((GameBoard[row, col] != GameBoard[row, col+1]) || GameBoard[row, col] == Player.empty)
                return false;
        }

        return true;
    }

    private bool Check_Row_GameOver(int col)
    {
        for (int row = 0; row < NumRow - 1; row++)
        {
            if ((GameBoard[row, col] != GameBoard[row+1, col]) || GameBoard[row, col] == Player.empty)
                return false;
        }

        return true;
    }

    private bool Check_Diag_GameOver(Direction direction)
    {
        int row;
        int col;

        if (direction == Direction.TLtoBR)
        {
            for (row = 0, col = 0; row < NumCol - 1; row++, col++)
            {
                if ((GameBoard[row, col] != GameBoard[row + 1, col + 1]) || GameBoard[row, col] == Player.empty)
                    return false;
            }

            return true;
        }

        else
        {
            for (row = 0, col = NumCol - 1; row < NumRow - 1; row++, col--)
            {
                if ((GameBoard[row, col] != GameBoard[row + 1, col - 1]) || GameBoard[row, col] == Player.empty)
                    return false;
            }

            return true;
        }
    }

    private bool Check_Board_Filled()
    {
        bool filled = true;

        for (int row = 0; row < NumRow; row++)
        {
            for (int col = 0; col < NumCol; col++)
            {
                if (this.Check_Empty_Spot(row, col))
                    filled = false;
            }
        }

        return filled;
    }
}
