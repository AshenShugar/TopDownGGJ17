using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(TileInfo))] 
public class EditorLevelMaker: Editor {


	private Vector3 NewTileLocation;
	private bool LayingNewTile = false;

	void OnSceneGUI()
	{
		TileInfo CurrentObj = (TileInfo)target;

		if(CurrentObj != null)
		{
			Quaternion directionA = Quaternion.LookRotation (Vector3.left);
			Quaternion directionB = Quaternion.LookRotation (Vector3.right);
			Quaternion directionC = Quaternion.LookRotation (Vector3.up);
			Quaternion directionD = Quaternion.LookRotation (Vector3.down);
			GameObject tmp = CurrentObj.gameObject;

			if (!LayingNewTile) {
				if (Handles.Button (CurrentObj.transform.position + Vector3.left, directionA, 0.5f, 0.5f, Handles.ConeCap)) {
					NewTileLocation = CurrentObj.transform.position + Vector3.left * CurrentObj.transform.localScale.x;
					LayingNewTile = true;
				} else if (Handles.Button (CurrentObj.transform.position + Vector3.right, directionB, 0.5f, 0.5f, Handles.ConeCap)) {
					NewTileLocation = CurrentObj.transform.position + Vector3.right * CurrentObj.transform.localScale.x;
					LayingNewTile = true;
				} else if (Handles.Button (CurrentObj.transform.position + Vector3.up, directionC, 0.5f, 0.5f, Handles.ConeCap)) {
					NewTileLocation = CurrentObj.transform.position + Vector3.up * CurrentObj.transform.localScale.y;
					LayingNewTile = true;
				} else if (Handles.Button (CurrentObj.transform.position + Vector3.down, directionD, 0.5f, 0.5f, Handles.ConeCap)) {
					NewTileLocation = CurrentObj.transform.position + Vector3.down * CurrentObj.transform.localScale.y;
					LayingNewTile = true;
				}

				if (Handles.Button (CurrentObj.transform.position + Vector3.left * 2, directionA, 1f, 1f, Handles.ConeCap)) {
					NewTileLocation = CurrentObj.transform.position + Vector3.left * CurrentObj.transform.localScale.x;
					tmp = CurrentObj.GetNewTile (CurrentObj.ThisTilesIndex);
					tmp.GetComponent<TileInfo> ().ThisTilesIndex = CurrentObj.ThisTilesIndex;
					tmp.transform.position = NewTileLocation;
					Selection.activeObject = tmp;
					tmp.name = (CurrentObj.LookAtNewTile(CurrentObj.ThisTilesIndex)).name;
					tmp.transform.SetParent (CurrentObj.gameObject.transform.parent);

				} else if (Handles.Button (CurrentObj.transform.position + Vector3.right * 2, directionB, 1f, 1f, Handles.ConeCap)) {
					NewTileLocation = CurrentObj.transform.position + Vector3.right * CurrentObj.transform.localScale.x;

					tmp = CurrentObj.GetNewTile (CurrentObj.ThisTilesIndex);
					tmp.GetComponent<TileInfo> ().ThisTilesIndex = CurrentObj.ThisTilesIndex;

					tmp.transform.position = NewTileLocation;
					Selection.activeObject = tmp;
					tmp.name = (CurrentObj.LookAtNewTile(CurrentObj.ThisTilesIndex)).name;
					tmp.transform.SetParent (CurrentObj.gameObject.transform.parent);
				} else if (Handles.Button (CurrentObj.transform.position + Vector3.up * 2 , directionC, 1f, 1f, Handles.ConeCap)) {
					NewTileLocation = CurrentObj.transform.position + Vector3.up * CurrentObj.transform.localScale.y;
					tmp = CurrentObj.GetNewTile (CurrentObj.ThisTilesIndex);
					tmp.GetComponent<TileInfo> ().ThisTilesIndex = CurrentObj.ThisTilesIndex;

					tmp.transform.position = NewTileLocation;
					Selection.activeObject = tmp;
					tmp.name = (CurrentObj.LookAtNewTile(CurrentObj.ThisTilesIndex)).name;
					tmp.transform.SetParent (CurrentObj.gameObject.transform.parent);
				} else if (Handles.Button (CurrentObj.transform.position + Vector3.down * 2, directionD, 1f, 1f, Handles.ConeCap)) {
					NewTileLocation = CurrentObj.transform.position + Vector3.down * CurrentObj.transform.localScale.y;

					tmp = CurrentObj.GetNewTile (CurrentObj.ThisTilesIndex);
					tmp.GetComponent<TileInfo> ().ThisTilesIndex = CurrentObj.ThisTilesIndex;

					tmp.transform.position = NewTileLocation;
					Selection.activeObject = tmp;
					tmp.name = (CurrentObj.LookAtNewTile(CurrentObj.ThisTilesIndex)).name;
					tmp.transform.SetParent (CurrentObj.gameObject.transform.parent);
				}

			}
			if(LayingNewTile)
			{
				Rect guiArea = new Rect (0, 0, 200, 200);

				GUILayout.BeginArea (guiArea);

				for (int i = 0; i < CurrentObj.TileCount(); i++) {
					if (GUILayout.Button (CurrentObj.LookAtNewTile(i).name)) {
						LayingNewTile = false;
						tmp = CurrentObj.GetNewTile (i);
						tmp.GetComponent<TileInfo> ().ThisTilesIndex = i;
                        EditorSceneManager.MarkSceneDirty( EditorSceneManager.GetActiveScene() );
						tmp.transform.position = NewTileLocation;

						Selection.activeObject = tmp;
						tmp.name = (CurrentObj.LookAtNewTile(i)).name;
						tmp.transform.SetParent (CurrentObj.gameObject.transform.parent);
					}
				}
				GUILayout.EndArea ();
			}
		}
	}
}
