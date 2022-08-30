using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeButtonTxt : MonoBehaviour
{
    public Text hoverText;
    public Text boatText;
    public Text cruiserText;
    public Text mainslayerText;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ChangeText(int size, int amount)
    {
        if (amount < 0)
            amount = 0;
        if (size == 1)
            hoverText.text = ("Hover(Size: 1) " + amount);
        if (size == 2)
            boatText.text = ("Boat(Size: 2) " + amount);
        if (size == 3)
            cruiserText.text = ("Cruiser(Size: 3) " + amount);
        if (size == 4)
            mainslayerText.text = ("Mainslayer(Size: 4) " + amount);
    }
}
