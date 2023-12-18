using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    //Setting the grid area for changing the positions of food
    public BoxCollider2D GridArea;

    int trailTime = 6;
    int Score = 0;
    public static float elapsed = 0;

    // Making a basic GUI For Score and Time
    GUIStyle guiStyle = new GUIStyle();
    void OnGUI()
    {
        guiStyle.fontSize = 50;
        guiStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 100, 20), "Trail Time:" + (int)elapsed, guiStyle);
        GUI.Label(new Rect(10, 65, 100, 20), "Score:" + (int)Score, guiStyle);
    }

    private void Start()
    {
        //Setting the food position for the first time
        Randomize();
    }


    //Change different positions
    private void Randomize()
    {
        Bounds bounds = this.GridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            Randomize();
            Score++;

        }
    }

    // Updating random positions based on the time given.
    private void Update()
        {
            elapsed += Time.deltaTime;
            if (elapsed > trailTime)
            {
                Randomize();
                elapsed = 0;
            }
        }
    } 
            
     
    