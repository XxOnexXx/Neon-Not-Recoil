using Cinemachine;
using Microsoft.Unity.VisualStudio.Editor;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] int healthPoints = 10;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Transform weaponCamera;
    [SerializeField] UnityEngine.UI.Image[] shieldbars;
    [SerializeField] GameObject gameOverCont;
   
    int currentHealthPoints;
    int deathCameraPriority = 20;

    private void Awake()
    {
        currentHealthPoints = healthPoints;
        
        AdjustHealthUI();
    }


    public void TakeDamage(int amount)
    {
        currentHealthPoints = currentHealthPoints - amount;

        AdjustHealthUI();

        if (currentHealthPoints < 0)
        {
            
            RestartScene();
        }
    }

    private void RestartScene()
    {
        weaponCamera.parent = null;
        deathVirtualCamera.Priority = deathCameraPriority;
        gameOverCont.SetActive(true);
        StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssetsInputs.SetCursorState(false);
        Destroy(this.gameObject);
    }

    void AdjustHealthUI()
    {
        for (int i = 0; i < shieldbars.Length; i++)
        {
            if (i < currentHealthPoints)
            {
                shieldbars[i].gameObject.SetActive(true);
            }

            else
            {
                shieldbars[i].gameObject.SetActive(false);
            }
        }
    }

}
