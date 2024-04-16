export class BaseClient {
  authToken = '';
  protected constructor() {}

  setAuthToken(token: string) {
    this.authToken = token;
    return this;
  }

  protected transformOptions = (options: RequestInit): Promise<RequestInit> => {
    // @ts-ignore
    options.headers['Authorization'] = `Bearer ${this.authToken}`;
    return Promise.resolve(options);
  };
}
