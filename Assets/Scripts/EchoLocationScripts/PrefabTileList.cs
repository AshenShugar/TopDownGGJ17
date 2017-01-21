using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTileList : MonoBehaviour {

	// Have to keep this list seperate from the TileInfo script as otherwise prefabs end up pointing at themselves which screws things up.
	public GameObject[] PossibleTiles;

}
