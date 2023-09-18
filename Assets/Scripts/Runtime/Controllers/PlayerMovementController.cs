using System;
using Runtime.Data.ValueObjects;
using Runtime.Keys;
using UnityEngine;

namespace Runtime.Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Vector3 _inputValues;

        #region SerializeField Variables

        //[SerializeField] private int speedValue;
        private PlayerMovementData _playerMovementData;

        #endregion
        
        private void GetReferences() => _rigidbody = GetComponent<Rigidbody>();

        private void Awake()
        {
            GetReferences();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        public void OnInputTaken(InputParams inputSignal)
        {
            _inputValues = inputSignal.InputValues;
        }
        
        private void MovePlayer()
        {
            _rigidbody.velocity += new Vector3(_inputValues.x, 0, _inputValues.z * (_playerMovementData.Speed* Time.fixedDeltaTime));
        }

        public void SendMovementData(PlayerMovementData playerMovementData)
        {
            _playerMovementData = playerMovementData;
        }
    }
}