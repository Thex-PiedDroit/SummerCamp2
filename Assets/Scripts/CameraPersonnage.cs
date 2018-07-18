
using UnityEngine;

public class CameraPersonnage : MonoBehaviour
{
#region Variables (public)

	public PersonnageJoueur m_pTarget = null;
	public Transform m_pCameraTransform = null;

	public float m_fDistanceDeSuivi = 0.0f;

	#endregion

#region Variables (private)



	#endregion


	private void Update()
	{
		TournerCamera();
	}

	private void LateUpdate()
	{
		if (m_pTarget != null)
			SuivrePersonnage();
	}

	private void SuivrePersonnage()
	{
		Vector3 tNouvellePositionPoint = m_pTarget.transform.position + Vector3.up;
		transform.position = tNouvellePositionPoint;

		Vector3 tNouvellePositionCamera = tNouvellePositionPoint - (m_pCameraTransform.forward * m_fDistanceDeSuivi);
		m_pCameraTransform.position = tNouvellePositionCamera;
	}

	private void TournerCamera()
	{
		float fSourisX = Input.GetAxis("Mouse X");

		if (fSourisX != 0.0f)
		{
			Vector3 tRotation = new Vector3(0.0f, fSourisX, 0.0f);
			transform.eulerAngles += tRotation;
		}


		float fSourisY = Input.GetAxis("Mouse Y");

		if (fSourisY != 0.0f)
		{
			Vector3 tRotation = new Vector3(-fSourisY, 0.0f, 0.0f);

			Vector3 tRotationSiAjoutee = transform.eulerAngles + tRotation;

			if (tRotationSiAjoutee.x <= 55.0f && tRotationSiAjoutee.x >= 0.0f)
				transform.eulerAngles = tRotationSiAjoutee;
		}
	}
}
