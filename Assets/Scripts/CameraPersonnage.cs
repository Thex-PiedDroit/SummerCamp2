
using UnityEngine;

public class CameraPersonnage : MonoBehaviour
{
#region Variables (public)

	static public CameraPersonnage Instance = null;

	public PersonnageJoueur m_pTarget = null;

	public Camera m_pCamera = null;

	public float m_fDistanceDeSuivi = 0.0f;
	public float m_fVitesseDeRotation = 0.0f;

	#endregion

#region Variables (private)



	#endregion


	private void Awake()
	{
		if (CameraPersonnage.Instance != null)
		{
			if (CameraPersonnage.Instance != this)
			{
				Debug.LogError("Attention, il y a deux CameraPersonnage dans la scene");
				Destroy(this);
			}

			return;
		}

		CameraPersonnage.Instance = this;
	}

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
		Vector3 tNouvellePositionCamera = m_pTarget.transform.position + Vector3.up - (transform.forward * m_fDistanceDeSuivi);
		transform.position = tNouvellePositionCamera;
	}

	private void TournerCamera()
	{
		float fSourisX = Input.GetAxis("Mouse X");

		if (fSourisX != 0.0f)
			transform.RotateAround(m_pTarget.transform.position, Vector3.up, fSourisX * (m_fVitesseDeRotation * Time.deltaTime));


		float fSourisY = Input.GetAxis("Mouse Y");

		if (fSourisY != 0.0f)
			transform.RotateAround(m_pTarget.transform.position, transform.right, -fSourisY * (m_fVitesseDeRotation * Time.deltaTime));
	}
}
