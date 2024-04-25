
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public GameObject player;
    public float speed = 1f;
    public AudioSource explode;
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < 10f) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            explode.Play();
            Destroy(gameObject, 1f);
        }
    }
}
