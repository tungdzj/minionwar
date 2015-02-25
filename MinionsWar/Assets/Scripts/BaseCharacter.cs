using UnityEngine;
using System.Collections;

public class BaseCharacter : BaseObject {

    public BaseCharacter(GameObject _obj, Point board)
        :base(_obj, board)
    {

    }
    private float speed = 4;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public override void Update()
    {
        base.Update();
    }

    public virtual bool Move(MoveDirectionEnum dir)
    {
        bool r = true;
        Vector2 pos = position;
        switch (dir)
        {
            case MoveDirectionEnum.Up:
                //move object first
                pos.y += speed * Time.deltaTime;
                //corectting move
                if (pos.y > BoardPosition.Real.y)
                {
                    if (Movable(BoardPosition.Up))
                    {
                        var offset = pos.x - BoardPosition.Real.x;
                        if (!Movable(BoardPosition.Left.Up))
                        {
                            if (offset < -0.2)
                            {
                                pos.y = BoardPosition.Real.y;
                                pos.x += speed * Time.deltaTime;
                            }
                            else if (offset < 0)
                            {
                                pos.x = BoardPosition.Real.x;
                            }
                        }
                        if (!Movable(boardPosition.Right.Up))
                        {
                            if (offset > 0.2)
                            {
                                pos.y = BoardPosition.Real.y;
                                pos.x -= speed * Time.deltaTime;
                            }
                            else if (offset > 0)
                            {
                                pos.x = BoardPosition.Real.x;
                            }
                            
                        }
                        r = true;
                    }
                    else
                    {
                        pos.y = BoardPosition.Real.y;
                        r = false;
                    }
                }
                else
                {
                    r = true;
                }
                break;
            case MoveDirectionEnum.Down:
                pos.y -= speed * Time.deltaTime;

                //corectting move
                if (pos.y < BoardPosition.Real.y)
                {
                    if (Movable(BoardPosition.Down))
                    {
                        var offset = pos.x - BoardPosition.Real.x;
                        if (!Movable(BoardPosition.Left.Down))
                        {
                            if (offset < -0.2)
                            {
                                pos.y = BoardPosition.Real.y;
                                pos.x += speed * Time.deltaTime;
                            }
                            else if (offset < 0)
                            {
                                pos.x = BoardPosition.Real.x;
                            }
                        }
                        if (!Movable(BoardPosition.Right.Down))
                        {
                            if (offset > 0.2)
                            {
                                pos.y = BoardPosition.Real.y;
                                pos.x -= speed * Time.deltaTime;
                            }
                            else if (offset > 0)
                            {
                                pos.x = BoardPosition.Real.x;
                            }
                        }
                        r = true;
                    }
                    else
                    {
                        pos.y = BoardPosition.Real.y;
                        r = false;
                    }
                }
                else
                {
                    r = true;
                }
                break;
            case MoveDirectionEnum.Left:
                pos.x -= speed * Time.deltaTime;

                //corectting move
                if (pos.x < BoardPosition.Real.x)
                {
                    if (Movable(BoardPosition.Left))
                    {
                        var offset = pos.y - BoardPosition.Real.y;
                        if (!Movable(BoardPosition.Left.Down))
                        {
                            if (offset < -0.2)
                            {
                                pos.x = BoardPosition.Real.x;
                                pos.y += speed * Time.deltaTime;
                            }
                            else if (offset < 0)
                            {
                                pos.y = BoardPosition.Real.y;
                            }
                        }
                        if (!Movable(boardPosition.Left.Up))
                        {
                            if (offset > 0.2)
                            {
                                pos.x = BoardPosition.Real.x;
                                pos.y -= speed * Time.deltaTime;
                            }
                            else if (offset > 0)
                            {
                                pos.y = BoardPosition.Real.y;
                            }
                        }
                        r = true;
                    }
                    else
                    {
                        pos.x = BoardPosition.Real.x;
                        r = false;
                    }
                }
                else
                {
                    r = true;
                }
                break;
            case MoveDirectionEnum.Right:
                pos.x += speed * Time.deltaTime;
                //corectting move
                if (pos.x > BoardPosition.Real.x)
                {
                    if (Movable(BoardPosition.Right))
                    {
                        var offset = pos.y - BoardPosition.Real.y;
                        if (!Movable(BoardPosition.Right.Down))
                        {
                            if (offset < -0.2)
                            {
                                pos.x = BoardPosition.Real.x;
                                pos.y += speed * Time.deltaTime;
                            }
                            else if (offset < 0)
                            {
                                pos.y = BoardPosition.Real.y;
                            }
                        }
                        if (!Movable(boardPosition.Right.Up))
                        {
                            if (offset > 0.2)
                            {
                                pos.x = BoardPosition.Real.x;
                                pos.y -= speed * Time.deltaTime;
                            }
                            else if (offset > 0)
                            {
                                pos.y = BoardPosition.Real.y;
                            }
                        }
                        r = true;
                    }
                    else
                    {
                        pos.x = BoardPosition.Real.x;
                        r = false;
                    }
                }
                else
                {
                    r = true;
                }
                break;
        }

        Position = pos;
        return r;
    }

    public virtual bool Movable(Point pos)
    {
        if (pos.X < 0 || pos.Y < 0 || pos.X >= Map.Width || pos.Y >= Map.Height)
        {
            return false;
        }
        switch (Map.Data[pos.X, pos.Y])
        {
            case MapTileEnum.Tree:
                return false;
        }
        return true;
    }
}
