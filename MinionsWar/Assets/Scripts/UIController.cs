using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {
    private static UIController instance;
    public GameObject[] panels;

    Rect textRect, buttonRect;

	void Start () {
        textRect = new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 2, 200);
        buttonRect = new Rect(Screen.width / 3, Screen.height / 4 + 200, Screen.width / 3, 100);
	}

    //main panel controller
    public void mainOnPlayClick()
    {

    }

}
