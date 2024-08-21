using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infantry.Devices
{
    public class Device : MonoBehaviour // would be interface but needs to be monobehaviour
    {
        protected InfantryInputMap input;
        public virtual void Awake()
        {
            input = new InfantryInputMap();
        }

        public void OnEnable()
        {
            input.Enable();
        }

        public void OnDisable()
        {
            input.Disable();
        }
    }
}
