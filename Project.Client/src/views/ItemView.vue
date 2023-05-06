<template>
  <div>
    <li v-for="item in items" :key="item.id">
      {{ item.name }}
    </li>
  </div>
</template>

<script setup>
import axios from "axios";
import { ref, reactive, onMounted } from "vue";

let items = ref([]);

onMounted(() => {
  axios
    .get("https://localhost:7108/api/item", {
      withCredentials: true,
    })
    .then((response) => {
      console.log(response.data);
      items.value = response.data;
    })
    .catch((error) => {
      console.error(error);
    });
});
</script>
