using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TileRemover : MonoBehaviour
{
    public Tilemap tiles;
    public Tile tile;
    public Vector3Int location;
    public Vector3 Snake;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 Snake = Camera.main.ScreenToWorldPoint(transform.position);
            location = tiles.WorldToCell(Snake);
            tiles.SetTile(location, tile);
        }
    }
}
