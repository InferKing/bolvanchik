using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameObject _mousePos;
    private float _power;
    private Vector3 vect;
    private void Start()
    {
        _power = 4;
    }
    private void Update()
    {
        if (Time.timeScale == 1 && MainManager.playingType != PlayingType.Stop)
        {
            vect = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vect.z = transform.position.z;
            _mousePos.transform.position = vect;
        }
    }

    private void FixedUpdate()
    {
        if (Time.timeScale == 1 && MainManager.playingType != PlayingType.Stop)
        {
            _rb.velocity = (vect - transform.position) * 1200 * Time.fixedDeltaTime;
        }
        
        //_rb.AddForce((vect-transform.position) * _power * Time.fixedDeltaTime * 1000, ForceMode2D.Force);
        //_rb.AddForceAtPosition((vect - transform.position)*_power*2, vect, ForceMode2D.Force);

    }

    /* here is old version of player control
     if (!_touched && Time.timeScale == 1)
        {
            _hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        }
        if (_hit.collider != null && !_touched)
        {
            if (_hit.collider.name == "Player" && Input.GetKeyDown(KeyCode.Mouse0))
            {
                _touched = true;
            }
        }
        if (_touched && Time.timeScale == 1)
        {
            Vector3 vect = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vect.z = _hit.collider.gameObject.transform.position.z;
            _hit.collider.gameObject.transform.position = vect;
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _touched = false;
            }
        }
     */

    private void OnCollisionEnter2D(Collision2D collision)
    {       
        if (collision.collider.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((collision.transform.position-transform.position) * _power, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((collision.transform.position - transform.position) * _power/8, ForceMode2D.Impulse);
        }
    }
}
