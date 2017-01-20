using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTile : MonoBehaviour {

    public int TileX
    {
        get
        {
            return ((int)Mathf.Round(transform.position.x));
        }
    }

    public int TileY
    {
        get
        {
            return ((int)Mathf.Round(transform.position.y));
        }
    }

    // Use this for initialization
    void Start () {
        if (WorldController.instance != null)
        {
            //WorldController.instance.tileIds[TileX, TileY] = 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    void OnDestroy()
    {
        
        if (WorldController.instance != null)
        {
            //WorldController.instance.tileIds[TileX, TileY] = 0;
        }
    }
}
