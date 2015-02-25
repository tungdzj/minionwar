using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {
    private static GameData instance;
    public static GameData Instance
    {
        get{
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }
    private static int currentLevel = 1;

    public static int CurrentLevel
    {
        get { return currentLevel; }
        set { currentLevel = value; }
    }

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
