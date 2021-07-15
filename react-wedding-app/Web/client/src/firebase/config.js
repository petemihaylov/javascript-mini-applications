import firebase from 'firebase/app';
import 'firebase/storage';
import 'firebase/firestore';

// Firebase is used in order to save the images in external storage. 
// However the url will be stored in our database.
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
var firebaseConfig = {
    apiKey: "AIzaSyBWFH4mQVE9IEaUNSh7kjJk6PilW08xmho",
    authDomain: "wedding-invitation-93a7b.firebaseapp.com",
    projectId: "wedding-invitation-93a7b",
    storageBucket: "wedding-invitation-93a7b.appspot.com",
    messagingSenderId: "241410943448",
    appId: "1:241410943448:web:c3cedf2c4e700ca8d32aad",
    measurementId: "G-HNVB5VRMPX"
};

// Initialize Firebase
firebase.initializeApp(firebaseConfig);

const projectStorage = firebase.storage();
const projectFirestore = firebase.firestore();
const timestamp = firebase.firestore.FieldValue.serverTimestamp;

export { projectStorage, projectFirestore, timestamp };