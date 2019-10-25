import Vue from "vue";
import App from "./App.vue";
import { store } from './store';
import { router } from "./router";
import Argon from "./plugins/argon-kit";
import './registerServiceWorker';
import './assets/css/style.css';

Vue.config.productionTip = false;
Vue.use(Argon);
new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
