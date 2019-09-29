using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Animator _animator;
	Rigidbody2D rigidbody2d;
	bool isGround; //Находится ли наш персонаж на земле
	
    void Start()
    {
        _animator = transform.GetChild(0).GetComponent<Animator>();
		rigidbody2d = GetComponent<Rigidbody2D>();
		isGround = true; //изначально на земле
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
			WalkLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
			WalkRight();
        }
		else if(isGround)
		{
			Idle();
		}
		if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
			Jump();
        }
    }
	
	void WalkLeft()
	{
		transform.localScale = new Vector3(-1, 1, 1);
		transform.Translate(Vector2.left * Time.deltaTime);
		if(isGround) _animator.Play("H_M_WALK");
	}
	
	void WalkRight()
	{
		transform.localScale = new Vector3(1, 1, 1);
		transform.Translate(Vector2.right * Time.deltaTime);
		if(isGround) _animator.Play("H_M_WALK");
	}
	
	void Idle()
	{
		_animator.Play("H_M_IDLE");
	}
	
	void Jump()
	{
		isGround = false;
		rigidbody2d.velocity = new Vector2(0, 6.6f);
		_animator.Play("H_M_JUMP");
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground")) //если объект столкнулся с игроком
        {
            isGround = true;
			rigidbody2d.velocity = new Vector2(0, 0);
        }
		else //Здесь нужен else if с проверкой тега противника. 
		{
			EventManager.TriggerEvent("Loser"); //Подаем событие, что мы проиграли
		}
    }
}
