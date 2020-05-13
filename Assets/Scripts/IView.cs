public interface IView
{
    int[] Ask_For_Next_Move();
    void Draw_Move(int row, int col);
    void Draw_GameOver(GameResultViewData game_result);
}

public struct GameResultViewData
{
    public readonly PlayerViewData Winning_Player;
    public readonly WinningTypeViewData Winning_Type;
    public readonly int Winning_Pos;

    public GameResultViewData(PlayerViewData winningPlayer, WinningTypeViewData winningType, int winningPos)
    {
        Winning_Player = winningPlayer;
        Winning_Type = winningType;
        Winning_Pos = winningPos;
    }
}

public enum PlayerViewData
{
    empty = 0,
    circle = 1,
    cross = -1
}
public enum WinningTypeViewData
{
    ROW,
    COL,
    DIAG,
    DRAW
}