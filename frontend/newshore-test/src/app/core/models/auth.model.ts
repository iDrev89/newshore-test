export class AuthToken {
  access_token!: string;
  refresh_token!: string;
}

export class UserDetail {
  username!: string;
  password!: string;
}

export interface User {
  email: string;
  id: string;
  userName: string;
}

export interface UserData {
  user: User;
  token: string;
}
