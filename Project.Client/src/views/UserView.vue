<template>
  <div class="mx-auto max-w-7xl px-4 sm:px-6 lg:px-8">
    <div class="title mt-4 text-3xl">ユーザ情報</div>

    <div class="rounded overflow-hidden shadow-lg">
      <div
        class="px-6 py-4 border-b border-gray-200 cursor-pointer select-none flex justify-between items-center"
        @click="isOpen = !isOpen"
      >
        <div class="font-bold text-xl mb-2">検索条件</div>
        <ChevronUpIcon
          :class="{
            'transform rotate-180 transition-transform duration-200': isOpen,
          }"
          class="h-6 w-6 text-gray-500"
        />
      </div>
      <div
        v-show="isOpen"
        class="transition-all px-6 py-4 grid sm:grid-cols-2 lg:grid-cols-3 gap-4"
      >
        <div v-for="(item, index) in searchItems" :key="index" @click.stop>
          <label class="block text-gray-700 text-sm font-bold mb-2">
            {{ item.label }}
          </label>
          <input
            v-model="item.value"
            class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            type="text"
            :placeholder="item.label"
          />
        </div>
        <button
          class="mt-4 bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded"
          @click="search"
        >
          検索
        </button>
      </div>
    </div>

    <div class="flex flex-col mt-10">
      <div class="-mx-2 overflow-x-auto sm:-mx-6 lg:-mx-8">
        <div class="inline-block min-w-full py-2 align-middle sm:px-6 lg:px-8">
          <div
            class="overflow-hidden shadow-sm rounded-lg border-b border-gray-200"
          >
            <!-- Table -->
            <div style="max-height: 50vh; overflow-y: auto">
              <table class="min-w-full divide-y divide-gray-200">
                <thead
                  class="sticky top-0 bg-neutral-800 text-white z-10 text-left"
                >
                  <tr>
                    <th scope="col" class="px-6 py-4">ユーザーID</th>
                    <th scope="col" class="px-6 py-4">ユーザー名</th>
                    <th scope="col" class="px-6 py-4">略称</th>
                    <th scope="col" class="px-6 py-4">権限</th>
                    <th scope="col" class="px-6 py-4">メールアドレス</th>
                  </tr>
                </thead>
                <tbody class="bg-white divide-y divide-gray-200">
                  <tr v-for="user in users" :key="user.id">
                    <td class="px-6 py-4 whitespace-nowrap">
                      {{ user.userId }}
                    </td>
                    <td class="px-6 py-4 whitespace-nowrap">
                      {{ user.userName }}
                    </td>
                    <td class="px-6 py-4 whitespace-nowrap">
                      {{ user.userShortName }}
                    </td>
                    <td class="px-6 py-4 whitespace-nowrap">
                      {{ user.authority }}
                    </td>
                    <td class="px-6 py-4 whitespace-nowrap">
                      {{ user.mailAddress }}
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>

      <!-- Pagination -->
      <div
        class="px-5 py-5 bg-white border-t flex flex-col xs:flex-row items-center xs:justify-between"
      >
        <span class="text-xs xs:text-sm text-gray-900">
          Showing 1 to 4 of 50 Entries
        </span>
        <div class="inline-flex mt-2 xs:mt-0">
          <button
            class="text-sm bg-gray-300 hover:bg-gray-400 text-gray-800 font-semibold py-2 px-4 rounded-l"
          >
            Prev
          </button>
          <button
            class="text-sm bg-gray-300 hover:bg-gray-400 text-gray-800 font-semibold py-2 px-4 rounded-r"
          >
            Next
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import "jspreadsheet-ce/dist/jspreadsheet.css";
</script>

<script setup>
import { ref, reactive, onMounted, inject, getCurrentInstance } from "vue";
import jspreadsheet from "jspreadsheet-ce";
import { ChevronUpIcon } from "@heroicons/vue/24/outline";
const axios = getCurrentInstance().appContext.config.globalProperties.$axios;

let users = ref([]);
let currentPage = ref(1);
let pageSize = ref(10);

const searchItems = ref([
  { label: "ユーザーID", value: "", isOpen: false },
  { label: "ユーザー名", value: "", isOpen: false },
  { label: "権限", value: "", isOpen: false },
]);

const isOpen = ref(false);
const getUsers = async (pageNumber, pageSize) => {
  try {
    const response = await axios.get("api/users", {
      params: {
        searchUser: searchItems,
        pageNumber: pageNumber,
        pageSize: pageSize,
      },
    });
  } catch (error) {
    console.error(error);
  }
};

const search = async () => {
  try {
    const response = await axios.post("api/users/search", {
      params: {
        searchUser: searchItems,
      },
    });
    users.value = response.data;
    console.log(users.value);
  } catch (error) {
    console.error(error);
  }
};

onMounted(() => {});

const handlePageChange = (el, cell, col, row, value) => {
  if (col === "page") {
    currentPage.value = value;
    getUsers(currentPage.value, pageSize.value);
  }
};
</script>
