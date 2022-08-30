using System.Collections;
using UnityEngine;

public class SeaSaw : MonoBehaviour
{
    [Range(5,20)]
    public float degrees = 15;
    [Range(0.1f, 5f)]
    public float frequency = 0.5f;
    [Range(0f, 0.5f)]
    public float fwdSpeed = 1f;

    float leanRight, leanLeft;

    private float dir = 1f;
    // Start is called before the first frame update
    void Start()
    {
        // split leaning half-way across vertical
        leanRight = degrees / 2f;
        leanLeft = -leanRight; 
        StartCoroutine("Swing");          // for smooth animation        
    }

    IEnumerator Swing()
    {
        while (true)
        {
            dir = -dir;
            float i = 0;

            while (i < leanRight)
            {
                transform.Rotate(new Vector3(0f, 0f, frequency * dir));
                i++;
                yield return new WaitForSeconds(0.1f);
            }
            while (i > leanLeft)
            {
                transform.Rotate(new Vector3(0f, 0f, frequency * -dir));
                i--;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * -fwdSpeed * Time.deltaTime);
    }
}
