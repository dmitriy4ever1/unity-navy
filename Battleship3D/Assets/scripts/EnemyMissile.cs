using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    public GameObject smoke;
    public AudioClip missSound, hitSound;

    AudioSource player;

    GameManager gm;
    bool launched = false;
    Vector3 origin;
    int r;
    GameObject target;

    void Start()
    {
        origin = transform.position;
        smoke.SetActive(false);
        gm = GameObject.Find("GameKeeper").GetComponent<GameManager>();
        player = gameObject.AddComponent<AudioSource>();
        player.volume = 0.5f;
    }

    public void Launch(GameObject tgt)
    {
        target = tgt;
        launched = true;
        smoke.SetActive(true);
    }
    
    // swing in a nice arc
    void Update()
    {
        if (!launched)
            return;

        Vector3 dir = target.transform.position - transform.position;
        if (dir.magnitude <= 1f)  // reached the target
        {
            launched = false;
            smoke.SetActive(false);
            transform.position = origin; // reset to starting point

            Tile3D hitPoint = target.GetComponent<Tile3D>();
            hitPoint.Mark();    // hit or miss   
            if (hitPoint.ship != null)
                player.PlayOneShot(hitSound);
            else
                player.PlayOneShot(missSound);
        }
        else
        {
          // transform.LookAt(target.transform, Vector3.up);  // will give us ached movement
           transform.Translate(dir.normalized * 2f);
        }
    }
   
}
