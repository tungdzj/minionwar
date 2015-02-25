using UnityEngine;
using System.Collections;

public class BaseObject {
    public BaseObject()
    {
        Manager = GameManager.Instance;
    }

    public BaseObject(GameObject _obj, Vector2 position)
        : this()
    {
        this.obj = _obj;
        Position = position;
    }

    public BaseObject(GameObject _obj, Point boardPosition)
        : this(_obj, new Vector2(boardPosition.X * Game.DISTANCE, boardPosition.Y * Game.DISTANCE))
    {

    }
    public GameObject obj;
    public GameManager Manager;
    public Vector2 position;
    public Point boardPosition;
    public Vector2 Position
    {
        get { return position; }
        set
        {
            position = value;
            boardPosition = new Point(
                (int)((position.x + Game.DISTANCE / 2) / Game.DISTANCE),
                (int)((position.y + Game.DISTANCE / 2) / Game.DISTANCE));
            obj.transform.localPosition = position;
        }
    }

    public Point BoardPosition
    {
        get { return boardPosition; }
    }


    public virtual void Update()
    {

    }

    public virtual int OnBoom()
    {
        return 0;
    }

    public virtual int Destroy()
    {
        return 0;
    }
}
