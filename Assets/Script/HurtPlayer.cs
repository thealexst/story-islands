using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    [SerializeField] private int _damageToGive;
    [SerializeField] private float _startTimeBtwAttack;

    private float _timeBtwAttak;
    private bool _canBeAttack;
    private HealthManager _healthMan;
    private GameObject _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _healthMan = _player.GetComponent<HealthManager>();
    }

    void Update()
    {
        TimeToFight();
        Fight();
    }

    private void Fight()
    {
        if(Vector2.Distance(transform.position, _player.transform.position) <= 1f && _canBeAttack)
        {
            _healthMan.HurtPlayer(_damageToGive);
            _timeBtwAttak = _startTimeBtwAttack;
        }
    }
    private void TimeToFight()
    {
        if(_timeBtwAttak <= 0)
        {
            _canBeAttack = true;
        }
        else
        {
            _canBeAttack = false;
            _timeBtwAttak -= Time.deltaTime;
        }
    }
}
