using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TileInfo : MonoBehaviour {

	private PrefabTileList PTL;

	private PrefabTileList GetPTL {
		get {
			if (PTL == null) {
				Debug.Log ("Couldn't find it");
				PTL = FindObjectOfType<PrefabTileList> ();
			} else {
				Debug.Log ("Found it");
			}
			return PTL;
		}
	}


	public void Update()
	{

	}


	public int TileCount()
	{
		return GetPTL.PossibleTiles.Length;
	}

	public GameObject LookAtNewTile(int index)
	{
		return GetPTL.PossibleTiles [index];
	}

	public GameObject GetNewTile(int index)
	{
		return (GameObject)PrefabUtility.InstantiatePrefab (GetPTL.PossibleTiles [index]);
	}

}
