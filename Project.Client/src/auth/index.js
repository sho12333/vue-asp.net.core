import { createAuth0Client } from "@auth0/auth0-spa-js";
import { reactive } from "vue";

export const AuthState = reactive({
  user: null,
  loading: false,
  isAuthenticated: false,
  auth0: null,
});

const config = {
  domain: import.meta.env.VITE_AUTH0_DOMAIN,
  clientId: import.meta.env.VITE_AUTH0_CLIENT_ID,
  redirect_uri: import.meta.env.VITE_AUTH0_CALLBACK_URL,
};

export const useAuth0 = (state) => {
  const handleStateChange = async () => {
    state.isAuthenticated = !!(await state.auth0.isAuthenticated());
    state.user = await state.auth0.getUser();
    state.loading = false;
  };

  const initAuth = () => {
    state.loading = true;
    createAuth0Client({
      domain: config.domain,
      clientId: config.clientId,
      cacheLocation: "localstorage",
      authorizationParams: {
        redirect_uri: config.redirect_uri,
      },
    }).then(async (auth) => {
      state.auth0 = auth;
      await handleStateChange();
    });
  };

  const login = async () => {
    await state.auth0.loginWithPopup();
    await handleStateChange();
  };

  const logout = async () => {
    state.auth0.logout({
      returnTo: window.location.origin,
    });
  };

  return {
    login,
    logout,
    initAuth,
  };
};
