using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : MonoBehaviour {

	public GameObject[] popUps;

	public GameObject ptButton;
	public GameObject enButton;
	public GameObject ptCircle;
	public GameObject enCircle;

	public GameObject fsButton;
	public GameObject winButton;
	public GameObject fsCircle;
	public GameObject winCircle;

	public Sprite emptyCircle;
	public Sprite filledCircle;

	public Slider mscSlider;
	public Slider sfxSlider;

	public void OpenPopUp(int popUpIdx) {
		CloseAllPopUps();
		try {
			popUps[popUpIdx].SetActive(true);
		} catch (IndexOutOfRangeException e) {
			Debug.LogError("Falha ao tentar abrir pop-up com index inválido: " + e.Message);
		}
	}

	public void CloseAllPopUps() {
		foreach (GameObject popUp in popUps) {
			popUp.SetActive(false);
		}
	}

	public void SetEnglishUI(bool english) {
		ptCircle.GetComponent<Image>().sprite =  english ? emptyCircle : filledCircle;
		enCircle.GetComponent<Image>().sprite = !english ? emptyCircle : filledCircle;
	}

	public void SetFullscreenUI(bool fullscreen) {
		winCircle.GetComponent<Image>().sprite = fullscreen ? emptyCircle : filledCircle;
		fsCircle.GetComponent<Image>().sprite = !fullscreen ? emptyCircle : filledCircle;
	}

	public ConfigsModel GetConfigs() {
		ConfigsModel cfg = new ConfigsModel();
		cfg.SetEnglish(enCircle.GetComponent<Image>().sprite == filledCircle);
		cfg.SetFullscreen(fsCircle.GetComponent<Image>().sprite == filledCircle);
		cfg.SetMusicVol(mscSlider.value);
		cfg.SetSfxVol(sfxSlider.value);
		return cfg;
	}

	public void UpdateConfigs(ConfigsModel cfg) {
		SetEnglishUI(cfg.GetEnglish());
		SetFullscreenUI(cfg.GetFullscreen());
		mscSlider.value = cfg.GetMusicVol();
		sfxSlider.value = cfg.GetSfxVol();
	}

}
