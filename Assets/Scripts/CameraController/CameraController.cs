using Cinemachine;
using UnityEngine;

namespace CameraController
{
    public class CameraController : MonoBehaviour
    {
        public void SetFollow(Transform transformObject)
        {
            GetComponent<CinemachineVirtualCamera>().Follow = transformObject;
        }
    }
}
