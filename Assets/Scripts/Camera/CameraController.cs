using UnityEngine;
using Unity.Cinemachine;
using Unity.VisualScripting;

namespace Hex.CameraTools
{
    public class CameraController : MonoBehaviour
    {
        private const float MIN_ZOOM = 2f;
        private const float MAX_ZOOM = 12f;
        [SerializeField] private CinemachineFollow _cinemachineFollow;
        private float _moveSpeed = 10f;
        private float _rotationSpeed = 100f;
        private float _zoomSpeed = 1f;
        private Vector3 _followOffset;

        private void Start()
        {
            _followOffset = _cinemachineFollow.FollowOffset;
        }
        void Update()
        {
            HandleCameraMovement();
            HandleCameraRotation();
            HandleCameraZoom();
        }

        private void HandleCameraZoom()
        {
            if (Input.mouseScrollDelta.y > 0)
                _followOffset.y -= _zoomSpeed;
            if (Input.mouseScrollDelta.y < 0)
                _followOffset.y += _zoomSpeed;
            _followOffset.y = Mathf.Clamp(_followOffset.y, MIN_ZOOM, MAX_ZOOM);
            _cinemachineFollow.FollowOffset = Vector3.Lerp(_cinemachineFollow.FollowOffset, _followOffset, Time.deltaTime * 10f);
        }

        private void HandleCameraMovement()
        {
            Vector3 inputMoveDir = new Vector3(0, 0, 0);

            if (Input.GetKey(KeyCode.W))
                inputMoveDir.z = 1f;

            if (Input.GetKey(KeyCode.S))
                inputMoveDir.z = -1f;

            if (Input.GetKey(KeyCode.A))
                inputMoveDir.x = -1f;

            if (Input.GetKey(KeyCode.D))
                inputMoveDir.x = 1f;

            Vector3 moveVector = transform.forward * inputMoveDir.z + transform.right * inputMoveDir.x;
            transform.position += moveVector * _moveSpeed * Time.deltaTime;
        }

        private void HandleCameraRotation()
        {
            Vector3 rotationVector = new Vector3(0, 0, 0);

            if (Input.GetKey(KeyCode.Q))
                rotationVector.y = -1f;

            if (Input.GetKey(KeyCode.E))
                rotationVector.y = 1f;

            transform.eulerAngles += rotationVector * _rotationSpeed * Time.deltaTime;
        }
    }
}