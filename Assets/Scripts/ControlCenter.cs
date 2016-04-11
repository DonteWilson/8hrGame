using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ControlCenter : MonoBehaviour {
    // Use this for initialization
    //Sets Vector2 direction to equal right
    Vector2 d = Vector2.right;
    
    //Sets bool obtain to false;
    bool obtain = false;

    public GameObject FollowerPrefab;
    //Stores the last position of the follower into a list.
    List<Transform> Follower = new List<Transform>();

    void Start()
    {
        //Repeats this every repeatRate seconds, creates the feel of the object movbin
        InvokeRepeating("Navigate", 0.3f, 0.4f);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            d = -Vector2.right;
        //Moves the leader is the right position
        else if (Input.GetKey(KeyCode.RightArrow))
            //switches direction to right
            d = Vector2.right;
        //Switches Vector2 up to negative, so it brings the follower down.
        else if (Input.GetKey(KeyCode.DownArrow))
            //switches direction to up
            d = -Vector2.up;
        //Moves the leader is the up position
        else if (Input.GetKey(KeyCode.UpArrow))
            //Switches direction to up
            d = Vector2.up;

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        //Checks to see if Leader collides with Follower
        if (coll.name.StartsWith("SaberPrefab"))
            //When the leader collides he obtains a follower.
            obtain = true;

        Destroy(coll.gameObject);
    }
       
  
    

    void Navigate()
    {
        Vector2 v = transform.position;
        transform.Translate(d);
        if(obtain)
        {
            GameObject GO = (GameObject)Instantiate(FollowerPrefab, v, Quaternion.identity);

            Follower.Insert(0, GO.transform);

            obtain = false;
        }
        else if(Follower.Count > 0)
        {
            Follower.Last().position = v;

            Follower.Insert(0, Follower.Last());
            Follower.RemoveAt(Follower.Count - 1);
        }
    }
      
}
