using Infantry.Devices;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

namespace Infantry.Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        private InfantryInputMap input;

        public List<Device> devicePrefabsList;

        private List<Device> devicesList;
        private Device currentDevice;
        private int CurrentDeviceIndex = 0;

        void Awake()
        {
            input = new InfantryInputMap();
            input.Infantry.NextWeapon.performed += (UnityEngine.InputSystem.InputAction.CallbackContext obj) => NextDevice();
            input.Infantry.PreviousWeapon.performed += (UnityEngine.InputSystem.InputAction.CallbackContext obj) => PreviousDevice();

            devicesList = new List<Device>();
            foreach (Device devicePrefab in devicePrefabsList)
            {
                Device tempDevice = Instantiate(devicePrefab);

                devicesList.Add(tempDevice);
                tempDevice.gameObject.SetActive(false);
            }

            currentDevice = devicesList[0];
            currentDevice.gameObject.SetActive(true);
        }

        public void OnEnable()
        {
            input.Enable();
        }

        public void OnDisable()
        {
            input.Disable();
        }

        public void NextDevice()
        {
            SwitchDevices((CurrentDeviceIndex + 1) % devicesList.Count);
        }
        
        public void PreviousDevice()
        {
            if (CurrentDeviceIndex == 0)
                CurrentDeviceIndex = devicesList.Count;

            SwitchDevices(CurrentDeviceIndex - 1);
        }

        public void SwitchDevices(int index)
        {
            if (index >= 0 && index < devicesList.Count)
            {
                currentDevice.gameObject.SetActive(false);

                CurrentDeviceIndex = index;
                currentDevice = devicesList[CurrentDeviceIndex];
                currentDevice.gameObject.SetActive(true);
            }

        }
    }
}
