using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scheduler : MonoBehaviour
{
    GameLogic.Player current_player = GameLogic.Player.empty;
    bool game_over_flag = false;
    GameLogic game_logic = new GameLogic();
    GameLogic.GameResult game_result = new GameLogic.GameResult();

    [SerializeField] private BoardView view;

    // Start is called before the first frame update
    void Start()
    {
        view.Initialize();
        Start_Game();
    }

    private void Start_Game()
    {   
        current_player = GameLogic.Player.circle;
        for (int row = 0; row < game_logic.NumRow; row++)
        {
            for (int col = 0; col < game_logic.NumCol; col++)
            {
                int current_row = row;
                int current_col = col;

                UnityAction button_register = () =>
                {
                    Game_Play(current_row, current_col);
                };

                view.RegisterButtonListener(row, col, button_register);
            }
        }
    }

    private void Game_Play(int row, int col)
    {

        if (game_logic.Make_Move(current_player, row, col) && !(game_over_flag))
        {
            view.Draw_Move(row, col, (int)current_player);
            game_result = game_logic.Check_Game_Over();
            current_player = (GameLogic.Player)(-(int)current_player);
        }
        
        if (game_result.Is_Game_Over && !(game_over_flag))
        {
            PlayerViewData player_view_data = (PlayerViewData)((int)game_result.Winning_Player);
            WinningTypeViewData winning_type_view_data = (WinningTypeViewData)((int)game_result.Winning_Type);
            int winning_pos = game_result.Winning_Pos;

            GameResultViewData game_result_view_data = new GameResultViewData(player_view_data, winning_type_view_data, winning_pos);
            view.Draw_GameOver(game_result_view_data);
            game_over_flag = true;
        }
    }
}
