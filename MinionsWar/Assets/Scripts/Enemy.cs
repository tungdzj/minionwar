using UnityEngine;
using System.Collections;

public class Enemy : BaseCharacter {
    private MoveDirectionEnum move;
	public Enemy(GameObject _obj, Point position)
        : base(_obj, position)
    {
        move = (MoveDirectionEnum)Random.Range(0, 4);
    }

    public override void Update()
    {
        if (!Move(move))
        {
            move = (MoveDirectionEnum)Random.Range(0, 4);
        }
    }
}
