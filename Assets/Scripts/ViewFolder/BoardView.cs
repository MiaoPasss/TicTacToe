using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BoardView : MonoBehaviour
{
    [SerializeField] public GameObject circle_win;
    [SerializeField] public GameObject cross_win;
    [SerializeField] private PrefabInstantiator ButtonInstantiator;
    private TileView[] ButtonGroup = new TileView[9];
    [SerializeField] private Animator victory_animator;

    public void RegisterButtonListener(int row, int col, UnityAction listener)
    {
        int button_index = 0;
        button_index = col * 3 + row;
        RegisterButtonClick(ButtonGroup[button_index].button, listener);
    }

    public void Draw_GameOver(GameResultViewData game_result)
    {
        GameObject winner;

        if (game_result.Winning_Player == PlayerViewData.circle)
            winner = circle_win;

        else
            winner = cross_win;

        /*
        winner.SetActive(true);
        winner.transform.localScale = Vector3.zero;
        LeanTween.scale(winner, Vector3.one, 2);
        */

        victory_animator.SetTrigger("Move To Victory");

        Debug.Log("Game Over!");
        Debug.Log("Winner: " + game_result.Winning_Player.ToString("g"));
        Debug.Log("WinningType: " + game_result.Winning_Type.ToString("g"));
        Debug.Log("WinningPosition: " + game_result.Winning_Pos);
    }

    public void Draw_Move(int row, int col, int current_player)
    {
        int button_index = row + col * 3;

        if (current_player == -1)
            ButtonGroup[button_index].ShowCross();

        else if (current_player == 1)
            ButtonGroup[button_index].ShowCircle();


        string color;
        switch (current_player)
        {
            case -1:
                color = "Cross";
                break;
            case 1:
                color = "Circle";
                break;
            default:
                color = "None";
                break;
        }

        Debug.Log(color + " play move at " + row + ',' + col);
    }

    // Start is called before the first frame update
    public void Initialize()
    {
        for (int i = 0; i < 9; i++)
        {
            ButtonGroup[i] = ButtonInstantiator.Instantiate().GetComponent<TileView>();

            /*
            int button_index = i;

            UnityAction on_ith_button_clicked = () => 
            {
                Debug.Log(button_index + "-th button clicked");
            };
            
            RegisterButtonClick(ButtonGroup[i], on_ith_button_clicked);
            */
        }
    }

    private void RegisterButtonClick(Button button_click, UnityAction onClick)
    {
        button_click.onClick.AddListener(onClick);
    }

    
}
