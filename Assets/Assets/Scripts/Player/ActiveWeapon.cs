

using Cinemachine;
using Cinemachine.Utility;
using StarterAssets;
using TMPro;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ActiveWeapon : MonoBehaviour
{
    RaycastHit hit;

    [SerializeField] WeaponSo startingWeaponSo;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] TMP_Text magText;
    [SerializeField] CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] Camera weaponCamera;

    FirstPersonController firstPersonController;

    WeaponSo currentWeaponSo;
    float timeLastShot = 0f;
    float defaultFov;
    float defaultRotSpeed;
    int currentAmmo;
    
    int currentStoredMag;
    int startingStoredMag;
    [SerializeField] GameObject zoomVignette;


    Animator animator;

    const string SHOOT_STRING = ("Recoil");



    StarterAssetsInputs starterAssetsInputs;



    Weapon currentweapon;


    void Start()
    {

        SwitchWeapon(startingWeaponSo);
        AddSubAmmo(currentWeaponSo.Magzine_Size);
        
        
    }
    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        animator = GetComponent<Animator>();
        defaultFov = playerFollowCamera.m_Lens.FieldOfView;
        defaultRotSpeed = firstPersonController.RotationSpeed;
    }


    void Update()
    {

        timeLastShot += Time.deltaTime;

        ShootHandle();
        Zoomhandle();
        Reload();

    }

    public void SwitchWeapon(WeaponSo weaponSo)
    {
        if (currentweapon)
        {
            Destroy(currentweapon.gameObject);
        }

        Weapon newWeapon = Instantiate(weaponSo.WeaponPrefab, transform).GetComponent<Weapon>();

        currentweapon = newWeapon;
        this.currentWeaponSo = weaponSo;
        AddSubAmmo(currentWeaponSo.Magzine_Size);

    }

    void ShootHandle()
    {
        if (!starterAssetsInputs.shoot) return;
        {
            if (timeLastShot >= currentWeaponSo.fireRate && currentAmmo > 0)
            {
                animator.Play(SHOOT_STRING, 0, 0f);
                currentweapon.ShootHandle(currentWeaponSo);
                timeLastShot = 0f;
                AddSubAmmo(-1);
            }

            if (!currentWeaponSo.IsAutomatic)
            {
                starterAssetsInputs.ShootInput(false);
            }

        }

    }

    void Reload()
    {
        if (currentAmmo <= 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                currentAmmo = currentStoredMag;
                currentStoredMag = 0; 
          }
        }
    }

    public void AddSubAmmo(int amount)
    {
        currentAmmo += amount;
       
        if (currentAmmo > currentWeaponSo.Magzine_Size)
        {
            currentAmmo = currentWeaponSo.Magzine_Size;
        }
        ammoText.text = currentAmmo.ToString("D2");
       
        
    }
    void Zoomhandle()
    {
            if (!currentWeaponSo.CanZoom) return;

        if (starterAssetsInputs.zoom)
        {
            playerFollowCamera.m_Lens.FieldOfView = currentWeaponSo.ZoomAmount;
            weaponCamera.fieldOfView = currentWeaponSo.ZoomAmount;
            zoomVignette.SetActive(true);
            firstPersonController.ChangeRotationSpeed(currentWeaponSo.zoomSens);

        }

        else
        {
            playerFollowCamera.m_Lens.FieldOfView = defaultFov;
            weaponCamera.fieldOfView = defaultFov;
            zoomVignette.SetActive(false);
            firstPersonController.ChangeRotationSpeed(defaultRotSpeed);
        }
          
        }
}
