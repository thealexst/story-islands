using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private float _startTimeBtwAttack = 0.4f;
    [SerializeField] private float _timeBtwAttak = 0.4f;
    [SerializeField] private bool _canBeAttack;
    [SerializeField] private GameObject _sword;

    void Update()
    {
        if (_canBeAttack)
        {
            _sword.SetActive(true);
            _timeBtwAttak -= Time.deltaTime;
        }
        else
        {
            _sword.SetActive(false);
            _timeBtwAttak = 0.4f;
        }

        if (_timeBtwAttak <= 0)
        {
            _canBeAttack = false;
        }

        if(_startTimeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _canBeAttack = true;
                _startTimeBtwAttack = 0.4f;
            }
        }
        else
        {
            _startTimeBtwAttack -= Time.deltaTime;
        }
    }
}
