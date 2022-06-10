import { createApp } from 'vue'
import App from './App.vue'

import router from './router/index.js';

import primeVue from 'primevue/config';
import confirmationService from 'primevue/confirmationservice';
import toastService from 'primevue/toastservice';
import 'primevue/resources/themes/saga-blue/theme.css'
import 'primevue/resources/primevue.min.css'
import 'primeicons/primeicons.css'
import '/node_modules/primeflex/primeflex.css'


const app = createApp(App);

app.use(primeVue);
app.use(router);
app.use(confirmationService);
app.use(toastService);

app.mount('#app')
