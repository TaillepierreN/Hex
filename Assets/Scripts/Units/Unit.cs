using Hex.Tools;
using UnityEngine;

namespace Hex.Units
{
    public class Unit : MonoBehaviour
    {
        private Vector3 targetPosition;
        private float moveSpeed = 4f;
        private float stoppingDistance = .1f;

        private void Update()
        {
            if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
            {
                Vector3 moveDirection = (targetPosition - transform.position).normalized;
                transform.position += moveDirection * moveSpeed * Time.deltaTime;
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