using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceCounter : MonoBehaviour
{
    [SerializeField] private GameObject barn
        ;
    private FenceUpgrader fenceUpgrader;

    [SerializeField] private TMP_Text woodText;
    [SerializeField] private TMP_Text crystalText;


    // Start is called before the first frame update
    void Start()
    {
        fenceUpgrader = barn.GetComponent<FenceUpgrader>();
    }

    // Update is called once per frame
    void Update()
    {
        woodText.text = fenceUpgrader.woodCount.ToString();
        crystalText.text = fenceUpgrader.crystalCount.ToString();
    }
}
