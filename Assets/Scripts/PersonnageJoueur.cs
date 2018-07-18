
using UnityEngine;

public class PersonnageJoueur : MonoBehaviour
{
#region Variables (public)

	public Rigidbody m_pMonRigidBody = null;

	public float m_fPointsDeVie = 0.0f;

	public float m_fVitesse = 0.0f;
	public float m_fVitesseDeSaut = 0.0f;

	#endregion

#region Variables (private)



	#endregion


	private void Update()
	{
		BougerPersonnage();
		Sauter();
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
			m_pMonRigidBody.MovePosition(transform.position + tDeplacement);

			transform.forward = tDirection;
		}
	}

	private void Sauter()
	{
		if (Input.GetButtonDown("Jump"))
		{
			Vector3 tSaut = Vector3.up * m_fVitesseDeSaut;
			m_pMonRigidBody.AddForce(tSaut, ForceMode.Impulse);
		}
	}
}
