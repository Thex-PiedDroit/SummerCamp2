
using UnityEngine;

public class PersonnageJoueur : Personnage
{
#region Variables (public)

	public Rigidbody m_pMonRigidBody = null;

	public float m_fVitesseDeSaut = 0.0f;

	#endregion

#region Variables (private)



	#endregion


	private void Update()
	{
		BougerPersonnage();
		Sauter();
		Attaquer();
	}

	override protected void BougerPersonnage()
	{
		float fHorizontal = Input.GetAxis("Horizontal");
		float fVertical = Input.GetAxis("Vertical");

		Vector3 tDirection = new Vector3(fHorizontal, 0.0f, fVertical);

		if (tDirection != Vector3.zero)
		{
			tDirection = CameraPersonnage.Instance.transform.TransformDirection(tDirection);
			tDirection.y = 0.0f;

			if (tDirection.sqrMagnitude != 0.0f)
				tDirection.Normalize();
			else
				tDirection = transform.forward;

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

	override protected void Attaquer()
	{
		if (Input.GetButton("Fire1"))
		{
			Vector3 tDirectionDattaque = Input.mousePosition;	// On stock la position de la souris

			tDirectionDattaque.x /= Screen.width;				// On transforme de (x=1920, y=1080) à (x=1, y=1)
			tDirectionDattaque.y /= Screen.height;

			tDirectionDattaque -= new Vector3(0.5f, 0.5f, 0.0f);	// On le prend par rapport au centre de l'écran (donc (x=0.5, y=0.5))

			tDirectionDattaque.z = tDirectionDattaque.y;			// On échange le y et le z
			tDirectionDattaque.y = 0.0f;

			tDirectionDattaque = CameraPersonnage.Instance.transform.TransformDirection(tDirectionDattaque);	// On transforme la direction de l'espace monde à l'espace caméra
			tDirectionDattaque.y = 0.0f;		// On applatit la direction pour pas qu'il regarde vers le haut

			if (tDirectionDattaque != Vector3.zero)
				transform.forward = tDirectionDattaque.normalized;

			m_pArme.Attaquer();
		}
	}
}
