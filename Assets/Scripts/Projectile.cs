using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed;
	public float damage;
	public float knockback;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate ( Vector3.right * speed * Time.deltaTime );
	}
	
	void OnTriggerEnter2D ( Collider2D coll )  {
		Attacker attacker = coll.gameObject.GetComponent<Attacker>();
		Health health = coll.gameObject.GetComponent<Health>();
		
		if ( attacker && health ) {
			attacker.transform.Translate ( Vector3.right * knockback * Time.deltaTime);
			health.DealDamage(damage);
			Destroy (gameObject);
		}
	}

}
