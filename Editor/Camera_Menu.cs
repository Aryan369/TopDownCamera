using UnityEngine;
using UnityEditor;

namespace Aryan369.Cameras
{
    public class Camera_Menu : MonoBehaviour
    {
        [MenuItem("Aryan369/Cameras/TopDown_Camera")]
        public static void CreateTopDownCamera()
        {
            GameObject[] selectedGO = Selection.gameObjects;
            
            if (selectedGO.Length > 0 && selectedGO[0].GetComponent<Camera>())
            {
                if(selectedGO[0].GetComponent<TopDown_Camera>())
                {
                    EditorUtility.DisplayDialog("Camera Tools", "The selected gameobject already has TopDown_Camera script attached to it!", "OK");
                    return;
                }
                
                if (selectedGO.Length < 2)
                {
                    AttachTopDownScript(selectedGO[0].gameObject, null);
                }
                else if(selectedGO.Length == 2)
                {
                    AttachTopDownScript(selectedGO[0].gameObject, selectedGO[1].transform);
                }
                else
                {
                    EditorUtility.DisplayDialog("Camera Tools", "You can only select 2 gameobjects in the scene and the first selection needs to be a camera!", "OK");
                }
            }
            else
            {
                EditorUtility.DisplayDialog("Camera Tools", "You need to select a gameobject in the scene that has a camera component assigned to it!", "OK");
            }
        }

        static void AttachTopDownScript(GameObject aCamera, Transform aTarget)
        {
            //Assign TopDown script to the camera
            TopDown_Camera camScript = null;
            
            if (aCamera)
            {
                camScript = aCamera.AddComponent<TopDown_Camera>();

                //Check if we have a target and have a script ref
                if (camScript && aTarget)
                {
                    camScript.target = aTarget;
                }

                Selection.activeGameObject = aCamera;
            }
        }
    }
}
