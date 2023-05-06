<template>
  <RouterLink to="/items">
    <RouterView />
  </RouterLink>
</template>

<script setup>
import { RouterLink, RouterView } from "vue-router";
</script>
