using UnityEngine;

public class HurtEnemey : MonoBehaviour
{
    public GameObject lootDrop;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Instantiate(lootDrop, transform.position, Quaternion.identity);
        }
    }
}
