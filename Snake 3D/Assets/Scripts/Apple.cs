using UnityEngine;

public class Apple : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Respawn();
            Destroy(gameObject);
            SnakeManager.Instance.Grow();
        }
    }

    void Respawn()
    {
        int xPos = Random.Range(-11, 11);
        int zPos = Random.Range(-11, 11);

        GameObject newApple = Instantiate(gameObject);
        newApple.transform.position = new Vector3(xPos, 1, zPos);
    }
}
