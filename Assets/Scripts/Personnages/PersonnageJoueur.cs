﻿
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
			m_pArme.Attaquer();
	}
}