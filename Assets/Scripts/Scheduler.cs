using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scheduler : MonoBehaviour
{
    GameLogic.Player current_player = GameLogic.Player.empty;
    GameLogic game_logic = new GameLogic();
    GameLogic.GameResult game_result = new GameLogic.GameResult();

    [SerializeField] private IView view;

    // Start is called before the first frame update
    void Start()
    {
        Start_Game();

        do
        {
            Game_Play();
        } while (game_result.Is_Game_Over == false);

    }

    private void Start_Game()
    {   
        current_player = GameLogic.Player.circle;
    }

    private void Game_Play()
    {
        int[] Player_Move = view.Ask_For_Next_Move();
        int row = Player_Move[0];
        int col = Player_Move[1];
        if (game_logic.Make_Move(current_player, row, col))
        {
            current_player = (GameLogic.Player)(-(int)current_player);
            view.Draw_Move(row, col);
            game_result = game_logic.Check_Game_Over();
        }
        
        if (game_result.Is_Game_Over)
        {
            PlayerViewData player_view_data = (PlayerViewData)((int)game_result.Winning_Player);
            WinningTypeViewData winning_type_view_data = (WinningTypeViewData)((int)game_result.Winning_Type);
            int winning_pos = game_result.Winning_Pos;

            GameResultViewData game_result_view_data = new GameResultViewData(player_view_data, winning_type_view_data, winning_pos);
            view.Draw_GameOver(game_result_view_data);
        }
    }
}
