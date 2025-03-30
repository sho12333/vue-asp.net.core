export interface ApiResponse<T> {
  data: T | null;
  error: string | null;
  status: number;
}

export interface RequestOptions {
  headers?: HeadersInit;
  timeout?: number;
  credentials?: RequestCredentials;
  cache?: RequestCache;
}

export type RequestData = Record<string, unknown> | unknown[] | null;

export class FetchClient {
  private baseUrl: string;
  private defaultOptions: RequestOptions;

  /**
   * コンストラクタ
   * @param baseUrl APIのベースURL
   * @param defaultOptions デフォルトのリクエストオプション
   */
  constructor(baseUrl: string = "", defaultOptions: RequestOptions = {}) {
    this.baseUrl = baseUrl;
    this.defaultOptions = {
      headers: {
        "Content-Type": "application/json",
        Accept: "application/json",
      },
      credentials: "same-origin",
      ...defaultOptions,
    };
  }

  async get<T>(url: string, options: RequestOptions = {}): Promise<ApiResponse<T>> {
    return this.request<T>(url, "GET", null, options);
  }

  async post<T>(
    url: string,
    data: RequestData,
    options: RequestOptions = {}
  ): Promise<ApiResponse<T>> {
    return this.request<T>(url, "POST", data, options);
  }

  async put<T>(
    url: string,
    data: RequestData,
    options: RequestOptions = {}
  ): Promise<ApiResponse<T>> {
    return this.request<T>(url, "PUT", data, options);
  }

  async delete<T>(url: string, options: RequestOptions = {}): Promise<ApiResponse<T>> {
    return this.request<T>(url, "DELETE", null, options);
  }

  private async request<T>(
    url: string,
    method: string,
    data: RequestData = null,
    options: RequestOptions = {}
  ): Promise<ApiResponse<T>> {
    const fullUrl = `${this.baseUrl}${url}`;

    // リクエストのタイムアウト処理の準備
    const { timeout, ...restOptions } = options;

    // リクエスト設定の作成
    const fetchOptions: RequestInit = {
      method,
      headers: {
        ...this.defaultOptions.headers,
        ...options.headers,
      },
      credentials: options.credentials || this.defaultOptions.credentials,
      cache: options.cache || this.defaultOptions.cache,
      ...restOptions,
    };

    if (data) {
      fetchOptions.body = JSON.stringify(data);
    }

    try {
      const fetchPromise = fetch(fullUrl, fetchOptions);
      let response: Response;

      if (timeout) {
        const timeoutPromise = new Promise<Response>((_, reject) => {
          setTimeout(() => reject(new Error("Request timeout")), timeout);
        });

        response = (await Promise.race([fetchPromise, timeoutPromise])) as Response;
      } else {
        response = await fetchPromise;
      }

      if (!response.ok) {
        let errorMessage: string;

        try {
          const errorResponse = await response.json();
          errorMessage =
            errorResponse.message || `API error: ${response.status} ${response.statusText}`;
        } catch (e: unknown) {
          errorMessage = `API error: ${response.status} ${response.statusText}`;
        }

        return {
          data: null,
          error: errorMessage,
          status: response.status,
        };
      }

      if (response.status === 204) {
        return {
          data: {} as T,
          error: null,
          status: 204,
        };
      }

      const responseData = await response.json();

      return {
        data: responseData,
        error: null,
        status: response.status,
      };
    } catch (error) {
      const errorMessage = error instanceof Error ? error.message : "Network error";

      return {
        data: null,
        error: errorMessage,
        status: 0,
      };
    }
  }
}

export const createApiClient = (baseUrl: string, defaultOptions?: RequestOptions) => {
  return new FetchClient(baseUrl, defaultOptions);
};
