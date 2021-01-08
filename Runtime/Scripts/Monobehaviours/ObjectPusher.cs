using UnityEngine;

namespace TheAshenWolf.Monobehaviours
{
    public class ObjectPusher : MonoBehaviour
    {
        [SerializeField] private bool movementEnabled;

        [Header("General Settings")]
        [SerializeField] private bool multiplyByDeltaTime;
        [SerializeField] private float movementSpeed = 1;

        [Header("Movement Weights"), Tooltip("Movement speed gets multiplied by these values per axis.")]
        [Range(-1, 1), SerializeField] private float movementWeightXAxis;
        [Range(-1, 1), SerializeField] private float movementWeightYAxis;
        [Range(-1, 1), SerializeField] private float movementWeightZAxis;

        [Header("Axis Locks"), Tooltip("If a box is checked, the movement weight of that axis is ignored.")]
        [SerializeField] private bool lockXAxis;
        [SerializeField] private bool lockYAxis;
        [SerializeField] private bool lockZAxis;

        private void Update()
        {
            if (!movementEnabled) return;

            Vector3 movement = Vector3.zero;
            
            if (!lockXAxis) movement.x = movementWeightXAxis;
            if (!lockYAxis) movement.y = movementWeightYAxis;
            if (!lockZAxis) movement.z = movementWeightZAxis;

            movement *= movementSpeed;

            if (multiplyByDeltaTime) movement *= Time.deltaTime;
            
            transform.Translate(movement);
        }
    }
}