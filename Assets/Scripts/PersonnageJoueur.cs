
using UnityEngine;

public class PersonnageJoueur : MonoBehaviour
{
#region Variables (public)

	public float m_fPointsDeVie = 0.0f;

	public float m_fVitesse = 0.0f;

	#endregion

#region Variables (private)



	#endregion


	private void Update()
	{
		BougerPersonnage();
	}

	private void BougerPersonnage()
	{
		float fHorizontal = Input.GetAxis("Horizontal");
		float fVertical = Input.GetAxis("Vertical");

		Vector3 tDirection = new Vector3(fHorizontal, 0.0f, fVertical);

		if (tDirection != Vector3.zero)
		{
			tDirection.Normalize();

			Vector3 tDeplacement = tDirection * (m_fVitesse * Time.deltaTime);
			transform.position += tDeplacement;

			transform.forward = tDirection;
		}
	}
}
