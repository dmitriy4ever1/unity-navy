using UnityEngine;

public class Ship : MonoBehaviour {

    /// Enemy ships are invisible at the start and will not be revealed until completely destroyed.
    public bool submersible;  // enemy ship - originally invisible under water

    [Range(1, 4)]
	public int size;		// we always set the size (occupied cells) of the ships via inspector

    [HideInInspector]
    public int row;
    [HideInInspector]
    public int col;  // col + capacity is the ship's horizontal line

    public int health;     // optionally can manage health and update player fleet stats to AIFireController

    void Start () {
        health = size;       
	}

    // we could add Hit() function, to update sprites for related 2D tiles
    // but this is not really necessary 
}
