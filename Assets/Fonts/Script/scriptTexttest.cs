using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scriptTexttest : MonoBehaviour 
{
	public Text bubbleText;
    public Text bubbleTitleTxt;
	public Text bubbleText2;
    public GameObject bubble;
    public GameObject bubbleTitle;
	public GameObject bubble2;
	
	void Start ()
	{
        bubbleTitleTxt.text = "Font JazzCreate Bubble";
		bubbleText.text = "☺☻♥♦♣♠•◘○◙♂♀♪♫☼►◄↕‼▬↨↑↓→←\n" + "∟↔▲▼!#$%&'()*+,-./0123456789:;<=>?@\n"
            + "ABCDEFGHIJKLMNOPQRSTUVWXYZ\n`abcdefghijklmnopqrstuvwxyz\nîìÄÅÉæÆôöòûùÿÖÜ \n ¢£¥ƒáíóúñÑªº¿¬½¼¡«»░▒▓\n "
                + "│┤╣║╗┐└┴┬├─┼╚╔╩╦╣║╗•§©®¶" + "\nThanks for using fonts from JazzCreates2015©.";
		bubbleText2.text = "☺☻♥♦♣♠•◘○◙♂♀♪♫☼►◄↕‼▬↨↑↓→←\n" + "∟↔▲▼!#$%&'()*+,-./0123456789:;<=>?@\n"
			+ "ABCDEFGHIJKLMNOPQRSTUVWXYZ\n`abcdefghijklmnopqrstuvwxyz\nîìÄÅÉæÆôöòûùÿÖÜ \n ¢£¥ƒáíóúñÑªº¿¬½¼¡«»░▒▓\n "
			+ "│┤╣║╗┐└┴┬├─┼╚╔╩╦╣║╗•§©®¶" + "\nThanks for using fonts from JazzCreates2015©.";
	}
}