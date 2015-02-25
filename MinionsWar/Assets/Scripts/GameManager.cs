using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameManager : MonoBehaviour {

    private static GameManager instance = null;
    public static GameManager Instance
    {
        get { return instance; }
    }

    //Game Objects
    

    //Properties
    private bool isPause = true;
    public bool IsPause
    {
        get { return isPause; }
    }

    public List<BaseCharacter> characters;
    public List<BaseEffect> effects;
    public List<BaseTrap> traps;
    List<BaseObject>[,] mapObjects;
    List<BaseObject> tmpList;
    void Awake()
    {
        instance = this;
        tmpList = new List<BaseObject>();
        characters = new List<BaseCharacter>();
        effects = new List<BaseEffect>();
        traps = new List<BaseTrap>();
    }
	// Use this for initialization
	void Start () {
        Map.Load(GameData.CurrentLevel);
        mapObjects = new List<BaseObject>[Map.Width, Map.Height];
        for (int i = 0; i < Map.Width; i++)
        {
            for (int j = 0; j < Map.Height; j++)
            {
                mapObjects[i, j] = new List<BaseObject>();
            }
        }
            MapGenerator.Instance.Generate();
	}
	
	// Update is called once per frame
	void Update () {
        tmpList.Clear();
        foreach (BaseCharacter c in characters)
        {
            tmpList.Add(c);
        }
        foreach (BaseTrap t in traps)
        {
            tmpList.Add(t);
        }
        foreach (BaseEffect e in effects)
        {
            tmpList.Add(e);
        }
        for (int i = 0; i < Map.Width; i++)
        {
            for (int j = 0; j < Map.Height; j++)
            {
                foreach (BaseObject o in mapObjects[i, j])
                {
                    tmpList.Add(o);
                }
            }
        }
        foreach (BaseObject t in tmpList)
        {
            t.Update();
        }
	}

    public void StartGame()
    {
        isPause = false;
    }

    public void AddCharacter(BaseCharacter character)
    {
        characters.Add(character);
    }

    public void AddObject(BaseObject obj, Point pos)
    {
        mapObjects[pos.X, pos.Y].Add(obj);
    }
}
