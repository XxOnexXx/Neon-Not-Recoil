using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject explosionFx;
    [SerializeField] int healthPoints = 3;

    int currentHealthPoints;
    GameManager gameManager;

    private void Awake()
    {
        currentHealthPoints = healthPoints;
    }

    void Start()
    {

        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AdjustEnemies(1);
    }

    public void TakeDamage(int amount)
    {
        currentHealthPoints = currentHealthPoints - amount;

        if (currentHealthPoints <= 0)
        {
            gameManager.AdjustEnemies(-1);
            alahuAkbhar();
        }


    }
    void Update()
    {

    }

    public void alahuAkbhar()
    {
            Instantiate(explosionFx, transform.position, Quaternion.identity);
            Destroy(gameObject);

    }
}
