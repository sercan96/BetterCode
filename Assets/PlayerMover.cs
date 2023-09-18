using UnityEngine;

public class PlayerMover : MonoBehaviour // En temel hali
{
    private Rigidbody _rigidbody;
    public int speedValue;
    private Vector3 _inputValues;

    private void Start()
    {
        GetReferences();
    }

    private void GetReferences() => _rigidbody = GetComponent<Rigidbody>();

    void Update()
    {
        #region OldVersion
        // _rigidbody.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime * 50, 0,
        //     Input.GetAxisRaw("Vertical") * 50* Time.fixedDeltaTime);
        
        // FixedUpdate metodunda yazılmalı
        // Sabit değerler olmamalı
        // PlayerMover kötü bir isim

        #endregion
        InputGetAxis();
    }

    private void FixedUpdate()
    {
        #region OldVersion
        // Input Update içerisinde yazılır,
        // Fizik işlemi ise fixedUpdate içerisinde yazılmalıdır.

        /* VELOCITY
         Burada velocity'nin y eksenini 0 a eşitlediğimiz için gravity -9.81 ile aşağı inerken 0 yapmaya çalışıyoruz.
         Bu sebeple aşağı doğru inerken daha zor inmesini sağlıcaktır.
         velocity değerine += dersek bu sefer hızlıca inecektir. Çünkü bir önceki değere ekleme yaparak ilerler.
        */
        #endregion
        
        MovePlayer();
    }

    private void MovePlayer()
    {
        _rigidbody.velocity += new Vector3(_inputValues.x, 0, _inputValues.z * (speedValue* Time.fixedDeltaTime));
    }

    private void InputGetAxis() // Input başka bir scriptte yapılmalıdır.
    {
        _inputValues = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }
}
