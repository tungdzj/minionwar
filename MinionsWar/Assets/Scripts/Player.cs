using UnityEngine;
using System.Collections;

public class Player : BaseCharacter {

    public Player(GameObject _obj, Point boardPos)
        :base(_obj, boardPos)
    {

    }
    public override void Update()
    {
        base.Update();
        HandleInput();
    }

    void HandleInput()
    {
        MoveDirectionEnum moveInput = MoveDirectionEnum.None;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveInput = MoveDirectionEnum.Up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveInput = MoveDirectionEnum.Down;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = MoveDirectionEnum.Left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = MoveDirectionEnum.Right;
        }
        if (moveInput != MoveDirectionEnum.None)
        {
            Move(moveInput);
        }
    }
}
