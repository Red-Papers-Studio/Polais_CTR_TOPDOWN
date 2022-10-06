using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private ShortRangeWeapon _firstWeapon;
    [SerializeField] private LongRangeWeapon _secondWeapon;

    public bool IsFirstWeapon { get; private set; }
    public bool IsSecondWeapon { get; private set; }
    public ShortRangeWeapon FirstWeapon { get => _firstWeapon; }
    public LongRangeWeapon SecondWeapon { get => _secondWeapon; }

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        IsFirstWeapon = true;
        IsSecondWeapon = false;
        SetParamsInAnimator();
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
        if(_firstWeapon.gameObject.activeInHierarchy)
        {
            IsFirstWeapon = false;
            IsSecondWeapon = true;
            SetParamsInAnimator();
        }
        else
        {
            IsFirstWeapon = true;
            IsSecondWeapon = false;
            SetParamsInAnimator();
        }
    }

    private void SetParamsInAnimator()
    {
        _animator.SetBool("IsFirstWeapon", IsFirstWeapon);
        _animator.SetBool("IsSecondWeapon", IsSecondWeapon);
        _firstWeapon.gameObject.SetActive(IsFirstWeapon);
        _secondWeapon.gameObject.SetActive(IsSecondWeapon);
    }
    public void EndWeaponSwitch() => _animator.SetBool("WeaponSwitch", false);
}
