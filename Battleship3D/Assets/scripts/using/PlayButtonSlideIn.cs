using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonSlideIn : MonoBehaviour
{
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void Move()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        rb2D.AddForce(transform.right * 80);
    }
}
