<template>
  <div class="mx-auto max-w-7xl p-4 sm:p-6 lg:p-8">
    <div class="text-h4">ユーザ情報</div>

    <v-expansion-panels class="mt-5">
      <v-expansion-panel title="検索条件">
        <v-expansion-panel-text>
          <v-container>
            <v-row no-gutters>
              <v-col cols="12" sm="4">
                <v-text-field
                  class="ma-2 pa-2"
                  label="ユーザーID"
                  variant="solo-filled"
                  v-model="searchItems[0].value"
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="4">
                <v-text-field
                  class="ma-2 pa-2"
                  label="ユーザー名"
                  variant="solo-filled"
                  v-model="searchItems[1].value"
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="4">
                <v-text-field
                  class="ma-2 pa-2"
                  label="権限"
                  variant="solo-filled"
                  v-model="searchItems[2].value"
                ></v-text-field>
              </v-col>
            </v-row>
            <v-btn @click="search" color="info">検索</v-btn>
          </v-container>
        </v-expansion-panel-text>
      </v-expansion-panel>
    </v-expansion-panels>

    <v-table fixed-header height="300px" class="mt-10">
      <thead>
        <tr>
          <th class="text-left">ID</th>
          <th class="text-left">名称</th>
          <th class="text-left">略称</th>
          <th class="text-left">権限</th>
          <th class="text-left">メールアドレス</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="user in users" :key="user.id">
          <td>
            {{ user.userId }}
          </td>
          <td>
            {{ user.userName }}
          </td>
          <td>
            {{ user.userShortName }}
          </td>
          <td>
            {{ user.authority }}
          </td>
          <td>
            {{ user.mailAddress }}
          </td>
        </tr>
      </tbody>
    </v-table>

    <div class="text-center mt-5">
      <v-pagination
        :model-value="currentPage"
        :length="totalItems"
        rounded="circle"
        @update:model-value="changePage"
      ></v-pagination>
    </div>
  </div>
</template>

<script></script>

<script setup>
import { ref, reactive, getCurrentInstance } from "vue";
const axios = getCurrentInstance().appContext.config.globalProperties.$axios;

let users = ref([]);
let currentPage = ref(1);
let pageSize = ref(10);
let totalItems = ref(0);
let totalPage = ref(0);

const searchItems = reactive([
  { label: "ユーザーID", value: "" },
  { label: "ユーザー名", value: "" },
  { label: "権限", value: "" },
]);

const search = async () => {
  try {
    const response = await axios.post("api/users/search", {
      userId: searchItems[0].value,
      userName: searchItems[1].value,
      authority: searchItems[2].value,
      pageNumber: (currentPage.value - 1) * pageSize.value,
      pageSize: pageSize.value,
    });
    users.value = response.data;
    totalItems.value = users.value.length;
    setTotalPage();
  } catch (error) {
    console.error(error);
  }
};

const changePage = (pageNumber) => {
  currentPage.value = pageNumber;
  search();
};

const setTotalPage = () => {
  totalPage.value = Math.ceil(totalItems.value / pageSize.value);
};
</script>
