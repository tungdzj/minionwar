using System;
using System.Collections.Generic;
using UnityEngine;
public class MapTile : BaseObject
{
    public MapTile()
        : base()
    {

    }
    public MapTile(GameObject _obj) :
        base()
    {
        this.obj = _obj;
    }

    public MapTile(GameObject _obj, Point boardPosition)
        : base(_obj, boardPosition)
    {
    }

    protected GameObject obj;
    public override int OnBoom()
    {
        return base.OnBoom();
    }

    public override int Destroy()
    {
        return base.Destroy();
    }
}