using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileView : MonoBehaviour
{
    [SerializeField] private GameObject cross;
    [SerializeField] private GameObject circle;

    public Button button
    {
        get
        {
            return this.GetComponent<Button>();
        }
    }

    public void ShowCross()
    {
        cross.SetActive(true);
    }

    public void ShowCircle()
    {
        circle.SetActive(true);
    }

    public void Empty()
    {
        cross.SetActive(false);
        circle.SetActive(false);
    }
}
