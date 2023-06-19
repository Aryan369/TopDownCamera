using UnityEngine;
using UnityEditor;

namespace Aryan369.Cameras
{
    [CustomEditor(typeof(TopDown_Camera))]
    public class TopDown_Camera_Editor : Editor
    {
        #region Variables
        private TopDown_Camera targetCam;

        #endregion

        #region Main Methods
        private void OnEnable()
        {
            targetCam = (TopDown_Camera)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }

        private void OnSceneGUI()
        {
            if (!targetCam.target)
            {
                return;
            }

            Transform camTarget = targetCam.target;

            Handles.color = new Color(1f, 0f, 0f, 0.15f);
            Handles.DrawSolidDisc(camTarget.position, Vector3.up, targetCam.distance);

            Handles.color = new Color(1f, 1f, 0f, 0.75f);
            Handles.DrawWireDisc(camTarget.position, Vector3.up, targetCam.distance);

            Handles.color = new Color(1f, 0f, 0f, 0.5f);
            targetCam.distance = Handles.ScaleSlider(targetCam.distance, camTarget.position, -camTarget.forward, Quaternion.identity, targetCam.distance, 1f);
            targetCam.distance = Mathf.Clamp(targetCam.distance, 1f, float.MaxValue);

            Handles.color = new Color(0f, 0f, 1f, 0.5f);
            targetCam.height = Handles.ScaleSlider(targetCam.height, camTarget.position, Vector3.up, Quaternion.identity, targetCam.height, 1f);
            targetCam.height = Mathf.Clamp(targetCam.height, 5f, float.MaxValue);

            GUIStyle labelStyle = new GUIStyle();
            labelStyle.fontSize = 15;
            labelStyle.normal.textColor = Color.white;
            labelStyle.alignment = TextAnchor.UpperCenter;
            Handles.Label(camTarget.position + (-camTarget.forward * targetCam.distance), "Distance", labelStyle);

            labelStyle.alignment = TextAnchor.MiddleRight;
            Handles.Label(camTarget.position + (Vector3.up * targetCam.height), "Height", labelStyle);
        }
        #endregion
    }
}
