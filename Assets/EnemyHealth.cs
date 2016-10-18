using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityStandardAssets.Characters.FirstPerson;
public class EnemyHealth : MonoBehaviour
{
	public int health = 100;
	public GameObject JailCell;
	public Text txt;
	public gun gun;

	void Start() {
		JailCell.SetActive (false);
	}
	void Update()
	{
		if (health <= 0)
		{
			Dead ();
			StartCoroutine (restart());
		}
	}
	public void ApplyDamage(int damageToTake)
	{
		damageToTake = 100;
		health -= damageToTake;
	}
	void Dead()
	{
		transform.Rotate(Vector3.left);
		JailCell.SetActive(true);
		txt.gameObject.SetActive (true);
		GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = false;
		gun.canwin = false;
	}
	IEnumerator restart()
	{
		yield return new  WaitForSeconds (4);
		Application.LoadLevel(Application.loadedLevel);
	}
}
