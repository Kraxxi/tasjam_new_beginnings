using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplat : MonoBehaviour
{
    public List<Sprite> bloodSplats;
    public SpriteRenderer sr;
    public float minScale;
    public float maxScale;
    public float minOpacity;
    public float maxOpacity;
    
    private void Start()
    {
        sr.sprite = bloodSplats[Random.Range(0, bloodSplats.Count)];
        sr.color = new Color(255, 255, 255, Random.Range(minOpacity, maxOpacity));
        float randScale = Random.Range(minScale, maxScale);

        transform.localScale = new Vector3(randScale, randScale, randScale);

        float randRotation = Random.Range(0, 360);
        
        transform.rotation = Quaternion.Euler(0, 0, randRotation);
        
        GameState.bloodSplats.Enqueue(gameObject);

        if (GameState.bloodSplats.Count > 1000)
        {
            Destroy(GameState.bloodSplats.Dequeue());
        }
    }
}
