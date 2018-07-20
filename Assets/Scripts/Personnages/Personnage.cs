
using UnityEngine;

abstract public class Personnage : MonoBehaviour
{
#region Variables (public)

	public Arme m_pArme = null;
	public Animator m_pAnimator = null;

	public float m_fPointsDeVie = 0.0f;

	public float m_fVitesse = 0.0f;

	#endregion

#region Variables (private)



	#endregion


	abstract protected void BougerPersonnage();

	/// <summary>
	/// Lance l'attaque de mon arme si elle existe
	/// </summary>
	virtual protected void Attaquer()
	{
		m_pArme?.Attaquer();
	}
}
