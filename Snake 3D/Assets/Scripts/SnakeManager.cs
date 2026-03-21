using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeManager : MonoBehaviour
{
    public static List<Vector3> posHistory = new List<Vector3>();
    public List<SnakeBody> bodyParts = new List<SnakeBody>();
    [SerializeField] GameObject bodyPart;

    public float delayTime = 0.5f;
    [SerializeField] float moveTime = 0.5f;
    public float moveTile = 1;

    Vector3 direction = Vector3.forward;

    public static bool stepHappened;

    public static SnakeManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        posHistory.Clear();

        for (int i = 0; i < 100; i++)
        {
            posHistory.Add(transform.position - direction * moveTile * i);
        }
    }

    void Update()
    {
        HandleMovement();
        HandleInput();
    }

    void HandleMovement()
    {
        moveTime -= Time.deltaTime;
        if (moveTime <= 0)
        {
            Move();
            moveTime = delayTime;
        }
        else
        {
            stepHappened = false;
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector3.forward;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector3.back;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector3.left;
        }
        transform.rotation = Quaternion.LookRotation(direction);
    }

    void Move()
    {
        transform.position += direction * moveTile;
        posHistory.Insert(0, transform.position);

        int maxHistory = 100;
        if (posHistory.Count > maxHistory) {
            posHistory.RemoveAt(posHistory.Count - 1);
        }

        stepHappened = true;
        AudioManager.Instance.PlaySFX(AudioManager.Instance.walk);
    }

    public void Grow()
    {
        GameObject newPart = Instantiate(bodyPart);

        SnakeBody snakeBody = newPart.GetComponent<SnakeBody>();

        bodyParts.Add(snakeBody);

        snakeBody.SetIndex(bodyParts.Count);

        newPart.transform.position = posHistory[bodyParts.Count];
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("SnakeBody"))
        {
            GameManager.Instance.SetState(GameManager.GameState.GameOver);
        }
    }
}
