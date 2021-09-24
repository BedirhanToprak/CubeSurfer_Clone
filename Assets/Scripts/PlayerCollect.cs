using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.CompareTag("GoodDoor"))
        {
            anim.SetLayerWeight(1, 1);
            anim.Play("UpperBody.dance", 1, .25f);
            Invoke("setAnimLayerWeightZero", 2.3f);
        }
        /* if (other.TryGetComponent(out ICollectable collectable))
            {
                collectable.Collect(this.transform);
            }
            else if (other.TryGetComponent(out IDoors door))
            {
                door.OpenDoor(this.transform);

            }*/

    }
    void setAnimLayerWeightZero()
    {
        anim.SetLayerWeight(1, 0);
    }
}
