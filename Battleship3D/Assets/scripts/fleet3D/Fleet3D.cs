using System.Collections.Generic;
using UnityEngine;

// one Fleet for the player, and one for the AI board (submarines)
public class Fleet3D : MonoBehaviour {

    public GameObject single, twin, triple, flagman;
    private static Tile3D[,] board;

    private static List<Tile3D> tileList = new List<Tile3D>();     // for AI aiming

    void Awake () {
        BoardManager3D admiral = new BoardManager3D();
        BuildTiles();
        GameObject [] fleet = BuildFleet();
        admiral.PlaceFleet(fleet, board);
	}

    public static List<Tile3D> getTiles()
    {
        return tileList;
    }

    void BuildTiles()
    {
        board = new Tile3D[8, 8];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameObject go = GameObject.Find("Tile" + i + j);
                board[i, j] = go.GetComponent<Tile3D>();
                tileList.Add(go.GetComponent<Tile3D>());
            }
        }
    }
  
    // creates fleed, but not positions it yet
    GameObject [] BuildFleet()
    {
        // add from largest to smallest
        GameObject[] fleet = new GameObject[10];
        
        fleet[0] = GameObject.Instantiate(flagman);

        for (int i = 1; i < 3; i++)
            fleet[i] = GameObject.Instantiate(triple);

        for (int i = 3; i < 6; i++)
            fleet[i] = GameObject.Instantiate(twin);

        for (int i = 6; i < 10; i++)
            fleet[i] = GameObject.Instantiate(single);

        return fleet;
    }

   
}       
