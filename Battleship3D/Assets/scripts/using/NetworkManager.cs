using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{
    GameObject enemy;
    PlayerSetup ps;
    public static Tile3D[,] fakeEnemyBoard;
    public Tile3D[,] GetEnemyBoard()
    {
        //ps = enemy.GetComponent<PlayerSetup>();
        return PlayerSetup.board;
      
    }


}
