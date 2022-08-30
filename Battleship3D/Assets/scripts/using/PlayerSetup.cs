using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{   /*
      4 hover
      3 boat
      2 cruiser
      1 mainslay
     */
    public GameObject GameStartButton;
    
    public GameObject playerSetupManager;
    public Sprite checkmark;

    ChangeButtonTxt cbt;

    public Text selectedText;

    private static List<Tile3D> tileList = new List<Tile3D>();     // for AI aiming

    public GameObject Hover, Boat, Cruiser, Mainslayer;
    int hc = 4, bc = 3, cc = 2, mc = 1;
    int len;
    GameObject CurentSelection;
    
    public static Tile3D[,] board;
    // Start is called before the first frame update
    void Start()
    {
        cbt = playerSetupManager.GetComponent<ChangeButtonTxt>();
        BuildTiles();
        GameStartButton.SetActive(false);
    }

    public void tileUnpressed(int r, int c, tilePress tile,int length)
    {
        Destroy(tile.ShipOnTile);
        for (int i = c; i < c + length; i++)
            board[r, i].ship = null;

        // mark the adjacent tiles as required gaps between ships (length-wise)
        if (c > 0)
            board[r, c - 1].gap = true;  // adjacent space taken
        if (c + length < 8)
            board[r, c + length].gap = false;
        if (length == 1)
        {
            hc++;
            cbt.ChangeText(1, hc);
        }

        if (length == 2)
        {
            bc++;
            cbt.ChangeText(2, bc);
        }

        if (length == 3)
        {
            cc++;
            cbt.ChangeText(3, cc);
        }

        if (length == 4)
        {

            mc++;
            cbt.ChangeText(4, mc);
        }

    }
    public void tilePressed(int r, int c, tilePress tile)
    {
        //print("tile pressed. Row: "+r+", Col: "+c);
        if (CurentSelection == null)
            return;
        len = CurentSelection.GetComponent<Ship>().size;
        int capacity = CountOpenSpaces(board, r, c);
        if (capacity >= len)
        {
            tile.pressedOn = true;
            int curSelNum = 0;
            if (CurentSelection == Hover)
            { 
                curSelNum = hc; hc--;
                cbt.ChangeText(1, hc);
            }

            if (CurentSelection == Boat)
            { 
                curSelNum = bc; bc--;
                cbt.ChangeText(2, bc);
            }

            if (CurentSelection == Cruiser)
            { 
                curSelNum = cc; cc--;
                cbt.ChangeText(3, cc);
            }

            if (CurentSelection == Mainslayer)
            { 
                curSelNum = mc; mc--;
                cbt.ChangeText(4, mc);
            }

            if (curSelNum <= 0)
                return;
            Place(board, r, c, CurentSelection, len,tile);

            print("setting " + checkmark + " onto " + tile.gameObject);
            
            tile.SetImage(checkmark);
            //Destroy(TileActivated);
        }
    }

    void Place(Tile3D[,] board, int row, int startCol, GameObject ship, int length, tilePress tile)
    {
        // center the ship in the middle between start & end tiles
        
        GameObject startTile = board[row, startCol].gameObject;
        GameObject endTile = board[row, startCol + length - 1].gameObject;
        Vector3 midPoint = (startTile.transform.position + endTile.transform.position) / 2f;
        // Debug.Log("placing at row " + row + ", col " + startCol + " midpoint " + midPoint);
        GameObject curship = Instantiate(ship);
        tile.ShipOnTile = curship;
        tile.shipsize = length;
        curship.transform.position = midPoint;
        //print("Start tile: " + startTile + ". End Tile:" + endTile + ". Midpoint:" + midPoint);

        // mark the tiles as occupied by a ship
        for (int i = startCol; i < startCol + length; i++)
            board[row, i].ship = ship;

        // mark the adjacent tiles as required gaps between ships (length-wise)
        if (startCol > 0)
            board[row, startCol - 1].gap = true;  // adjacent space taken
        if (startCol + length < 8)
            board[row, startCol + length].gap = true;

        if (hc==0 && bc==0 && cc==0 && mc==0)
        {
            GameStartButton.SetActive(true);
            PlayButtonSlideIn pb;
            pb= GameStartButton.GetComponent<PlayButtonSlideIn>();
            pb.Move();
        }
    }
    int CountOpenSpaces(Tile3D[,] board, int row, int col)
    {
        int count = 0;
        for (int i = col; i < 8; i++)
        {
            if (board[row, i].ship == null && board[row, i].gap == false)
                count++;
            else
                break;  // run into occupied space
        }
        return count;
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
    public void SelectHover()
    {
        CurentSelection = Hover;

        selectedText.text = ("Selected: Hover(1)");
    }
    public void SelectBoat()
    {
        CurentSelection = Boat;

        selectedText.text = "Selected: Boat(2)";
    }
    public void SelectCruiser()
    {
        CurentSelection = Cruiser;

        selectedText.text = "Selected: Cruiser(3)";
    }
    public void SelectMainslayer()
    {
        CurentSelection = Mainslayer;
        selectedText.text = "Selected: Mainslayer(4)";
    }
}
