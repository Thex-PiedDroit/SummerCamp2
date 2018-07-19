
using UnityEngine;

public class ArmeADistance : Arme
{
#region Variables (public)

	public GameObject m_pPrefabDeProjectile = null;

	public Transform m_pOrigineDeTir = null;

	#endregion

#region Variables (private)



	#endregion


	override public void Attaquer()
	{
		Instantiate(m_pPrefabDeProjectile, m_pOrigineDeTir.position, m_pOrigineDeTir.rotation);
	}
}
