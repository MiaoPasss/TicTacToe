using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BoardView : MonoBehaviour, IView
{
    [SerializeField] private PrefabInstantiator ButtonInstantiator;
    private Button[] ButtonGroup = new Button[9];

    public int[] Ask_For_Next_Move()
    {
        throw new System.NotImplementedException();
    }

    public void Draw_GameOver(GameResultViewData game_result)
    {
        
    }

    public void Draw_Move(int row, int col)
    {
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            ButtonGroup[i] = ButtonInstantiator.Instantiate().GetComponent<Button>();
            int button_index = i;
            UnityAction on_ith_button_clicked = () => 
            {
                Debug.Log(button_index + "-th button clicked");
            };
            RegisterButtonClick(ButtonGroup[i], on_ith_button_clicked);
        }
    }

    private void RegisterButtonClick(Button button_click, UnityAction onClick)
    {
        button_click.onClick.AddListener(onClick);
    }

    
}
