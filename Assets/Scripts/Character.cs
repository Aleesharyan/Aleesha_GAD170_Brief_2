using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum ClassType
    {
        mage,
        knight,
        warior
    }

    public ClassType classType;
    public int health;
    public int attack;
    public int defense;

    // Start is called before the first frame update
    void Awake()
    {
        InitStats();

        Debug.Log(classType);
    }

    private void InitStats()
    {
        switch (Random.Range(1, 4))
        {
            case 1:
                classType = ClassType.mage;
                break;
            case 2:
                classType = ClassType.knight;
                break;
            case 3:
                classType = ClassType.warior;
                break;
        }


        switch (classType)
        {
            case ClassType.mage:
                health = 110;
                attack = Random.Range(25, 50);
                defense = Random.Range(10, 20);
                break;
            case ClassType.warior:
                health = 100;
                attack = Random.Range(15, 25);
                defense = Random.Range(1, 10);
                break;
            case ClassType.knight:
                health = 100;
                attack = Random.Range(10, 20);
                defense = Random.Range(20, 30);
                break;
        }
        

    }

    public Character(ClassType CT)
    {
        this.classType = CT;
    }
}
