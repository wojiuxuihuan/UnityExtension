//The editor window can be found in Window > Open Code Editor

//Feel free to edit and use this script however you like, for any purpose


#pragma strict

class CodeEditor extends EditorWindow {	
	
	//sets up the necessary variables
	var text : String = "Nothing Opened..."; //string to show in text area in window
	var ScriptToEdit : MonoScript; //Script file being edited
	var scroll : Vector2; //This is used for scrolling down in the window
	var textpath = "Assets/example.js"; //This is where the script is saved to, it includes the scripts name 'example' and file type '.js'

		
	//sets menu item to open the window
	@MenuItem("Window/Open Code Editor")
static function ShowWindow() {       
    //opens the window when the menu item is clicked on.
    //it opens a new window every time, so more than one window can be opened
    var window : CodeEditor = CreateInstance(CodeEditor);   //opens window    
    window.title = "Code Editor";   //sets window title
    window.Show();    
}
	
function OnGUI() {

		//The labels you can see at the top of the editor window
		GUILayout.Label("IMPORTANT: The editing of scripts is limited to 65,536 characters, including new lines.");
		GUILayout.Label("And there may be rare errors related to new lines which are not shown here, but can be corrected in MonoDevelop.");
		
		//field to drag and drop scripts into as a 'MonoScript'. This can be changed to 'TextAsset' if required.
		var newScriptToEdit = EditorGUILayout.ObjectField(ScriptToEdit, MonoScript);		
	
		//checks if a different script has been dragged into the 'MonoScript' field above
		if (newScriptToEdit != ScriptToEdit) {
			ReadTextAsset(newScriptToEdit); //calls function to replace text in text area field with text from the new script
		}
		
		//adds the save button to the window
		if (GUILayout.Button("Save to path")) {
			Save(); //calls function to create/overwrite the script at the file path
		}
			
		EditorGUILayout.BeginHorizontal(); //if you look in the window, the two refresh buttons are side by side. This line begins the horizontal layout for this.
		
			//Adds the button to refresh the editor window e.g. to undo all changes to the script, or reset it, if it has been edited externally
			if (GUILayout.Button("Refresh Script")) {
				ReadTextAsset(newScriptToEdit); //calls function to replace text in text area field with text from the selected script
				AssetDatabase.Refresh(); //tells unity to compile the script
			}
			
			//Adds a second refresh button. This button refreshes the path field to save the script at.
			if (GUILayout.Button("Refresh Path")) {
				textpath = AssetDatabase.GetAssetPath(ScriptToEdit); //sets the path variable (which can be edited in the window), to the path of the selected script
			}
		EditorGUILayout.EndHorizontal(); //ends the horizontal, so the next fields are bellow, rather than to the right
		
		//Adds text field to edit the 'textpath' string, where the script will be saved when the 'Save to path' button is pressed		
		textpath = EditorGUILayout.TextField("Path: ", textpath);
		
		//begins a scroll view allowing the ability to scroll up and down within the window so you can see the whole script
		//the fields before this are not in between the beginning and end of the scroll view, so they do not change position when you scroll
		scroll = EditorGUILayout.BeginScrollView(scroll);		
			
			//if you wish to add numbers showing the line number you could do this here within a horizontal layout
			
			text = GUILayout.TextArea(text);  //adds the text area field displaying the script which has been selected

		EditorGUILayout.EndScrollView(); //the scroll view has to be ended

Repaint(); //refreshes the editor window, even when it isn't selected. This isn't really necessary, but it may be useful if you were going to make the editor do other things.
           //however, with longer scripts it may temporarily slow down your computer

}
		
//This is called to replace the edited text in the text field with the text from the selected script file
function ReadTextAsset(txt : MonoScript) {	//includes the script as a parameter called 'txt'
	text = txt.text; //sets the text displayed to the text in the selected file
	ScriptToEdit = txt;
}
		
//function called to 'save' the text. It overwrites the file as the file path.
function Save () {
		var outfile =  new System.IO.StreamWriter(textpath); //creates a 'StreamWriter' variable which creates the file at the file path
		outfile.WriteLine(text); //the text which has been edited is added to the file just saved, through the StreamWriter
		outfile.Close(); //ends the editing of the saved file
		AssetDatabase.Refresh(); //tells unity to compile the script
}

}