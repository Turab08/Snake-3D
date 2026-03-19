using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    int index = 1;

    public void SetIndex(int i)
    {
        index = i;
    }

    void Update()
    {
        if (SnakeManager.stepHappened == true)
        {
            FollowHead();
        }
    }

    void FollowHead()
    {
        if (SnakeManager.posHistory.Count > index) {
            transform.position = SnakeManager.posHistory[index];
        }
    }
}
