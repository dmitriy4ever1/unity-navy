using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerMissile, enemyMissile;
    public GameObject explosion;
    int playerTurn = 0, aiTurn = 3;

    string playerTarget = "";

    PlayerMissile playerNav;  // these two could be possibly
    EnemyMissile  enemyNav;     // combined into one script

    void Start()
    {
        playerNav = playerMissile.GetComponent<PlayerMissile>();
        enemyNav = enemyMissile.GetComponent<EnemyMissile>();
    }

    // button callback. Player goes first
    public void PlayerLaunch(string targetField)
    {
        if (playerTurn < 3) {
            print("Player shooting at " + targetField);
            playerTarget = targetField;
            playerNav.Launch();
            playerTurn++;
            aiTurn--;   // neat hack
        }        
    }

    // ai callback
    public void EnemyLaunch(string targetField)
    {
        if (aiTurn < 3)
        {
            print("AI shooting at " + targetField);
            GameObject target = GameObject.Find("Tile" + targetField);
            enemyNav.Launch(target);
            aiTurn++;
            playerTurn--;
        }
    }

    public void MissileLanded()
    {
        Button b = GameObject.Find("Button" + playerTarget).GetComponent<Button>();
        Tile t = b.GetComponent<Tile>();
        t.Mark();
    }

   
}
