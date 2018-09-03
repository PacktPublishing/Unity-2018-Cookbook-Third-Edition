using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

// adapted from answers.unity.com sample code posted by 'Statememt' (Dec 2013)
// https://answers.unity.com/questions/601131/editorgui-editorguilayout-gui-guilayout-pshhh-when.html
public class MyEditorWindow : EditorWindow 
 {
     MyGUITextField username;
     MyGUITextField realname;
     MyGUIButton registerButton;
     MyGUIFlexibleSpace flexibleSpace;

     // Optional, but may be convenient.
     List<IMyGUI> guiComponents = new List<IMyGUI>();

     [MenuItem("Example/Show Window")]
     public static void ShowWindow () {
         GetWindow<MyEditorWindow>("My Reg Panel", true);
     }

     // setup all our GUI obejcts
     void OnEnable()
     {
        username = new MyGUITextField ();
        username.label.text = "Username";
        username.text = "JDoe";
        
        realname = new MyGUITextField ();
        realname.label.text = "Real name";
        realname.text = "John Doe";
                
        registerButton = new MyGUIButton ();
        registerButton.label.text = "Register";
         // add LogUser() to button's OnClick event broadcaster
        registerButton.OnClick += LogUser;
        
         bool centerFully = true;
         guiComponents.Add(new MyGUILabel("Unity 2018 is great", centerFully));
        
         guiComponents.Add (username);
         guiComponents.Add (realname);
         guiComponents.Add(new MyGUIFlexibleSpace());
         guiComponents.Add (registerButton);        
     }

     // remove method LogUser() from button's OnClick event broadcaster
     private void OnDisable()
     {
         registerButton.OnClick -= LogUser;
     }

     // actions to perform when button clicked
     void LogUser()
     {
         var msg = "Registering " + realname.text + " as " + username.text;
         Debug.Log (msg);
     }

     // loop through to display all GUI controls each frame
     void OnGUI() {
         foreach (var component in guiComponents)
             component.OnGUI();
     }
 }
