<template>
  <div class="login-wrapper">
    <div class="login-form">
      <h2>ログイン</h2>
      <n-form ref="loginForm" label-placement="top">
        <n-form-item label="ユーザー名" required>
          <n-input v-model="loginForm.username" />
        </n-form-item>
        <n-form-item label="パスワード" required>
          <n-input v-model="loginForm.password" type="password" />
        </n-form-item>
        <n-form-item>
          <n-button type="primary" @click="login">ログイン</n-button>
        </n-form-item>
      </n-form>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import { NForm, NFormItem, NInput, NButton } from "naive-ui";
import { useRouter } from "vue-router";

const loginForm = ref({
  username: "",
  password: "",
});

const router = useRouter();

const login = () => {
  if (loginForm.value.username === "admin" && loginForm.value.password === "password") {
    router.push("/dashboard");
  } else {
    alert("ユーザー名またはパスワードが違います");
  }
};
</script>
