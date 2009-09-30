// 
// PreferencesWin.cs
//  
// Author:
//       Giannis Skoulis
//       Thanos Papathanasiou
// 
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using Monogle;
using Gtk;

public partial class PreferencesWin : Gtk.Dialog
{
	Preferences pref;
	
	public PreferencesWin(Preferences pr)
	{
		pref = pr;
		this.Build();
		proxyEntry.Text = pref.proxy;
		portSpinButton.Value = pref.proxyPort;
		
		switch(pref.pStatus) {
			case "no":
				noProxyRadioButton.Click();
				break;
			case "system":
				systemProxyRadioButton.Click();
				break;
			case "manual":
				manualProxyRadioButton.Click();
				break;
		}
		
		switch (pref.resultsSize){
			case "small":
				sizeComboBox.Active = 0;
				break;
			case "large":
				sizeComboBox.Active = 1;
				break;
		}
		
		switch (pref.safe){
			case "active":
				filterComboBox.Active = 0;
				break;
			case "moderate":
				filterComboBox.Active = 1;
				break;
			case "off":
				filterComboBox.Active = 2;
				break;
		}
		
		switch (pref.resultsWritenInLang){
			case "lang_ar":
				resultLangComboBox.Active = 0;
				break;
			case "lang_bg":
				resultLangComboBox.Active = 1;
				break;
			case "lang_ca":
				resultLangComboBox.Active = 2;
				break;
			case "lang_zh-CN":
				resultLangComboBox.Active = 3;
				break;
			case "lang_zh-TW":
				resultLangComboBox.Active = 4;
				break;
			case "lang_hr":
				resultLangComboBox.Active = 5;
				break;
			case "lang_cs":
				resultLangComboBox.Active = 6;
				break;
			case "lang_da":
				resultLangComboBox.Active = 7;
				break;
			case "lang_nl":
				resultLangComboBox.Active = 8;
				break;
			case "lang_en":
				resultLangComboBox.Active = 9;
				break;
			case "lang_et":
				resultLangComboBox.Active = 10;
				break;
			case "lang_fi":
				resultLangComboBox.Active = 11;
				break;
			case "lang_fr":
				resultLangComboBox.Active = 12;
				break;
			case "lang_de":
				resultLangComboBox.Active = 13;
				break;
			case "lang_el":
				resultLangComboBox.Active = 14;
				break;
			case "lang_iw":
				resultLangComboBox.Active = 15;
				break;
			case "lang_hu":
				resultLangComboBox.Active = 16;
				break;
			case "lang_is":
				resultLangComboBox.Active = 17;
				break;
			case "lang_id":
				resultLangComboBox.Active = 18;
				break;
			case "lang_it":
				resultLangComboBox.Active = 19;
				break;
			case "lang_ja":
				resultLangComboBox.Active = 20;
				break;
			case "lang_ko":
				resultLangComboBox.Active = 21;
				break;
			case "lang_lv":
				resultLangComboBox.Active = 22;
				break;
			case "lang_lt":
				resultLangComboBox.Active = 23;
				break;
			case "lang_no":
				resultLangComboBox.Active = 24;
				break;
			case "lang_pl":
				resultLangComboBox.Active = 25;
				break;
			case "lang_pt":
				resultLangComboBox.Active = 26;
				break;
			case "lang_ro":
				resultLangComboBox.Active = 27;
				break;
			case "lang_ru":
				resultLangComboBox.Active = 28;
				break;
			case "lang_sr":
				resultLangComboBox.Active = 29;
				break;
			case "lang_sk":
				resultLangComboBox.Active = 30;
				break;
			case "lang_sl":
				resultLangComboBox.Active = 31;
				break;
			case "lang_es":
				resultLangComboBox.Active = 32;
				break;
			case "lang_sv":
				resultLangComboBox.Active = 33;
				break;
			case "lang_tr":
				resultLangComboBox.Active = 34;
				break;
		}
		
		switch (pref.hostLang){
			case "af":
				hostLangComboBox.Active = 0;
				break;
			case "sq":
				hostLangComboBox.Active = 1;
				break;
			case "sm":
				hostLangComboBox.Active = 2;
				break;
			case "ar":
				hostLangComboBox.Active = 3;
				break;
			case "az":
				hostLangComboBox.Active = 4;
				break;
			case "eu":
				hostLangComboBox.Active = 5;
				break;
			case "be":
				hostLangComboBox.Active = 6;
				break;
			case "bn":
				hostLangComboBox.Active = 7;
				break;
			case "bh":
				hostLangComboBox.Active = 8;
				break;
			case "bs":
				hostLangComboBox.Active = 9;
				break;
			case "bg":
				hostLangComboBox.Active = 10;
				break;
			case "ca":
				hostLangComboBox.Active = 11;
				break;
			case "zh-CN":
				hostLangComboBox.Active = 12;
				break;
			case "zh-TW":
				hostLangComboBox.Active = 13;
				break;
			case "hr":
				hostLangComboBox.Active = 14;
				break;
			case "cs":
				hostLangComboBox.Active = 15;
				break;
			case "da":
				hostLangComboBox.Active = 16;
				break;
			case "nl":
				hostLangComboBox.Active = 17;
				break;
			case "en":
				hostLangComboBox.Active = 18;
				break;
			case "eo":
				hostLangComboBox.Active = 19;
				break;
			case "et":
				hostLangComboBox.Active = 20;
				break;
			case "fo":
				hostLangComboBox.Active = 21;
				break;
			case "fi":
				hostLangComboBox.Active = 22;
				break;
			case "fr":
				hostLangComboBox.Active = 23;
				break;
			case "fy":
				hostLangComboBox.Active = 24;
				break;
			case "gl":
				hostLangComboBox.Active = 25;
				break;
			case "ka":
				hostLangComboBox.Active = 26;
				break;
			case "de":
				hostLangComboBox.Active = 27;
				break;
			case "el":
				hostLangComboBox.Active = 28;
				break;
			case "gu":
				hostLangComboBox.Active = 29;
				break;
			case "iw":
				hostLangComboBox.Active = 30;
				break;
			case "hi":
				hostLangComboBox.Active = 31;
				break;
			case "hu":
				hostLangComboBox.Active = 32;
				break;
			case "is":
				hostLangComboBox.Active = 33;
				break;
			case "id":
				hostLangComboBox.Active = 34;
				break;
			case "ia":
				hostLangComboBox.Active = 35;
				break;
			case "ga":
				hostLangComboBox.Active = 36;
				break;
			case "it":
				hostLangComboBox.Active = 37;
				break;
			case "ja":
				hostLangComboBox.Active = 38;
				break;
			case "jw":
				hostLangComboBox.Active = 39;
				break;
			case "kn":
				hostLangComboBox.Active = 40;
				break;
			case "ko":
				hostLangComboBox.Active = 41;
				break;
			case "la":
				hostLangComboBox.Active = 42;
				break;
			case "lv":
				hostLangComboBox.Active = 43;
				break;
			case "lt":
				hostLangComboBox.Active = 44;
				break;
			case "mk":
				hostLangComboBox.Active = 45;
				break;
			case "ms":
				hostLangComboBox.Active = 46;
				break;
			case "ml":
				hostLangComboBox.Active = 47;
				break;
			case "mt":
				hostLangComboBox.Active = 48;
				break;
			case "mr":
				hostLangComboBox.Active = 49;
				break;
			case "ne":
				hostLangComboBox.Active = 50;
				break;
			case "no":
				hostLangComboBox.Active = 51;
				break;
			case "nn":
				hostLangComboBox.Active = 52;
				break;
			case "oc":
				hostLangComboBox.Active = 53;
				break;
			case "fa":
				hostLangComboBox.Active = 54;
				break;
			case "pl":
				hostLangComboBox.Active = 55;
				break;
			case "pt-BR":
				hostLangComboBox.Active = 56;
				break;
			case "pt-PT":
				hostLangComboBox.Active = 57;
				break;
			case "pa":
				hostLangComboBox.Active = 58;
				break;
			case "ro":
				hostLangComboBox.Active = 59;
				break;
			case "ru":
				hostLangComboBox.Active = 60;
				break;
			case "gd":
				hostLangComboBox.Active = 61;
				break;
			case "sr":
				hostLangComboBox.Active = 62;
				break;
			case "si":
				hostLangComboBox.Active = 63;
				break;
			case "sk":
				hostLangComboBox.Active = 64;
				break;
			case "sl":
				hostLangComboBox.Active = 65;
				break;
			case "es":
				hostLangComboBox.Active = 66;
				break;
			case "su":
				hostLangComboBox.Active = 67;
				break;
			case "sw":
				hostLangComboBox.Active = 68;
				break;
			case "sv":
				hostLangComboBox.Active = 69;
				break;
			case "tl":
				hostLangComboBox.Active = 70;
				break;
			case "ta":
				hostLangComboBox.Active = 71;
				break;
			case "te":
				hostLangComboBox.Active = 72;
				break;
			case "th":
				hostLangComboBox.Active = 73;
				break;
			case "ti":
				hostLangComboBox.Active = 74;
				break;
			case "tr":
				hostLangComboBox.Active = 75;
				break;
			case "uk":
				hostLangComboBox.Active = 76;
				break;
			case "ur":
				hostLangComboBox.Active = 77;
				break;
			case "uz":
				hostLangComboBox.Active = 78;
				break;
			case "vi":
				hostLangComboBox.Active = 79;
				break;
			case "cy":
				hostLangComboBox.Active = 80;
				break;
			case "xh":
				hostLangComboBox.Active = 81;
				break;
			case "zu":
				hostLangComboBox.Active = 82;
				break;
		}
	}
	
	protected virtual void OnClose (object sender, System.EventArgs e)
	{
		this.Destroy();
	}

	protected virtual void OnTonggle (object sender, System.EventArgs e)
	{
		if (manualProxyEntryBox.Sensitive == false) manualProxyEntryBox.Sensitive = true;
		else manualProxyEntryBox.Sensitive = false;
	}

	protected virtual void OnNoProxy (object sender, System.EventArgs e)
	{
		pref.pStatus = "no";
	}

	protected virtual void OnSystemProxy (object sender, System.EventArgs e)
	{
		pref.pStatus = "system";
	}

	protected virtual void OnManualProxy (object sender, System.EventArgs e)
	{
		pref.pStatus = "manual";
	}

	protected virtual void OnProxyChange (object sender, System.EventArgs e)
	{
		pref.proxy = proxyEntry.Text;
	}

	protected virtual void OnProxyPortChange (object sender, System.EventArgs e)
	{
		pref.proxyPort = portSpinButton.ValueAsInt;
	}

	protected virtual void OnSizeComboBoxChanged (object sender, System.EventArgs e)
	{
		ComboBox cb = (ComboBox) sender;
		switch (cb.ActiveText){
			case "4":
				pref.resultsSize = "small";
				break;
			case "8":
				pref.resultsSize = "large";
				break;
		}
	}

	protected virtual void OnFilterComboBoxChanged (object sender, System.EventArgs e)
	{
		ComboBox cb = (ComboBox) sender;
		pref.safe = cb.ActiveText.ToLower();
	}

	protected virtual void OnHostLangComboBoxChanged (object sender, System.EventArgs e)
	{
		ComboBox cb = (ComboBox) sender;
		switch (cb.ActiveText){
			case "Afrikaans":
				pref.hostLang = "af";
				break;
			case "Albanian":
				pref.hostLang = "sq";
				break;
			case "Amharic":
				pref.hostLang = "sm";
				break;
			case "Arabic":
				pref.hostLang = "ar";
				break;
			case "Azerbaijani":
				pref.hostLang = "az";
				break;
			case "Basque":
				pref.hostLang = "eu";
				break;
			case "Belarusian":
				pref.hostLang = "be";
				break;
			case "Bengali":
				pref.hostLang = "bn";
				break;
			case "Bihari":
				pref.hostLang = "bh";
				break;
			case "Bosnian":
				pref.hostLang = "bs";
				break;
			case "Bulgarian":
				pref.hostLang = "bg";
				break;
			case "Catalan":
				pref.hostLang = "ca";
				break;
			case "Chinese (Simplified)":
				pref.hostLang = "zh-CN";
				break;
			case "Chinese (Traditional)":
				pref.hostLang = "zh-TW";
				break;
			case "Croation":
				pref.hostLang = "hr";
				break;
			case "Czech":
				pref.hostLang = "cs";
				break;
			case "Danish":
				pref.hostLang = "da";
				break;
			case "Dutch":
				pref.hostLang = "nl";
				break;
			case "English":
				pref.hostLang = "en";
				break;
			case "Esperanto":
				pref.hostLang = "eo";
				break;
			case "Estonian":
				pref.hostLang = "et";
				break;
			case "Faroese":
				pref.hostLang = "fo";
				break;
			case "Finnish":
				pref.hostLang = "fi";
				break;
			case "French":
				pref.hostLang = "fr";
				break;
			case "Frisian":
				pref.hostLang = "fy";
				break;
			case "Galician":
				pref.hostLang = "gl";
				break;
			case "Georgian":
				pref.hostLang = "ka";
				break;
			case "German":
				pref.hostLang = "de";
				break;
			case "Greek":
				pref.hostLang = "el";
				break;
			case "Gujarati":
				pref.hostLang = "gu";
				break;
			case "Hebrew":
				pref.hostLang = "iw";
				break;
			case "Hindi":
				pref.hostLang = "hi";
				break;
			case "Hungarian":
				pref.hostLang = "hu";
				break;
			case "Icelandic":
				pref.hostLang = "is";
				break;
			case "Indonesian":
				pref.hostLang = "id";
				break;
			case "Interlingua":
				pref.hostLang = "ia";
				break;
			case "Irish":
				pref.hostLang = "ga";
				break;
			case "Italian":
				pref.hostLang = "it";
				break;
			case "Japanese":
				pref.hostLang = "ja";
				break;
			case "Javanese":
				pref.hostLang = "jw";
				break;
			case "Kannada":
				pref.hostLang = "kn";
				break;
			case "Korean":
				pref.hostLang = "ko";
				break;
			case "Latin":
				pref.hostLang = "la";
				break;
			case "Latvian":
				pref.hostLang = "lv";
				break;
			case "Lithuanian":
				pref.hostLang = "lt";
				break;
			case "Macedonian":
				pref.hostLang = "mk";
				break;
			case "Malay":
				pref.hostLang = "ms";
				break;
			case "Malayam":
				pref.hostLang = "ml";
				break;
			case "Maltese":
				pref.hostLang = "mt";
				break;
			case "Marathi":
				pref.hostLang = "mr";
				break;
			case "Nepali":
				pref.hostLang = "ne";
				break;
			case "Norwegian":
				pref.hostLang = "no";
				break;
			case "Norwegian (Nynorsk)":
				pref.hostLang = "nn";
				break;
			case "Occitan":
				pref.hostLang = "oc";
				break;
			case "Persian":
				pref.hostLang = "fa";
				break;
			case "Polish":
				pref.hostLang = "pl";
				break;
			case "Portuguese (Brazil)":
				pref.hostLang = "pt-BR";
				break;
			case "Portuguese (Portugal)":
				pref.hostLang = "pt-PT";
				break;
			case "Punjabi":
				pref.hostLang = "pa";
				break;
			case "Romanian":
				pref.hostLang = "ro";
				break;
			case "Russian":
				pref.hostLang = "ru";
				break;
			case "Scots Gaelic":
				pref.hostLang = "gd";
				break;
			case "Serbian":
				pref.hostLang = "sr";
				break;
			case "Sinhalese":
				pref.hostLang = "si";
				break;
			case "Slovak":
				pref.hostLang = "sk";
				break;
			case "Slovenian":
				pref.hostLang = "sl";
				break;
			case "Spanish":
				pref.hostLang = "es";
				break;
			case "Sudanese":
				pref.hostLang = "su";
				break;
			case "Swahili":
				pref.hostLang = "sw";
				break;
			case "Swedish":
				pref.hostLang = "sv";
				break;
			case "Tagalog":
				pref.hostLang = "tl";
				break;
			case "Tamil":
				pref.hostLang = "ta";
				break;
			case "Telugu":
				pref.hostLang = "te";
				break;
			case "Thai":
				pref.hostLang = "th";
				break;
			case "Tigrinya":
				pref.hostLang = "ti";
				break;
			case "Turkish":
				pref.hostLang = "tr";
				break;
			case "Ukrainian":
				pref.hostLang = "uk";
				break;
			case "Urdu":
				pref.hostLang = "ur";
				break;
			case "Uzbek":
				pref.hostLang = "uz";
				break;
			case "Vietnamese":
				pref.hostLang = "vi";
				break;
			case "Welsh":
				pref.hostLang = "cy";
				break;
			case "Xhosa":
				pref.hostLang = "xh";
				break;
			case "Zulu":
				pref.hostLang = "zu";
				break;
		}
	}

	protected virtual void OnResultComboBoxChanged (object sender, System.EventArgs e)
	{
		ComboBox cb = (ComboBox) sender;
		switch (cb.ActiveText){
			case "Arabic":
				pref.resultsWritenInLang = "lang_ar";
				break;
			case "Bulgarian":
				pref.resultsWritenInLang = "lang_bg";
				break;
			case "Catalan":
				pref.resultsWritenInLang = "lang_ca";
				break;
			case "Chinese (Simplified)":
				pref.resultsWritenInLang = "lang_zh-CN";
				break;
			case "Chinese (Traditional)":
				pref.resultsWritenInLang = "lang_zh-TW";
				break;
			case "Croation":
				pref.resultsWritenInLang = "lang_hr";
				break;
			case "Czech":
				pref.resultsWritenInLang = "lang_cs";
				break;
			case "Danish":
				pref.resultsWritenInLang = "lang_da";
				break;
			case "Dutch":
				pref.resultsWritenInLang = "lang_nl";
				break;
			case "English":
				pref.resultsWritenInLang = "lang_en";
				break;
			case "Estonian":
				pref.resultsWritenInLang = "lang_et";
				break;
			case "Finnish":
				pref.resultsWritenInLang = "lang_fi";
				break;
			case "French":
				pref.resultsWritenInLang = "lang_fr";
				break;
			case "German":
				pref.resultsWritenInLang = "lang_de";
				break;
			case "Greek":
				pref.resultsWritenInLang = "lang_el";
				break;
			case "Hebrew":
				pref.resultsWritenInLang = "lang_iw";
				break;
			case "Hungarian":
				pref.resultsWritenInLang = "lang_hu";
				break;
			case "Icelandic":
				pref.resultsWritenInLang = "lang_is";
				break;
			case "Indonesian":
				pref.resultsWritenInLang = "lang_id";
				break;
			case "Italian":
				pref.resultsWritenInLang = "lang_it";
				break;
			case "Japanese":
				pref.resultsWritenInLang = "lang_ja";
				break;
			case "Korean":
				pref.resultsWritenInLang = "lang_ko";
				break;
			case "Latvian":
				pref.resultsWritenInLang = "lang_lv";
				break;
			case "Lithuanian":
				pref.resultsWritenInLang = "lang_lt";
				break;
			case "Norwegian":
				pref.resultsWritenInLang = "lang_no";
				break;
			case "Polish":
				pref.resultsWritenInLang = "lang_pl";
				break;
			case "Portuguese":
				pref.resultsWritenInLang = "lang_pt";
				break;
			case "Romanian":
				pref.resultsWritenInLang = "lang_ro";
				break;
			case "Russian":
				pref.resultsWritenInLang = "lang_ru";
				break;
			case "Serbian":
				pref.resultsWritenInLang = "lang_sr";
				break;
			case "Slovak":
				pref.resultsWritenInLang = "lang_sk";
				break;
			case "Slovenian":
				pref.resultsWritenInLang = "lang_sl";
				break;
			case "Spanish":
				pref.resultsWritenInLang = "lang_es";
				break;
			case "Swedish":
				pref.resultsWritenInLang = "lang_sv";
				break;
			case "Turkish":
				pref.resultsWritenInLang = "lang_tr";
				break;
		}
	}
}
