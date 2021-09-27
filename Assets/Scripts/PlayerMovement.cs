using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[SelectionBase]
public class PlayerMovement : MonoBehaviour
{
    //Ref
    [SerializeField] public Animator playerAnimator;
    [SerializeField] private InputManager InputManager;
    [SerializeField] private Transform[] checkPoints;
    [SerializeField] private GameObject levelEndUi;
    [SerializeField] private Transform pointAB;
    [SerializeField] private Transform pointBC;
    private Transform inputManagerObj;
    private Transform target;
    private Transform pointA;
    private Transform pointB;
    private Transform pointC;

    //Config
    [SerializeField] public float speed;
    private float interpolateAmount;
    private int index;

    //State 
    public bool isGameStart;
    private bool isLevelEnd;
    private bool isTurning;
    private bool isGoing;

    private void Start()
    {
        isGoing = true;
        index = 0;
        target = checkPoints[index];
        inputManagerObj = InputManager.gameObject.transform;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerAnimator.SetBool("isGameStart", true);
            isGameStart = true;
        }


        FollowPath();
        TurningHandler();
    }
    private void FollowPath()
    {
        if (isGoing && isGameStart)
        { transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime); }

        if (transform.position == target.position && !(index < checkPoints.Length))
        {
            //TODO Level end things below here
            // viewerUi.SetActive(false);
            isLevelEnd = true;
            Destroy(InputManager);
            // Invoke("ShowLevelEndUi", 1f);
        }
        else if (transform.position == target.position)
        {
            if (target.CompareTag("Corner"))
            {
                pointA = target;
                index++;
                pointB = checkPoints[index];
                index++;
                pointC = checkPoints[index];
                isGoing = false;
                isTurning = true;
            }
            else
            {
                index++;
                target = checkPoints[index];
            }
        }
    }
    private void ShowLevelEndUi()
    {
        levelEndUi.SetActive(true);
        Destroy(this);
    }
    private void TurningHandler()
    {
        if (isTurning)
        {
            interpolateAmount = ((interpolateAmount + Time.deltaTime)) % 1;
            pointAB.position = Vector3.Lerp(pointA.position, pointB.position, interpolateAmount);
            pointBC.position = Vector3.Lerp(pointB.position, pointC.position, interpolateAmount);
            transform.position = Vector3.Lerp(pointAB.position, pointBC.position, interpolateAmount);
            transform.LookAt(pointBC, Vector3.up);

            if (Vector3.Distance(transform.position, pointC.position) < 0.05f)
            {
                if (index < checkPoints.Length - 1) { index++; }
                interpolateAmount = 0;
                target = checkPoints[index];
                isTurning = false; isGoing = true;
                transform.rotation = Quaternion.Euler(0, checkPoints[index - 1].localRotation.eulerAngles.y, 0);
            }
        }
    }
}
