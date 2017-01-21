using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TileInfo : MonoBehaviour {

	private PrefabTileList PTL;

	public int ThisTilesIndex = -1;

	private PrefabTileList GetPTL {
		get {
			if (PTL == null) {
				PTL = FindObjectOfType<PrefabTileList> ();
				if (PTL == null) {
					Debug.Log ("Unable to find PrefabTileList script on an object.  Level editing won't work properly");
				}
			}
			return PTL;
		}
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
