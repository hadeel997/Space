using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AsteroidHit : MonoBehaviour
{
    [SerializeField] private GameObject astroidExplosion;
    [SerializeField] private GameController gameController;
    [SerializeField] private GameObject popupCanvas;


    private void Awake()
    {
        gameController=FindObjectOfType<GameController>();
    }

    public void AsteroidDestroyed()
    {
        Instantiate(astroidExplosion, transform.position, transform.rotation);

        if (GameController.currentGameStatus ==GameController.GameState.Playing) 

        {
            float distanceFromPlayer = Vector3.Distance(transform.position, Vector3.zero);
            Debug.Log(distanceFromPlayer);
            int bonusPoints = (int)distanceFromPlayer;
            int astroidScore = 10 * bonusPoints;
            popupCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = astroidScore.ToString();

            GameObject astasteroidpopup = Instantiate(popupCanvas, transform.position, Quaternion.identity);
            astasteroidpopup.transform.localScale = new Vector3(transform.localScale.x * (distanceFromPlayer / 10), transform.localScale.y * (distanceFromPlayer / 10), transform.localScale.z * distanceFromPlayer / 10);

            gameController.UpdatePlayerScore(astroidScore);
        }
        
       
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
