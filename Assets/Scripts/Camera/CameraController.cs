using UnityEngine;

namespace Hex.CameraTools
{
    public class CameraController : MonoBehaviour
    {

        private float _moveSpeed = 10f;
        private float _rotationSpeed = 100f;
        void Update()
        {
            HandleCameraMovement();
            HandleCameraRotation();
        }

        private void HandleCameraMovement()
        {
            Vector3 inputMoveDir = new Vector3(0, 0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                inputMoveDir.z = 1f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                inputMoveDir.z = -1f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                inputMoveDir.x = -1f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                inputMoveDir.x = 1f;
            }
            Vector3 moveVector = transform.forward * inputMoveDir.z + transform.right * inputMoveDir.x;
            transform.position += moveVector * _moveSpeed * Time.deltaTime;
        }

        private void HandleCameraRotation()
        {
            Vector3 rotationVector = new Vector3(0, 0, 0);
            if (Input.GetKey(KeyCode.Q))
            {
                rotationVector.y = -1f;
            }
            if (Input.GetKey(KeyCode.E))
            {
                rotationVector.y = 1f;
            }
            transform.eulerAngles += rotationVector * _rotationSpeed * Time.deltaTime;
        }
    }
}