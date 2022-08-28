using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _firstWeapon;
    [SerializeField] private GameObject _secondWeapon;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _secondWeapon.SetActive(false);
        _animator.SetBool("IsFirstWeapon", true);
        _animator.SetBool("IsSecondWeapon", false);
    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            _animator.SetBool("WeaponSwitch", true);
        }
    }

    public void SwitchWeapon()
    {
        if(_firstWeapon.activeInHierarchy)
        {
            _animator.SetBool("IsFirstWeapon", false);
            _animator.SetBool("IsSecondWeapon", true);
            _firstWeapon.SetActive(false);
            _secondWeapon.SetActive(true);
        }
        else
        {
            _animator.SetBool("IsFirstWeapon", true);
            _animator.SetBool("IsSecondWeapon", false);
            _secondWeapon.SetActive(false);
            _firstWeapon.SetActive(true);
        }
    }

    public void EndWeaponSwitch() => _animator.SetBool("WeaponSwitch", false);
}
