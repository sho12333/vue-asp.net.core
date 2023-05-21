import { createApp } from "vue";
import "./style.css";
import "./input.css";
import App from "./App.vue";
import axios from "axios";
import router from "./router";

const http = axios.create({
  baseURL: "https://localhost:7108/",
  withCredentials: true,
});

const app = createApp(App);
app.config.globalProperties.$axios = http;

app.use(router).mount("#app");
