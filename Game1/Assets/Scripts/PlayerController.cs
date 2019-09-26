using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Animator _animator;
	Rigidbody2D rigidbody2d;
	bool isGround; //Находится ли наш персонаж на земле
    // Start is called before the first frame update
    void Start()
    {
        _animator = transform.GetChild(0).GetComponent<Animator>();
		rigidbody2d = GetComponent<Rigidbody2D>();
		isGround = true; //изначально на земле
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
			transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate(Vector2.left * Time.deltaTime);
			if(isGround) _animator.Play("H_M_WALK");
        }
        else if (Input.GetKey(KeyCode.D))
        {
			transform.localScale = new Vector3(1, 1, 1);
            transform.Translate(Vector2.right * Time.deltaTime);
			if(isGround) _animator.Play("H_M_WALK");
        }
		else if(isGround)
		{
			_animator.Play("H_M_IDLE");
		}
		if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
			isGround = false;
			rigidbody2d.velocity = new Vector2(0, 6.6f);
			_animator.Play("H_M_JUMP");
        }
		
    }
	
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground")) //если объект столкнулся с игроком
        {
            isGround = true;
			rigidbody2d.velocity = new Vector2(0, 0);
        }
    }
}
