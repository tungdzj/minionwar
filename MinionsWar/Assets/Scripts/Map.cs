using UnityEngine;
using System.Collections;
using System.Xml;

public class Map {
    private static MapTileEnum[] mapTileData = 
    {
        MapTileEnum.Empty, 
        MapTileEnum.Tree, 
        MapTileEnum.Player,
        MapTileEnum.Enemy
    };
    private static int width = 10, height = 10;

    public static int Height
    {
        get { return Map.height; }
    }

    public static int Width
    {
        get { return Map.width; }
    }


    private static MapTileEnum[,] data;
    public static MapTileEnum[,] Data
    {
        get { return data; }
    }
    private static int level;

    public static void Load(int _level)
    {
        level = _level;
        string filename = "Assets//Maps//map" + level + ".xml";
        XmlDocument doc = new XmlDocument();
        doc.Load(filename);
        width = int.Parse(doc.DocumentElement.Attributes["width"].InnerText.ToString());
        height = int.Parse(doc.DocumentElement.Attributes["height"].InnerText.ToString());
        data = new MapTileEnum[width, height];
        int x = 0, y = 1; ;
        foreach (XmlNode e in doc.DocumentElement.ChildNodes)
        {
            if (x == width)
            {
                x = 0;
                y++;
            }
            data[x, height - y] = mapTileData[int.Parse(e.InnerText)];
            x++;
        }
    }

}
