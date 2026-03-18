using System.Collections;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float moveTime = 1f;
    public float moveTile = 1;

    [SerializeField] Transform bodyParent;

    void Update()
    {
        moveTime -= Time.deltaTime;
        if (moveTime <= 0)
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            StartCoroutine(AdjustBody());
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 90, transform.rotation.z);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, -90, transform.rotation.z);
        }
    }
    void Move()
    {
        transform.position += transform.forward * moveTile;
        moveTime = 0.5f;
    }

    IEnumerator AdjustBody()
    {
        foreach (Transform child in bodyParent)
        {
            child.transform.localRotation = gameObject.transform.rotation;
            yield return new WaitForSeconds(moveTime);
        }
    }
}
