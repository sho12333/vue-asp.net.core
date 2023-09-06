import { createApp } from "vue";
import "./style.css";
import "./input.css";
import App from "./App.vue";
import axios from "axios";
import router from "./router";
import "vuetify/styles";
import { createVuetify } from "vuetify";
import * as components from "vuetify/components";
import * as directives from "vuetify/directives";

const vuetify = createVuetify({
  components,
  directives,
});

const http = axios.create({
  baseURL: "https://localhost:7108/",
  withCredentials: true,
});

const app = createApp(App);
app.config.globalProperties.$axios = http;

app
  .use(router)
  // .use(
  //   createAuth0({
  //     domain: import.meta.env.VITE_AUTH0_DOMAIN,
  //     clientId: import.meta.env.VITE_AUTH0_CLIENT_ID,
  //     authorizationParams: {
  //       redirect_uri: import.meta.env.VITE_AUTH0_CALLBACK_URL,
  //     },
  //   })
  // )
  .use(vuetify)
  .mount("#app");
