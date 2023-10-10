using UnityEngine;


public class ChunkPlayerTest : MonoBehaviour
{
	public LayerMask GroundLayer;

	public GameObject GetPlayerPosition()
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position, Vector3.down * 3, out hit, GroundLayer))
		{
            return hit.transform.gameObject;
        }
		else
		{
			return null;
		}
	}
}
