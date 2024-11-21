import { initializeApp } from 'https://www.gstatic.com/firebasejs/10.14.1/firebase-app.js';
import { getMessaging, onBackgroundMessage } from 'https://www.gstatic.com/firebasejs/10.14.1/firebase-messaging.js';

const firebaseConfig = {
    apiKey: "AIzaSyDdIoSEwlKnPoj0rpR6SCabM1inuSKg5Ts",
    authDomain: "fieldops-65cc0.firebaseapp.com",
    projectId: "fieldops-65cc0",
    storageBucket: "fieldops-65cc0.appspot.com",
    messagingSenderId: "410053741923",
    appId: "1:410053741923:web:3733ff0f2d3792b05ad756",
    measurementId: "G-HH7C1N9RKY"
};
//const firebaseConfig = {
//    apiKey: "AIzaSyCG7c1HiRrT8Gn5psRfz2RPxrQeTu9hIxo",
//    authDomain: "fieldopsadmin.firebaseapp.com",
//    projectId: "fieldopsadmin",
//    storageBucket: "fieldopsadmin.appspot.com",
//    messagingSenderId: "301269992365",
//    appId: "1:301269992365:web:8c8c5ef86bcd673d695724"
//};

console.log("Initializing Firebase in Service Worker...");
const app = initializeApp(firebaseConfig);
const messaging = getMessaging(app);

// Background message handler
onBackgroundMessage(messaging, (payload) => {
    console.log('Received background message: ', payload);
    const notificationTitle = 'Background Message Title';
    const notificationOptions = {
        body: payload.notification.body,
        icon: '/firebase-logo.png'
    };

    self.registration.showNotification(notificationTitle, notificationOptions);
});
