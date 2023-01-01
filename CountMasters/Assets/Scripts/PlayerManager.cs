using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class PlayerManager : MonoBehaviour
{
    public Transform player;
    private int numberOFStickmans;
    [SerializeField]
    private TextMeshPro CounterTxt;
    [SerializeField]
    private GameObject stickMan;


    [Range(0f, 1f)][SerializeField]
    private float DistanceFactor, Radius;
    void Start()
    {
        player = transform;
        
        numberOFStickmans = transform.childCount - 1;
        CounterTxt.text = numberOFStickmans.ToString();

    }


    void Update()
    {

    }


    private void FormatStickman()
    {
        for (int i = 0; i < player.childCount; i++)
        {
            var x = DistanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * Radius);
            var z = DistanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * Radius);

            var NewPos = new Vector3(x, -0.5016661f,  z);

           // player.transform.DOlocalMove(NewPos, 1f).SetEase(Ease.OutBack);
        }
    }

    private void MakeStickMan(int number)
    {
        for (int i =0; i< number; i++)
        {
            Instantiate(stickMan, transform.position, Quaternion.identity, transform);
        }

        numberOFStickmans = transform.childCount - 1;

        CounterTxt.text = numberOFStickmans.ToString();    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("gate"))
        {
            other.transform.parent.GetChild(0).GetComponent<BoxCollider>().enabled = false;
            other.transform.parent.GetChild(1).GetComponent<BoxCollider>().enabled = false;

            var gateManager = other.GetComponent<GateManager>();

            if (gateManager.multiply)
            {
                MakeStickMan(numberOFStickmans * gateManager.randomNumber);
            }
            else
            {
                MakeStickMan(numberOFStickmans + gateManager.randomNumber);
            }
        }
    }
}
