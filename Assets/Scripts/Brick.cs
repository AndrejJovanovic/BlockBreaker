using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	
	void Awake () {
		breakableCount = 0;
	}
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
			print ("Initialized for breaking" + breakableCount);
		}
		
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.8f);
		if(isBreakable) {	
			HandleHits();
		}
	}
	
	void HandleHits (){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if(maxHits <= timesHit){
			breakableCount--;
			print ("Breakable" + breakableCount);
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		}else {
			LoadSprites();
		}
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit -1;
		if (hitSprites[spriteIndex]) {
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	
	//TODO Remove this method once we can asctually win!
	void SimulateWin () {
		levelManager.LoadNextLevel();
	}
}
