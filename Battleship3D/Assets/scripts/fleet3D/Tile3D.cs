using UnityEngine;

// fire at a given target
public class Tile3D : MonoBehaviour {

    public GameObject fire;  // hit

    [HideInInspector]
    public GameObject ship;        // null if not occupied    

    [HideInInspector]
    public int x, y;

    GameManager gm;

    [HideInInspector]
    public bool gap;        // adjacent to some ship, length-wise
    Tile3D tile;

    // this is controlled by AI or external player, so no need for click listeners
    void Start()
    {
        gm = GameObject.Find("GameKeeper").GetComponent<GameManager>();
        // Tile32 -> 32
        string sx = "" + name[4], sy = "" + name[5];
        x = int.Parse(sx);
        y = int.Parse(sy);
    }

    void LaunchMissile()
    {
        gm.PlayerLaunch("" + x + y);
    }

    // missile arrived, hit or miss:
    public void Mark()
    {
        if (ship != null)
        {
            Instantiate(fire);
            Ship sp = ship.GetComponent<Ship>();
            sp.health--;
            //    AIFireController.Hit();

            if (sp.health <= 0)
            {
                // let it sink - we don't have gravity scale for 3d body,
                // as Unity uses Box2D, and PhysX engines respectively
                Rigidbody body = sp.gameObject.AddComponent<Rigidbody>();
                Destroy(ship, 1.5f);
            }
        }
        else
            ;
          //  AIFireController.Miss();
    }
    
}
