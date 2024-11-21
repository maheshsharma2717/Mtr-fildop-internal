//importScripts('https://www.gstatic.com/firebasejs/10.14.1/firebase-app.js');
//importScripts('https://www.gstatic.com/firebasejs/10.14.1/firebase-messaging.js');

//// Firebase configuration for service worker
//firebase.initializeApp({
//    apiKey: "AIzaSyDdIoSEwlKnPoj0rpR6SCabM1inuSKg5Ts",
//    authDomain: "fieldops-65cc0.firebaseapp.com",
//    projectId: "fieldops-65cc0",
//    storageBucket: "fieldops-65cc0.appspot.com",
//    messagingSenderId: "410053741923",
//    appId: "1:410053741923:web:3733ff0f2d3792b05ad756",
//    measurementId: "G-HH7C1N9RKY"
//});

//const messaging = firebase.messaging();

//// Handle background messages
//messaging.onBackgroundMessage((payload) => {
//    console.log('[firebase-messaging-sw.js] Received background message ', payload);

//    const notificationTitle = payload.notification.title;
//    const notificationOptions = {
//        body: payload.notification.body,
//        icon: '/firebase-logo.png' // Add a URL to your app's logo if needed
//    };

//    self.registration.showNotification(notificationTitle, notificationOptions);
//});
