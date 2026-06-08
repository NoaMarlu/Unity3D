using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public float moveSpeed=5.0f;

    void Start()
    {
        
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
         float horizontal = Keyboard.current.wKey.ReadValue() - Keyboard.current.sKey.ReadValue();
         float vertical = Keyboard.current.aKey.ReadValue() - Keyboard.current.dKey.ReadValue();
         Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
         transform.Translate(movement);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Block"))
        {
            Block b=collision.gameObject.GetComponent<Block>();
            b.Open();
        }
    }

}
