
using UnityEngine;
using UnityEngine.AI;

public class Ennemi : Personnage
{
#region Variables (public)

	public NavMeshAgent m_pNavMeshAgent = null;

	public Personnage m_pCible = null;

	public float m_fDistanceDarret = 0.0f;

	#endregion

#region Variables (private)



	#endregion


	private void Start()
	{
		m_pNavMeshAgent.speed = m_fVitesse;
		m_pNavMeshAgent.stoppingDistance = m_fDistanceDarret;
	}

	private void Update()
	{
		if (m_pCible == null)
			return;
		// A partir d'ici, on est sûr qu'on a une cible

		BougerPersonnage();
	}

	private void LateUpdate()
	{
		if (m_pAnimator != null)
			AnimeMarche();
	}

	protected override void Attaquer()
	{

	}

	protected override void BougerPersonnage()
	{
		Vector3 tDirection = (m_pCible.transform.position - transform.position).normalized;

		RaycastHit tHit;

		if (Physics.Raycast(transform.position + Vector3.up, tDirection, out tHit, 300.0f, LayerMask.GetMask("Personnage"), QueryTriggerInteraction.Collide))
		{
			Vector3 tDestination = tHit.point - Vector3.up - (m_pNavMeshAgent.radius * tDirection /* notre largeur, vers l'arrière */);
			m_pNavMeshAgent.SetDestination(tDestination);
		}
	}

	private void AnimeMarche()
	{
		m_pAnimator.SetBool("Bouge", m_pNavMeshAgent.velocity != Vector3.zero);
	}
}
