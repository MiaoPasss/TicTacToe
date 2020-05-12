public class GameLogic
{
    private Player[] GameBoard = new Player[9];
    public enum Player
    {
        empty = 0,
        circle = 1,
        cross = -1
    }

    public struct GameResult {
        public readonly bool IsGameOver;
        public readonly Player WinningPlayer;

        public GameResult(bool isGameOver, Player winningPlayer)
        {
            IsGameOver = isGameOver;
            WinningPlayer = winningPlayer;
        }
    }

    public void Make_Move(Player player, int spot)
    {
        if (this.Check_Empty_Spot(spot))
            GameBoard[spot] = player;
    }

    public GameResult Check_Game_Over()
    {
        return new GameResult(false, Player.empty);
    }

    private bool Check_Empty_Spot(int spot)
    {
        return GameBoard[spot] == Player.empty;
    }
}
