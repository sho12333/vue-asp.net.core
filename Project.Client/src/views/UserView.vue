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
        <nav aria-label="Page navigation example">
          <ul class="inline-flex -space-x-px">
            <li>
              <a
                href="#"
                @click="changePage(currentPage - 1)"
                :class="pageButtonClasses(currentPage - 1)"
              >
                Previous
              </a>
            </li>
            <li v-for="pageNumber in totalPage" :key="pageNumber">
              <a
                href="#"
                @click="changePage(pageNumber)"
                :class="pageButtonClasses(pageNumber)"
              >
                {{ pageNumber }}
              </a>
            </li>
            <li>
              <a
                href="#"
                @click="changePage(currentPage + 1)"
                :class="pageButtonClasses(currentPage + 1)"
              >
                Next
              </a>
            </li>
          </ul>
        </nav>
      </div>
    </div>
  </div>
</template>

<script>
import "jspreadsheet-ce/dist/jspreadsheet.css";
</script>

<script setup>
import {
  ref,
  reactive,
  onMounted,
  inject,
  getCurrentInstance,
  computed,
} from "vue";
import { ChevronUpIcon } from "@heroicons/vue/24/outline";
const axios = getCurrentInstance().appContext.config.globalProperties.$axios;

let users = ref([]);
let currentPage = ref(1);
let pageSize = ref(10);
let totalItems = ref(0);
let totalPage = ref(0);

const searchItems = ref([
  { label: "ユーザーID", value: "", isOpen: false },
  { label: "ユーザー名", value: "", isOpen: false },
  { label: "権限", value: "", isOpen: false },
]);

const isOpen = ref(false);
const search = async () => {
  try {
    const response = await axios.post("api/users/search", {
      userId: searchItems.value[0].value,
      userName: searchItems.value[1].value,
      authority: searchItems.value[2].value,
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
  if (pageNumber <= 0) return;
  currentPage.value = pageNumber;
  search();
};

const pageButtonClasses = (pageNumber) => {
  return pageNumber === currentPage.value
    ? "px-3 py-2 text-blue-600 border border-gray-300 bg-blue-50 hover:bg-blue-100 hover:text-blue-700 dark:border-gray-700 dark:bg-gray-700 dark:text-white"
    : "px-3 py-2 leading-tight text-gray-500 bg-white border border-gray-300 hover:bg-gray-100 hover:text-gray-700 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white";
};

const setTotalPage = () => {
  totalPage.value = Math.ceil(totalItems.value / pageSize.value);
};
</script>
