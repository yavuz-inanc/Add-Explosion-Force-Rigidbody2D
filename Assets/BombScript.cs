using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private float explosionForce = 300;
    public CircleCollider2D explosionCollider;
    public Sprite effect;
    List <GameObject> currentCollisions = new List <GameObject> ();
    
    private void Start()
    {
        StartCoroutine(ActivateTheBomb());
    }

    void OnTriggerEnter2D (Collider2D other) {
        currentCollisions.Add (other.gameObject);
    }
 
    void OnTriggerExit2D (Collider2D other) {
        currentCollisions.Remove (other.gameObject);
    }

    IEnumerator ActivateTheBomb()
    {
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<SpriteRenderer>().sprite = effect;
        
        foreach (GameObject gObject in currentCollisions) {
            gObject.GetComponent<Rigidbody2D>().AddExplosionForce(
                explosionForce, transform.position, explosionCollider.radius);
        }

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
