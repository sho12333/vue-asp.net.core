<template>
  <div v-if="!AuthState.loading">
    <div v-if="!AuthState.isAuthenticated">
      <v-btn
        class="text-white text-subtitle-1"
        color="#5865f2"
        size="small"
        variant="flat"
        @click="login()"
        >ログイン</v-btn
      >
    </div>

    <div v-else>
      <p>
        Welcome to VueAuth <strong>{{ AuthState.user.name }}</strong>
      </p>
      <button @click="logout()" class="btn btn-secondary">Logout</button>
    </div>
  </div>

  <div v-else>Loading ...</div>
</template>

<script setup>
import NavBar from "./components/NavBar.vue";
import { onMounted } from "vue";
import { useAuth0, AuthState } from "./auth/index";
const { login, logout, initAuth } = useAuth0(AuthState);
console.log(AuthState);

initAuth();
</script>
