<template>
  <v-app id="inspire">
    <v-app-bar color="info">
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>

      <v-app-bar-title>サンプルアプリ</v-app-bar-title>
    </v-app-bar>

    <v-navigation-drawer v-model="drawer" location="left" temporary>
      <v-list density="compact" nav>
        <v-list-item
          prepend-icon="mdi-view-dashboard"
          title="Home"
          value="home"
        ></v-list-item>
        <a href="users">
          <v-list-item
            prepend-icon="mdi-account"
            title="ユーザー情報"
            value="users"
          ></v-list-item>
        </a>
      </v-list>
    </v-navigation-drawer>
    <v-main><router-view /> </v-main>
  </v-app>
</template>

<script setup>
import { onMounted, ref, reactive } from "vue";

const drawer = ref(false);
</script>
