using UnityEngine;

// instead of crazy arcs, have two waypoints for targeting
public class PlayerMissile : MonoBehaviour
{
    public GameObject target;
    public GameObject smoke;
    Vector3 origin;
    bool launched = false;
    GameManager gm;

    void Start()
    {
        // so the tail doesn't start growing until we need it
        smoke.SetActive(false);
        origin = transform.position;
        gm = GameObject.Find("GameKeeper").GetComponent<GameManager>();
    }

    public void Launch()
    {        
        launched = true;
        smoke.SetActive(true);
    }

    void Update()
    {
        if (!launched)
            return;

        Vector3 dir = target.transform.position - transform.position;
        if (dir.magnitude <= 1f)
        {
            launched = false;
            gm.MissileLanded();     // check, hit or miss

            smoke.SetActive(false);
            transform.position = origin;
        }

        transform.LookAt(target.transform);  // <- will give us cuved motion
        transform.Translate(dir.normalized * 1.5f); 
    }

}
