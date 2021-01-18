using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Firebase;

public class Authentication : MonoBehaviour
{

    FirebaseApp app;
    FirebaseAuth auth;
    private string inputEmail;
    private string inputPass; //Will be changed


    private void Awake() {

        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available) {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                Debug.Log("Dependencys cleared. Firebase instance set.");
                app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            } else {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });

        auth = FirebaseAuth.DefaultInstance;
    }

    // Start is called before the first frame update
    void Start()
    {
        auth.StateChanged += AuthStateChange;
        if(auth.CurrentUser != null) {

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetUserUniq() {
        if(auth.CurrentUser != null) {
            return "" + auth.CurrentUser.UserId;
        }

        return "";

    }



    void AuthStateChange(object Senver, System.EventArgs eventArgs) {
        if (auth.CurrentUser == null) return;
        Debug.Log("Auth state changed: "+ auth.CurrentUser.UserId);
    }


    public void SignUp() {
        
        if (checkValidInput()) {

            auth.CreateUserWithEmailAndPasswordAsync(inputEmail, inputPass).ContinueWith(task => {

                if (task.IsCanceled) {
                    Debug.LogError("Sign up was cancelled.");
                    return;
                }

                if (task.IsFaulted) {
                    Debug.LogError("Sign up encountered an error: "+ task.Exception);
                    return;
                }


                FirebaseUser newUser = task.Result;
                Debug.LogFormat("Firebase user created. {0},{1}",newUser.UserId);

            });



        }

    }


    public void SignIn() {
        Debug.Log("Sign-in called");
        if (checkValidInput()) {
            Debug.Log("Sending to firebase async.");
            auth.SignInWithEmailAndPasswordAsync(inputEmail, inputPass).ContinueWith(task => {
                Debug.Log("Task underway.");
                if (task.IsCanceled) {
                    Debug.LogError("Sign in was cancelled.");
                    return;
                }

                if (task.IsFaulted) {
                    Debug.LogError("Sign in encountered an error: " + task.Exception);
                    return;
                }


                FirebaseUser newUser = task.Result;
                Debug.Log("Firebase user signed in:"+ newUser.UserId);

            });
        }

        Debug.Log("User output please?:"+auth.CurrentUser.UserId);

    }


    public void ReadInputs(InputField em,InputField ps) {
        
        inputEmail = em.text;
        inputPass = ps.text;


    }

    public void ReadInputsString(string em, string ps) {
        inputEmail = em;
        inputPass = ps;


    }

    public bool checkValidInput() {
        if(inputEmail == "" || inputPass == "") {
            //Default login for now!
            inputEmail = "cat@meow.com";
            inputPass = "pati21";
            Debug.LogFormat("Read email and password: {0},{1}", inputEmail, inputPass);
            return true;
        }
        return true;
    }

}
