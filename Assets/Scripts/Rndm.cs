using UnityEngine;
using System.Collections;

public class Rndm: MonoBehaviour
{
    public GameObject SaberPrefab;

    public Transform TopBorder;

    public Transform LeftBorder;

    public Transform RightBorder;

    public Transform BottomBorder;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Poof", 3, 4);
    }

    void Poof()
    {
        int x = (int)Random.Range(LeftBorder.position.x, RightBorder.position.x);

        int y = (int)Random.Range(TopBorder.position.y, BottomBorder.position.y);

        Instantiate(SaberPrefab, new Vector2(x, y), Quaternion.identity); 
    }

    
  
}

	
	

