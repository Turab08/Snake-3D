using UnityEngine;

public class Apple : MonoBehaviour
{
    public int value;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Respawn();
            CollectApple();
        }
    }


    void CollectApple()
    {
        Destroy(gameObject);
        SnakeManager.Instance.Grow();
        Score.Instance.AddScore(value);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.apple);
    }

    void Respawn()
    {
        int xPos = Random.Range(-11, 11);
        int zPos = Random.Range(-11, 11);

        GameObject newApple = Instantiate(gameObject);
        newApple.transform.position = new Vector3(xPos, 1, zPos);
    }
}
