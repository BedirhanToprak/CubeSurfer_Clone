using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBoxRemoved : MonoBehaviour
{
    private BlockStack blockStack;
    void Start()
    {
        blockStack = FindObjectOfType<BlockStack>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            blockStack.RemoveBoxToStack(this.gameObject);
            Destroy(this);
        }
        if (collision.gameObject.CompareTag("GroundObstacle"))
        {
            blockStack.RemoveBoxToStack(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
