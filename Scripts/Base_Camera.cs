using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aryan369.Cameras
{
    public class Base_Camera : MonoBehaviour
    {
        #region Variables
        public Transform target;
        #endregion

        #region Main Methods

        protected void Start()
        {
            HandleCamera();
        }

        protected void Update()
        {
            HandleCamera();
        }

        #endregion

        #region Helper Methods

        protected virtual void HandleCamera()
        {
            if (!target)
            {
                return;
            }
        }
        #endregion
    }
}
