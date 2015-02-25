using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {
    private static MapGenerator instance;
    public static MapGenerator Instance
    {
        get { return instance; }
    }
    public float tileSize = 1;
    public GameObject[] mapTiles;
    public GameObject mapParentObject;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    void Awake()
    {
        instance = this;
    }
    public void Generate()
    {
        int width = Map.Width;
        int height = Map.Height;
        MapTile[,] data = new MapTile[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                switch (Map.Data[x, y])
                {
                    case MapTileEnum.Tree:
                        GameManager.Instance.AddObject(new MapTile(InstanceObject(mapTiles[0],
                            new Vector2(x * tileSize, y * tileSize))), new Point(x, y));
                        break;
                    case MapTileEnum.Player:
                        GameManager.Instance.AddCharacter(new Player(
                            InstanceObject(playerPrefab, new Point(x, y)),
                            new Point(x, y)
                            ));
                        break;
                    case MapTileEnum.Enemy:
                        GameManager.Instance.AddCharacter(new Enemy(
                            InstanceObject(enemyPrefab, new Point(x, y)),
                            new Point(x, y)
                            ));
                        break;
                }
            }
        }
    }

    private GameObject InstanceObject(GameObject prefab, Vector2 position)
    {
        GameObject t = (GameObject)GameObject.Instantiate(prefab);
        t.transform.parent = mapParentObject.transform;
        t.transform.localPosition = position;
        return t;
    }
    private GameObject InstanceObject(GameObject prefab, Point position)
    {
        return InstanceObject(prefab, new Vector2(position.X * tileSize, position.Y * tileSize));
    }
}
