using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class Snake_Movement : MonoBehaviour
{
    //Initialise the tile map
    public Tilemap tiles;
    public Tile tile;

    // Set the tile location
    public Vector3Int location;
    
    //Set Normal Speed and Rotate Speed
    public float rotateSpeed = 40.0f;
    public float speed = 5.0f;
    

    // Update is called once per frame
    void Update()
    {
        SnakeMovement();
        SetBoundary();
    }

   
    void SnakeMovement()
    {
        
        float rotate = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
        transform.Rotate(Vector3.up * rotate);

        float movement = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(0, 0, movement);

        float totalspeed = speed * Time.deltaTime;
        float totalrotate = rotateSpeed * Time.deltaTime;

      // if (Input.GetKey("up"))
      // {
            transform.Translate(0, 0, totalspeed);
            //This is the logic for converting all normal tiles to green
            Vector3Int Snake = tiles.WorldToCell(transform.position);
            location = tiles.WorldToCell(Snake);
            if (tiles.GetTile(location) != tile)
            {
            tiles.SetTile(location, tile);

            // Check if all tiles are green
            if (AreAllTilesGreen())
            {
                // Call a function to restart the game
                SceneManager.LoadScene("Game_Over");
            }
        }
    }
   // }


bool AreAllTilesGreen()
{
    BoundsInt bounds = tiles.cellBounds;
    TileBase[] allTiles = tiles.GetTilesBlock(bounds);

    foreach (var currentTile in allTiles)
    {
        if (currentTile != tile)
        {
         
           return false; // At least one tile is not green
        }
    }

    return true; // All tiles are green
}


    
    // Setting the boundary for the snake
      void SetBoundary()
      {
        float rotate = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
        transform.Rotate(Vector3.up * rotate);

        float movement = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(0, 0, movement);

        float totalspeed = speed * Time.deltaTime;
        float totalrotate = rotateSpeed * Time.deltaTime;
        
        //Reverse the postion of the snake if it goes towards the border 

        // Setting boundaries to the y-axis
        if (transform.position.y >= 4.42f)
        {
            transform.position = new Vector3(transform.position.x, 4.42f, 0);
            transform.Rotate(0, -totalrotate, 0);
        }

       
        if (transform.position.y <= -4.65f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, 0);
            transform.Rotate(0, -totalrotate, 0);
        }

        // Setting boundaries to the x-axis
        if (transform.position.x <= -6.5f)
        {
            transform.position = new Vector3(-6.5f, transform.position.y);
            transform.Rotate(0, -totalrotate, 0);
        }

        if (transform.position.x >= 6.5f)
        {
            transform.position = new Vector3(6.5f, transform.position.y);
            transform.Rotate(0, -totalrotate, 0);

        }
    }
}
    



     
