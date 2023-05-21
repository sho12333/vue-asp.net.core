<template>
  <NavBar />
  <RouterView />
</template>

<script setup>
import NavBar from "./components/NavBar.vue";
import { RouterLink, RouterView } from "vue-router";
</script>
