using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if (other.TryGetComponent(out ICollectable collectable))
        {
            collectable.Collect();
        }
    }
}
