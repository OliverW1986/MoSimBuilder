using UnityEngine;

public class SpawnCargo : MonoBehaviour
{
    [SerializeField] private GameObject[] cargoPrefab;

    bool isMultiplayer;
    private bool sameAlliance;

    private int _gamemode;
    private void Start()
    {
        _gamemode = PlayerPrefs.GetInt("gamemode");

        switch (_gamemode)
        {
            case 1:
                isMultiplayer = true;
                sameAlliance = false;
                break;
            case 2:
                sameAlliance = true;
                isMultiplayer = false;
                break;
            default:
                sameAlliance = true;
                isMultiplayer = false;
                break;
        }

        InstantiateCargo();
    }

    public void InstantiateCargo()
    {
        if (PlayerPrefs.GetFloat("isChallange") == 1)
        {
            if ((PlayerPrefs.GetInt("challange") == 2 && !sameAlliance))
            {
                Instantiate(cargoPrefab[0], transform);
            } else if (PlayerPrefs.GetInt("challange") == 1 || (PlayerPrefs.GetInt("challange") == 2 && sameAlliance))
            {
                if (PlayerPrefs.GetString("alliance") == "red")
                {
                    Instantiate(cargoPrefab[2], transform);
                }
                else
                {
                    Instantiate(cargoPrefab[1], transform);
                }
            }
            else if (PlayerPrefs.GetFloat("challange") == 0)
            {
                if (PlayerPrefs.GetString("alliance") == "blue")
                {
                    Instantiate(cargoPrefab[2], transform);
                }
                else
                {
                    Instantiate(cargoPrefab[1], transform);
                }
            }
        } else
        {
            Instantiate(cargoPrefab[0], transform);
        }
        
            
    }
}
