
using UnityEngine;

public class CameraPersonnage : MonoBehaviour
{
#region Variables (public)

	public PersonnageJoueur m_pTarget = null;

	public float m_fDistanceDeSuivi = 0.0f;

	#endregion

#region Variables (private)



	#endregion


	private void LateUpdate()
	{
		if (m_pTarget != null)
			SuivrePersonnage();
	}

	private void SuivrePersonnage()
	{
		Vector3 tNouvellePosition = m_pTarget.transform.position + Vector3.up - (transform.forward * m_fDistanceDeSuivi);
		transform.position = tNouvellePosition;
	}
}
