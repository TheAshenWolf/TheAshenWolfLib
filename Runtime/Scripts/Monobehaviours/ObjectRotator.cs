using UnityEngine;

namespace TheAshenWolf.Monobehaviours
{
    public class ObjectRotator : MonoBehaviour
    {
        [SerializeField] private bool rotationEnabled;

        [Header("General Settings")]
        [SerializeField] private bool multiplyByDeltaTime;
        [SerializeField] private float rotationSpeed = 1;

        [Header("Movement Weights"), Tooltip("Movement speed gets multiplied by these values per axis.")]
        [Range(-1, 1), SerializeField] private float rotationWeightXAxis;
        [Range(-1, 1), SerializeField] private float rotationWeightYAxis;
        [Range(-1, 1), SerializeField] private float rotationWeightZAxis;

        [Header("Axis Locks"), Tooltip("If a box is checked, the movement weight of that axis is ignored.")]
        [SerializeField] private bool lockXAxis;
        [SerializeField] private bool lockYAxis;
        [SerializeField] private bool lockZAxis;

        private void Update()
        {
            if (!rotationEnabled) return;

            Vector3 rotation = Vector3.zero;
            
            if (!lockXAxis) rotation.x = rotationWeightXAxis;
            if (!lockYAxis) rotation.y = rotationWeightYAxis;
            if (!lockZAxis) rotation.z = rotationWeightZAxis;

            rotation *= rotationSpeed;

            if (multiplyByDeltaTime) rotation *= Time.deltaTime;
            
            transform.Rotate(rotation);
        }
    }
}
