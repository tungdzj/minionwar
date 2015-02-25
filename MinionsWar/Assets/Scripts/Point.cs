using UnityEngine;
using System.Collections;

public class Point{
    private int x, y;

    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    public int X
    {
        get { return x; }
        set { x = value; }
    }

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Point()
    {
        x = 0;
        y = 0;
    }
    public Point Up
    {
        get { return new Point(x, y + 1); }
    }
    public Point Down
    {
        get { return new Point(x, y - 1); }
    }

    public Point Left
    {
        get { return new Point(x - 1, y); }
    }

    public Point Right
    {
        get { return new Point(x +1, y);}
    }

    public Vector2 Real
    {
        get { return new Vector2(x * Game.DISTANCE, y * Game.DISTANCE); }
    }

    public override string ToString()
    {
        return "Point(" + x + "," + y + ")";
    }
}
