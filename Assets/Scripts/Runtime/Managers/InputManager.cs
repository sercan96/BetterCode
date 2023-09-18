using Runtime.Controllers;
using Runtime.Keys;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class InputManager : MonoBehaviour
    {
        #region PrivateVariables
        private Vector3 _inputValues;

        #endregion
        void Update()
        {
            _inputValues = GetInputAxis();
            if (!Input.anyKey) return;
            SendInput();
        }
        
        private void SendInput()
        {
            InputSignals.Instance.onInputTaken?.Invoke(new InputParams()
            {
                InputValues = _inputValues
            });
        }
        private Vector3 GetInputAxis() // Input başka bir scriptte yapılmalıdır.
        {
            return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        }
    }
}