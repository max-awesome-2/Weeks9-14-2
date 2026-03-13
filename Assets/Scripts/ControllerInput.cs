using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerInput : MonoBehaviour
{
    public float speed;
    public Vector2 directionalInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)directionalInput * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext con)
    {
        directionalInput = con.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext con)
    {
        print($"Attack time {con.phase}");
    }

    public void OnPoint(InputAction.CallbackContext con)
    {
        Debug.Log("OnPoint: " + con.ReadValue<Vector2>());

        Vector2 worldPos = Camera.main.ScreenToWorldPoint(con.ReadValue<Vector2>());


        transform.rotation = Quaternion.LookRotation(Vector3.forward, ((Vector3)worldPos - transform.position).normalized);
    } 
}
