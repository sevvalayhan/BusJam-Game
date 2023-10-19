using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    #region Fields
    static int soundLevel;
    static int vibration;
    static int darkmode;
    static int level;
    static int randomLevel;
    static int previousLevel;
    static int tutorial;
    static int totalCoin;
    static int totalStar;
 

    //power ups
    static int replaceBoost;
    static int jokerBoost;
    static int hammerBoost;

    //life update
    static int totalLife;
    static string time;
    static float timeSave;

    #endregion
    public static int Level
    {
        get
        {
            if (!PlayerPrefs.HasKey("level"))
            {
                return 1;
            }
            return PlayerPrefs.GetInt("level");
        }
        set
        {
            level = value;
            PlayerPrefs.SetInt("level", level);
        }
    }

    public static int TotalCoin
    {
        get
        {
            if (!PlayerPrefs.HasKey("totalCoin"))
            {
                return 0;
            }
            return PlayerPrefs.GetInt("totalCoin");
        }
        set
        {
            totalCoin = value;
            PlayerPrefs.SetInt("totalCoin", totalCoin);
        }
    }

    public static int RandomLevel
    {
        get
        {
            if (!PlayerPrefs.HasKey("randomLevel"))
            {
                return 1;
            }
            return PlayerPrefs.GetInt("randomLevel");
        }
        set
        {
            randomLevel = value;
            PlayerPrefs.SetInt("randomLevel", randomLevel);
        }
    }
    public static int Vibration
    {
        get
        {
            if (!PlayerPrefs.HasKey("vibration"))
            {
                return 1;
            }
            return PlayerPrefs.GetInt("vibration");
        }
        set
        {
            vibration = value;
            PlayerPrefs.SetInt("vibration", vibration);
        }
    }
    public static int Sound
    {
        get
        {
            return PlayerPrefs.GetInt("soundLevel");
        }
        set
        {
            soundLevel = value;
            PlayerPrefs.SetInt("soundLevel", soundLevel);
        }
    }

    public static int DarkMode
    {
        get
        {
            return PlayerPrefs.GetInt("darkmode");
        }
        set
        {
            darkmode = value;
            PlayerPrefs.SetInt("darkmode", darkmode);
        }
    }

    public static int Tutorial
    {
        get
        {
            return PlayerPrefs.GetInt("tutorial");
        }
        set
        {
            tutorial = value;
            PlayerPrefs.SetInt("tutorial", tutorial);
        }
    }

    public static int TotalStar
    {
        get
        {
            if (!PlayerPrefs.HasKey("totalStar"))
            {
                return 0;
            }
            return PlayerPrefs.GetInt("totalStar");
        }
        set
        {
            totalStar = value;
            PlayerPrefs.SetInt("totalStar", totalStar);
        }
    }

    public static int PreviousLevel
    {
        get
        {
            if (!PlayerPrefs.HasKey("previousLevel"))
            {
                return 1;
            }
            return PlayerPrefs.GetInt("previousLevel");
        }
        set
        {
            previousLevel = value;
            PlayerPrefs.SetInt("previousLevel", previousLevel);
        }
    }

    //power ups
    public static int ReplaceBoost
    {
        get
        {
            if (!PlayerPrefs.HasKey("replaceBoost"))
            {
                return 0;
            }
            return PlayerPrefs.GetInt("replaceBoost");
        }
        set
        {
            replaceBoost = value;
            PlayerPrefs.SetInt("replaceBoost", replaceBoost);
        }
    }

    public static int JokerBoost
    {
        get
        {
            if (!PlayerPrefs.HasKey("jokerBoost"))
            {
                return 0;
            }
            return PlayerPrefs.GetInt("jokerBoost");
        }
        set
        {
            jokerBoost = value;
            PlayerPrefs.SetInt("jokerBoost", jokerBoost);
        }
    }

    public static int HammerBoost
    {
        get
        {
            if (!PlayerPrefs.HasKey("hammerBoost"))
            {
                return 0;
            }
            return PlayerPrefs.GetInt("hammerBoost");
        }
        set
        {
            hammerBoost = value;
            PlayerPrefs.SetInt("hammerBoost", hammerBoost);
        }
    }

    // life update properties
    public static int TotalLife
    {
        get
        {
            return PlayerPrefs.GetInt("totalLife");
        }
        set
        {
            totalLife = value;
            PlayerPrefs.SetInt("totalLife", totalLife);
        }
    }

    public static string Time
    {
        get
        {
            return PlayerPrefs.GetString("time");
        }
        set
        {
            time = value;
            PlayerPrefs.SetString("time", time);
        }
    }

    public static float TimeSave
    {
        get
        {
            return PlayerPrefs.GetFloat("timeSave");
        }
        set
        {
            timeSave = value;
            PlayerPrefs.SetFloat("timeSave", timeSave);
        }
    }


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 1);
        }
        if (!PlayerPrefs.HasKey("vibration"))
        {
            PlayerPrefs.SetInt("vibration", 1);
        }
        if (!PlayerPrefs.HasKey("soundLevel"))
        {
            PlayerPrefs.SetInt("soundLevel", 1);
        }

        if (!PlayerPrefs.HasKey("darkmode"))
        {
            PlayerPrefs.SetInt("darkmode", 0);
        }

        if (!PlayerPrefs.HasKey("tutorial"))
        {
            PlayerPrefs.SetInt("tutorial", 1);
        }
        if (!PlayerPrefs.HasKey("totalStar"))
        {
            PlayerPrefs.SetInt("totalStar", 0);
        }
      
        if (!PlayerPrefs.HasKey("totalCoin"))
        {
            PlayerPrefs.SetInt("totalCoin", 0);
        }
        if (!PlayerPrefs.HasKey("replaceBoost"))
        {
            PlayerPrefs.SetInt("replaceBoost", 0);
        }
        if (!PlayerPrefs.HasKey("jokerBoost"))
        {
            PlayerPrefs.SetInt("jokerBoost", 0);
        }
        if (!PlayerPrefs.HasKey("hammerBoost"))
        {
            PlayerPrefs.SetInt("hammerBoost", 0);
        }

        //life recovery
        if (!PlayerPrefs.HasKey("totalLife"))
        {
            PlayerPrefs.SetInt("totalLife", 3);
        }


    }
}
