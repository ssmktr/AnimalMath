using UnityEngine;
using System.Collections;

public class BackLoop : MonoBehaviour {
	private GameScript m_sGame = null;
	private Material m_mBack;
	private float m_fOffsetX = 0.0f;
	public float m_fLoopSpeed = 0.5f;
	public void SetManager(GameScript game){
		m_sGame = game;
	}
	void Start () {
		m_mBack = this.GetComponent<Material> ();
	}
	void Update () {
		if (!m_sGame.bPause) {
			m_fOffsetX += m_fLoopSpeed * Time.deltaTime;
			if (1 < m_fOffsetX) {
				m_fOffsetX -= 1;
			}
			this.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2 (m_fOffsetX, 0.0f);
		}
	}
}
