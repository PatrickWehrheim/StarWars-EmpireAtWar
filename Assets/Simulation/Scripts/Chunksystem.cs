using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunksystem : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> _planes = new List<GameObject>();
	[SerializeField]
	private ChunkPlayerTest _player;

	private void FixedUpdate()
	{
		GameObject plane = _player.GetPlayerPosition();
		InitChunks(plane);
	}

	private void InitChunks(GameObject plane)
	{
		if (!_planes.Contains(plane))
			return;

		int index = _planes.FindIndex(x => x.gameObject == plane);

		for (int i = 0; i < _planes.Count; i++)
		{
			if (index != i && index + 1 != i && index + 2 != i)
			{
                _planes[i].gameObject.SetActive(false);
            }
			else
			{
				_planes[i].gameObject.SetActive(true);
			}
		}
	}
}
