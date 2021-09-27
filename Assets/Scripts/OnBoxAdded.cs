using System.Diagnostics.Tracing;
using System;
using UnityEngine;
public class OnBoxAdded : MonoBehaviour, ICollectable
{
    private BlockStack blockStack;
    private InputManager InputManager;
    private Transform character;
    private Camera gameCamera;

    #region Methods
    void Start()
    {
        blockStack = FindObjectOfType<BlockStack>();
        InputManager = FindObjectOfType<InputManager>();
        character = InputManager.transform.GetChild(0);
    }
    public void Collect()
    {
        if (!blockStack) return;

        bool blockAdded = blockStack.AddBoxToStack(this.gameObject);
        if (blockAdded)
        {
            RePositionBlock();
        }
    }
    private void RePositionBlock()
    {
        //Blocks Go Under Input Manager
        transform.SetParent(character.transform);
        character.localPosition += Vector3.up * 1.1f;
        print("Block List Count " + blockStack.boxList.Count);
        transform.localPosition = new Vector3(0, ((blockStack.boxList.Count) * -1.1f), 0);
        Camera.main.fieldOfView += 2.5f;
        Camera.main.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y, (Camera.main.transform.localPosition.z - .1f));
        Destroy(this);
    }
    #endregion
}
