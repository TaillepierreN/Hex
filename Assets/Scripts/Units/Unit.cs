using Hex.Tools;
using UnityEngine;

namespace Hex.Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Animator unitAnimator;
        private Vector3 targetPosition;
        private float moveSpeed = 4f;
        private float rotateSpeed = 10f;
        private float stoppingDistance = .1f;

        private void Update()
        {
            if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
            {
                Vector3 moveDirection = (targetPosition - transform.position).normalized;
                transform.position += moveDirection * moveSpeed * Time.deltaTime;
                transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
                unitAnimator.SetBool("isWalking", true);
            }
            else
            {
                unitAnimator.SetBool("isWalking", false);
            }
            if (Input.GetMouseButtonDown(0))
            {
                Move(MousePosition.GetPosition());
            }
        }
        private void Move(Vector3 targetPosition)
        {
            this.targetPosition = targetPosition;
        }
    }
}