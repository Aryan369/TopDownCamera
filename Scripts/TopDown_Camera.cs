using UnityEngine;

namespace Aryan369.Cameras
{
    public class TopDown_Camera : Base_Camera
    {
        #region Variables
        public float height = 10f;
        public float distance = 20f;
        [SerializeField] private float angle = 45f;
        [SerializeField] private float smoothSpeed = 0.5f;

        private Vector3 refVelocity;
        #endregion

        #region Helper Methods
        protected override void HandleCamera()
        {
            base.HandleCamera();

            //Make World position vector
            Vector3 worldPosition = (Vector3.forward * -distance) + (Vector3.up * height);
            //Debug.DrawLine(target.position, worldPosition, Color.red);

            //Make the rotated vector
            Vector3 rotatedVector = Quaternion.AngleAxis(angle, Vector3.up) * worldPosition;
            //Debug.DrawLine(target.position, rotatedVector, Color.green);

            //Move our position
            Vector3 flatTargetPosition = target.position;
            flatTargetPosition.y = 0f;
            Vector3 finalPosition = flatTargetPosition + rotatedVector;
            //Debug.DrawLine(target.position, finalPosition, Color.blue);

            transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, smoothSpeed);
            transform.LookAt(flatTargetPosition);
        }
        #endregion
    }

}
