using UnityEngine;
using UnityEngine.UI;

// fire at a given target
public class Tile : MonoBehaviour {

    public Sprite hitImg;
    public Sprite missImg;
    public Sprite deadImg;
    public bool interactive;        // is clickable or not (AI-controlled)

    [HideInInspector]
    public GameObject ship;        // null if not occupied    

    [HideInInspector]
    public int x, y;

    GameManager gm;

    [HideInInspector]
    public bool gap;        // adjacent to some ship, length-wise
    Button b;

    void Start()
    {
        gm = GameObject.Find("GameKeeper").GetComponent<GameManager>();
        b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(LaunchMissile);

        string sx = "" + name[6], sy = "" + name[7];
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
            b.GetComponent<Image>().sprite = hitImg;
            Ship sp = ship.GetComponent<Ship>();
            sp.health--;
            if(sp.health <= 0)
                b.GetComponent<Image>().sprite = deadImg;
        }
        else
            b.GetComponent<Image>().sprite = missImg;
    }
    
}
