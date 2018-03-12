using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
class Wrecks
{
    public GameObject wrecksToDiscover;
}

public class Scr_CollectEvidence : MonoBehaviour {

    public Image evidenceUIOne;
    public Image evidenceUITwo;
    public Image evidenceUIThree;

    public int amountPickedUp = 0;
    private int warningAmount = 0;

    [SerializeField]
    Wrecks[] ShowOnOneEv;
    [SerializeField]
    Wrecks[] ShowOnTwoEv;
    public GameObject BossBlockade;
    


    void Update()
    {
        if (amountPickedUp == 1)
        {
            UpdateUI(evidenceUIOne);
            ShowWrecks(ShowOnOneEv);
        }

        else if (amountPickedUp == 2)
        {
            UpdateUI(evidenceUITwo);
            ShowWrecks(ShowOnTwoEv);
        }

        else if (amountPickedUp == 3)
        {
            UpdateUI(evidenceUIThree);

            if (BossBlockade.activeInHierarchy)
            {
                BossBlockade.SetActive(false);
            }
            else if (!BossBlockade.activeInHierarchy && warningAmount < 2)
            {
                Debug.LogWarning("Make sure to set object blocking the boss room as active as a default!");
                warningAmount++;
            }
        }
    }

    void ShowWrecks(Wrecks[] arrayOfWrecks)
    {
        for (int i = 0; i < arrayOfWrecks.Length; i++)
        {
            if (!arrayOfWrecks[i].wrecksToDiscover.activeInHierarchy)
            {
                arrayOfWrecks[i].wrecksToDiscover.SetActive(true);
            }
            else
            {
                continue;
            }
        }
    }

    void UpdateUI(Image evidence)
    {
        if (!evidence.gameObject.activeInHierarchy)
        {
            evidence.gameObject.SetActive(true);
        }
    }
}
