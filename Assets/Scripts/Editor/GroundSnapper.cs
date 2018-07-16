
using UnityEngine;
using UnityEditor;

public class GroundSnapper : MonoBehaviour
{
#region Variables (public)



	#endregion

#region Variables (private)



	#endregion


	[MenuItem("Tools/Snap To Ground %g")]
	static public void SnapToGround()
	{
		Transform[] pSelection = Selection.transforms;

		for (int i = 0; i < pSelection.Length; ++i)
		{
			Transform pCurrentTransform = pSelection[i];

			RaycastHit[] tHits = Physics.RaycastAll(pCurrentTransform.position + (Vector3.up * 10.0f), Vector3.down, 200.0f, LayerMask.GetMask("Sol"));

			for (int j = 0; j < tHits.Length; ++j)
			{
				if (tHits[j].collider.gameObject == pCurrentTransform.gameObject)
					continue;

				pCurrentTransform.position = tHits[j].point;
				break;
			}
		}
	}
}
