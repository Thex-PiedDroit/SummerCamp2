
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTitre : MonoBehaviour
{
#region Variables (public)

	public string m_sNomDeLaSceneDeJeu = null;

	#endregion

#region Variables (private)



	#endregion


	public void LancerJeu()
	{
		SceneManager.LoadScene(m_sNomDeLaSceneDeJeu);
	}

	public void QuitterJeu()
	{
		Application.Quit();
	}
}
