using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tilePress : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerSetupManager;
    public int c;
    public int r;
    static PlayerSetup ps;
    [HideInInspector]
    public Image checkmark;
    public Sprite og;
    [HideInInspector]
    public bool pressedOn = false;
    [HideInInspector]
    public GameObject ShipOnTile;
    [HideInInspector]
    public int shipsize;
    void Start()
    {
        ps=playerSetupManager.GetComponent<PlayerSetup>();
    }

    // Update is called once per frame
    public void pressed()
    {
        // print("Pressed " + r + ", " + c);
        if (pressedOn)
        {
            ps.tileUnpressed(c, r, this,shipsize);
            pressedOn = false;
            SetImageBack();
        }
        else
            ps.tilePressed(c, r, this);
        
    }

    public void SetImageBack()
    {
        Button b = gameObject.GetComponent<Button>();
        b.image.sprite = og;
        b.image.color = Color.white;
    }

    public void SetImage(Sprite img)
    {
        Button b = gameObject.GetComponent<Button>();
        b.image.sprite = img;
        b.image.color = Color.blue;
    }

    

}
