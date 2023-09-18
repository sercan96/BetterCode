using System;
using Runtime.Controllers;
using Runtime.Data.UnityObjects;
using Runtime.Data.ValueObjects;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class PlayerManager : MonoBehaviour
    {

        #region SerializeField Variables

        [SerializeField] private PlayerMovementController _movementController;

        #endregion

        #region Private Variables

        private PlayerData _data;

        #endregion

        private void Awake()
        {
            GetPlayerData();
        }

        private void OnEnable()
        {
            SubscribeEvents();
            SendDataToControllers();
        }
        
        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.onInputTaken += _movementController.OnInputTaken;
        }
        
        private void UnSubscribeEvents()
        {
            InputSignals.Instance.onInputTaken -= _movementController.OnInputTaken;
        }
        
        private void GetPlayerData()
        {
            _data = Resources.Load<CD_Player>("Data/CD_Player").Data;
        }
        
        private void SendDataToControllers()
        {
            _movementController.SendMovementData(_data.MovementData);
        }
    }
}