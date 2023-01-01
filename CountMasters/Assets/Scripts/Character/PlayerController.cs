using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField]
    private float forwardSpeed;
    [SerializeField]
    private float swipeSpeed;
    [SerializeField]
    private GameObject mainCanvas;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!mainCanvas.activeSelf)
        {
            transform.Translate(0, 0, forwardSpeed * Time.deltaTime);
        }

        if (!mainCanvas.activeSelf && Input.touchCount > 0)
        {
            Touch firstTouch = Input.GetTouch(0);

            
            Vector3 newPosition = new Vector3(this.transform.position.x + firstTouch.deltaPosition.x, transform.position.y, transform.position.z);
            //if(newPosition.x < )
            this.transform.position = Vector3.Lerp(this.transform.position, newPosition, swipeSpeed/50 * Time.deltaTime);

            animator.SetBool("isWalking", true);
        }
    }
}
