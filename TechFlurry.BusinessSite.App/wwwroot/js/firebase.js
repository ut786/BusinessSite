// Import the functions you need from the SDKs you need
import { initializeApp } from "https://www.gstatic.com/firebasejs/9.9.2/firebase-app.js";
import { getAnalytics } from "https://www.gstatic.com/firebasejs/9.9.2/firebase-analytics.js";
import { getPerformance } from "https://www.gstatic.com/firebasejs/9.9.2/firebase-performance.js";
import { getMessaging } from "https://www.gstatic.com/firebasejs/9.9.2/firebase-messaging.js";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
    apiKey: "AIzaSyANDGk78M_A7S9vlHrFOCRy4G3GJ-xkeG4",
    authDomain: "techflurry-6f21d.firebaseapp.com",
    projectId: "techflurry-6f21d",
    storageBucket: "techflurry-6f21d.appspot.com",
    messagingSenderId: "401074944157",
    appId: "1:401074944157:web:8c8b8bc159766c79d6fc74",
    measurementId: "G-NCNKERV8WN"
};

// Initialize Firebase
var app;
var analytics;
var perf;
var messaging;


export function initFirebase () {
    if (!app) {
        app = initializeApp(firebaseConfig);
    }
    if (!analytics) {
        analytics = getAnalytics(app);
    }
    if (!perf) {
        perf = getPerformance(app);
    }
    if (!messaging) {
        messaging = getMessaging(app);
    }
}