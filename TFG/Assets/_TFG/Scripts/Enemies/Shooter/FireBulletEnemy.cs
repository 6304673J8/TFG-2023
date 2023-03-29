using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletEnemy : MonoBehaviour
{
    public GameObject _bullet;
    [SerializeField]
    private float _timer = 4f;
    //private float timerCount = 0f;

    [SerializeField]
    private int _counter;
    private int _maxCounter = 80;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireBullet_CR());
    }

    IEnumerator FireBullet_CR()
    {
        for(int i=0; i<_maxCounter; i++)
        {
            _counter++;
            Instantiate(_bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(_timer);
        }
    }
}
