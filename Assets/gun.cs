using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class gun : MonoBehaviour {


	public int theDamage;
	public ParticleSystem muzzle;
	public ParticleSystem trail;
	public AudioClip fire;
	public AudioSource src;
	public float waitTime;
	public Text txt;
	public bool canwin;
	// Use this for initialization
	void Start () {
		StartCoroutine (Win());
		canwin = true;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		EnemyHealth healthComponent;

		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2,0));

		if(Input.GetMouseButtonDown(0))
		{
			muzzle.Emit (Random.Range (0, 60));
			trail.Emit (1);
			src.PlayOneShot (fire);
			if(Physics.Raycast(ray,out hit,100))
			{
				// gets a reference to the component!
				healthComponent = hit.collider.GetComponent<EnemyHealth>();

				// just for safety: Check that you actually found EnemyHealth component on the raycast hit, if not do not proceed
				if (healthComponent == null)
					return;

				healthComponent.ApplyDamage(theDamage);

			}
		}
	}
	IEnumerator Win()
	{
		
		yield return new WaitForSeconds(10);
		if(canwin)
		txt.gameObject.SetActive (true);
		yield return new WaitForSeconds (4);
		if(canwin)
		Application.LoadLevel(Application.loadedLevel);
	}
}
