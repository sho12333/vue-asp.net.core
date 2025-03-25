import HomeView from "@/views/HomeView.vue";
import OrderView from "@/views/OrderView.vue";
import { createRouter, createWebHistory, type RouteRecordRaw } from "vue-router";

// import Dashboard from "../views/Dashboard.vue";
// const InventoryList = () => import("../views/inventory/InventoryList.vue");
// const InventoryInput = () => import("../views/inventory/InventoryInput.vue");
// const OrderList = () => import("../views/orders/OrderList.vue");
// const OrderCreate = () => import("../views/orders/OrderCreate.vue");
// const CustomerList = () => import("../views/customers/CustomerList.vue");
// const Settings = () => import("../views/Settings.vue");

// ルートの定義
const routes = [
  // const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "dashboard",
    component: HomeView,
    // meta: {
    //   title: "ダッシュボード",
    // //   requiresAuth: true,
    // },
  },
  //   {
  //     path: "/inventory",
  //     name: "inventory",
  //     redirect: "/inventory/list",
  //     meta: {
  //       title: "在庫管理",
  //       requiresAuth: true,
  //     },
  //     children: [
  //       {
  //         path: "list",
  //         name: "inventory-list",
  //         component: null,
  //         meta: {
  //           title: "在庫一覧",
  //           requiresAuth: true,
  //         },
  //       },
  //       {
  //         path: "input",
  //         name: "inventory-input",
  //         component: null,
  //         meta: {
  //           title: "在庫入力",
  //           requiresAuth: true,
  //         },
  //       },
  //     ],
  //   },
  {
    path: "/orders",
    name: "orders",
    // redirect: "/orders/list",
    component: OrderView,
    // meta: {
    //   title: "受注管理",
    //   requiresAuth: true,
    // },
  },
  //     // children: [
  //     //   {
  //     //     path: "list",
  //     //     name: "order-list",
  //     //     component: null,
  //     //     meta: {
  //     //       title: "受注一覧",
  //     //       requiresAuth: true,
  //     //     },
  //     //   },
  //     //   {
  //     //     path: "create",
  //     //     name: "order-create",
  //     //     component: null,
  //     //     meta: {
  //     //       title: "受注登録",
  //     //       requiresAuth: true,
  //     //     },
  //     //   },
  //     // ],
  //   },
  //   //   {
  //   //     path: "/customers",
  //   //     name: "customers",
  //   //     component: CustomerList,
  //   //     meta: {
  //   //       title: "顧客一覧",
  //   //       requiresAuth: true,
  //   //     },
  //   //   },
  //   //   {
  //   //     path: "/settings",
  //   //     name: "settings",
  //   //     component: Settings,
  //   //     meta: {
  //   //       title: "システム設定",
  //   //       requiresAuth: true,
  //   //     },
  //   //   },
  //   {
  //     path: "/login",
  //     name: "login",
  //     component: () => import("../views/Login.vue"),
  //     meta: {
  //       title: "ログイン",
  //       requiresAuth: false,
  //     },
  //   },
  //   {
  //     path: "/:pathMatch(.*)*",
  //     name: "not-found",
  //     component: () => import("../views/NotFound.vue"),
  //     meta: {
  //       title: "ページが見つかりません",
  //       requiresAuth: false,
  //     },
  //   },
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
});

// ナビゲーションガード
// router.beforeEach((to, from, next) => {
//   document.title = `${to.meta.title || "在庫・受注管理システム"}`;

//   // 認証のチェック
//   const isAuthenticated = localStorage.getItem("token") !== null;

//   if (to.meta.requiresAuth && !isAuthenticated) {
//     next({ name: "login", query: { redirect: to.fullPath } });
//   } else {
//     next();
//   }
// });

export default router;
